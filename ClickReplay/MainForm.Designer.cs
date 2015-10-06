namespace ClickReplay {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.StatusLabel = new System.Windows.Forms.Label();
            this.PlayButton = new System.Windows.Forms.Button();
            this.RecordButton = new System.Windows.Forms.Button();
            this.LoopBox = new System.Windows.Forms.CheckBox();
            this.ClicksLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(12, 9);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(104, 13);
            this.StatusLabel.TabIndex = 2;
            this.StatusLabel.Text = "Click record to begin";
            // 
            // PlayButton
            // 
            this.PlayButton.Enabled = false;
            this.PlayButton.Image = global::ClickReplay.Properties.Resources.play_icon;
            this.PlayButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PlayButton.Location = new System.Drawing.Point(105, 25);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(62, 23);
            this.PlayButton.TabIndex = 1;
            this.PlayButton.Text = "Play";
            this.PlayButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // RecordButton
            // 
            this.RecordButton.Image = global::ClickReplay.Properties.Resources.button_rec;
            this.RecordButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RecordButton.Location = new System.Drawing.Point(15, 25);
            this.RecordButton.Name = "RecordButton";
            this.RecordButton.Size = new System.Drawing.Size(84, 23);
            this.RecordButton.TabIndex = 0;
            this.RecordButton.Text = "Record";
            this.RecordButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RecordButton.UseVisualStyleBackColor = true;
            this.RecordButton.Click += new System.EventHandler(this.RecordButton_Click);
            // 
            // LoopBox
            // 
            this.LoopBox.AutoSize = true;
            this.LoopBox.Location = new System.Drawing.Point(15, 55);
            this.LoopBox.Name = "LoopBox";
            this.LoopBox.Size = new System.Drawing.Size(49, 17);
            this.LoopBox.TabIndex = 3;
            this.LoopBox.Text = "Loop";
            this.LoopBox.UseVisualStyleBackColor = true;
            // 
            // ClicksLabel
            // 
            this.ClicksLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ClicksLabel.AutoSize = true;
            this.ClicksLabel.Location = new System.Drawing.Point(82, 59);
            this.ClicksLabel.Name = "ClicksLabel";
            this.ClicksLabel.Size = new System.Drawing.Size(80, 13);
            this.ClicksLabel.TabIndex = 4;
            this.ClicksLabel.Text = "Saved clicks: 0\r\n";
            this.ClicksLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(180, 83);
            this.Controls.Add(this.ClicksLabel);
            this.Controls.Add(this.LoopBox);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.RecordButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "ClickReplay";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RecordButton;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.CheckBox LoopBox;
        private System.Windows.Forms.Label ClicksLabel;
    }
}