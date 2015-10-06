using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;

namespace ClickReplay {
    public class ClickReplay {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        private const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;

        private MouseHookListener mouseListener;
        private KeyboardHookListener keyListener;
        private Stopwatch watch;
        private CancellationTokenSource cts;
        private Keys cancelKey;
        private List<Click> Clicks = new List<Click>();

        public int Count { get; private set; }

        public ClickReplay() {
            mouseListener = new MouseHookListener(new GlobalHooker());
            keyListener = new KeyboardHookListener(new GlobalHooker());
            Count = 0;
        }

        public void StartRecording() {
            mouseListener.Enabled = true;
            mouseListener.MouseDown += NewClick;
            watch = Stopwatch.StartNew();
        }

        public void StopRecording() {
            mouseListener.Enabled = false;
            mouseListener.MouseDown -= NewClick;
            watch.Stop();
            long lastTime = Clicks[Clicks.Count - 1].Elapsed;
            Clicks.RemoveAt(Clicks.Count-1);
            Clicks.Add(new Click(Point.Empty, lastTime));
            Count--;
        }

        public async Task StartPlayback(Keys stopKey = Keys.Escape) {
            keyListener.Enabled = true;
            keyListener.KeyDown += KeyDown;
            cancelKey = stopKey;
            cts = new CancellationTokenSource();
            await Play(cts.Token);
        }

        public void StopPlayback() {
            cts.Cancel();
        }

        private async Task Play(CancellationToken token) {
            Stopwatch t = Stopwatch.StartNew();
            foreach (Click click in Clicks) {
                token.ThrowIfCancellationRequested();
                await Task.Delay((int)(click.Elapsed - t.ElapsedMilliseconds), token);
                if (click.Position != Point.Empty) {
                    DoMouseClick(click.Position);
                }
            }
        }

        private void DoMouseClick(Point position) {
            Point oldPos = Cursor.Position;
            Cursor.Position = position;
            IntPtr oldWindow = GetForegroundWindow();
            const int nChars = 256;
            StringBuilder buff = new StringBuilder(nChars);
            if (GetWindowText(oldWindow, buff, nChars) > 0) {
                Console.WriteLine(buff.ToString());
            }
            mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, position.X, position.Y, 0, 0);
            SwitchToThisWindow(oldWindow, true);
            Cursor.Position = oldPos;
        }

        private void NewClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                Clicks.Add(new Click(e.Location, watch.ElapsedMilliseconds));
                Count++;
            }
        }

        private void KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == cancelKey) {
                StopPlayback();
            }
        }

        private struct Click {
            public long Elapsed { get; private set; }
            public Point Position { get; private set; }

            public Click(Point position, long elapsed)
                : this() {
                Elapsed = elapsed;
                Position = position;
            }
        }

    }

    
}
