using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClickReplay {
    public partial class MainForm : Form {

        private ClickReplay replay;
        private bool recording;
        private bool playing;
        private CancellationTokenSource cts;

        public MainForm() {
            InitializeComponent();
            TopMost = true;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void RecordButton_Click(object sender, EventArgs e) {
            if (!recording) {
                replay = new ClickReplay();
                replay.StartRecording();
                PlayButton.Enabled = false;
                RecordButton.Image = Properties.Resources.Stop;
                RecordButton.Text = "Stop";
                StatusLabel.Text = "Recording...";
                recording = true;
            }
            else {
                replay.StopRecording();
                PlayButton.Enabled = true;
                RecordButton.Image = Properties.Resources.button_rec;
                RecordButton.Text = "Record";
                recording = false;
                StatusLabel.Text = "Press play to play back";
                ClicksLabel.Text = "Saved clicks: " + replay.Count;
            }
        }

        private async void PlayButton_Click(object sender, EventArgs e) {
            if (!playing) {
                RecordButton.Enabled = false;
                StatusLabel.Text = "Playing...";
                PlayButton.Text = "Stop";
                PlayButton.Image = Properties.Resources.Stop;
                playing = true;
                while (true) {
                    try {
                        await replay.StartPlayback();
                    }
                    catch (OperationCanceledException) {
                        break;
                    }
                    if (!LoopBox.Checked) {
                        break;
                    }
                }
                playing = false;
                StatusLabel.Text = "Press play to play back";
                RecordButton.Enabled = true;
                PlayButton.Text = "Play";
                PlayButton.Image = Properties.Resources.play_icon;
            }
            else {
                replay.StopPlayback();
                StatusLabel.Text = "Press play to play back";
                RecordButton.Enabled = true;
                PlayButton.Text = "Play";
                PlayButton.Image = Properties.Resources.play_icon;
                playing = false;
            }
            
        }
    }
}
