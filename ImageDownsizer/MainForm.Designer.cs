namespace ImageDownsizer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            bottomPanel = new Panel();
            groupBox = new GroupBox();
            parallelLoopBtn = new Button();
            consequentialBtn = new Button();
            timeLabel = new Label();
            parallelThreadsBtn = new Button();
            downscaleFactorLabel = new Label();
            bilinearInterpolationCheckBox = new CheckBox();
            downscaleFactorTextBox = new TextBox();
            saveImageBtn = new Button();
            openImageBtn = new Button();
            leftPanel = new Panel();
            baseImagePicBox = new PictureBox();
            rightPanel = new Panel();
            newImagePicBox = new PictureBox();
            percentLabel = new Label();
            bottomPanel.SuspendLayout();
            groupBox.SuspendLayout();
            leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)baseImagePicBox).BeginInit();
            rightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)newImagePicBox).BeginInit();
            SuspendLayout();
            // 
            // bottomPanel
            // 
            bottomPanel.BackColor = Color.DimGray;
            bottomPanel.Controls.Add(groupBox);
            bottomPanel.Controls.Add(saveImageBtn);
            bottomPanel.Controls.Add(openImageBtn);
            bottomPanel.Location = new Point(0, 446);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Size = new Size(1182, 156);
            bottomPanel.TabIndex = 0;
            // 
            // groupBox
            // 
            groupBox.Controls.Add(percentLabel);
            groupBox.Controls.Add(parallelLoopBtn);
            groupBox.Controls.Add(consequentialBtn);
            groupBox.Controls.Add(timeLabel);
            groupBox.Controls.Add(parallelThreadsBtn);
            groupBox.Controls.Add(downscaleFactorLabel);
            groupBox.Controls.Add(bilinearInterpolationCheckBox);
            groupBox.Controls.Add(downscaleFactorTextBox);
            groupBox.ForeColor = Color.LightGray;
            groupBox.Location = new Point(178, 17);
            groupBox.Name = "groupBox";
            groupBox.Size = new Size(824, 118);
            groupBox.TabIndex = 1;
            groupBox.TabStop = false;
            groupBox.Text = "Settings";
            // 
            // parallelLoopBtn
            // 
            parallelLoopBtn.ForeColor = SystemColors.ControlText;
            parallelLoopBtn.Location = new Point(594, 34);
            parallelLoopBtn.Name = "parallelLoopBtn";
            parallelLoopBtn.Size = new Size(130, 29);
            parallelLoopBtn.TabIndex = 9;
            parallelLoopBtn.Text = "Parallel Loop";
            parallelLoopBtn.UseVisualStyleBackColor = true;
            parallelLoopBtn.Click += parallelLoopBtn_Click;
            // 
            // consequentialBtn
            // 
            consequentialBtn.ForeColor = SystemColors.ControlText;
            consequentialBtn.Location = new Point(266, 34);
            consequentialBtn.Name = "consequentialBtn";
            consequentialBtn.Size = new Size(130, 29);
            consequentialBtn.TabIndex = 4;
            consequentialBtn.Text = "Consequential";
            consequentialBtn.UseVisualStyleBackColor = true;
            consequentialBtn.Click += consequentialBtn_Click;
            // 
            // timeLabel
            // 
            timeLabel.AutoSize = true;
            timeLabel.ForeColor = Color.LightGray;
            timeLabel.Location = new Point(266, 78);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(228, 20);
            timeLabel.TabIndex = 1;
            timeLabel.Text = "Measured Time for Execution: ms";
            // 
            // parallelThreadsBtn
            // 
            parallelThreadsBtn.ForeColor = SystemColors.ControlText;
            parallelThreadsBtn.Location = new Point(430, 34);
            parallelThreadsBtn.Name = "parallelThreadsBtn";
            parallelThreadsBtn.Size = new Size(130, 29);
            parallelThreadsBtn.TabIndex = 5;
            parallelThreadsBtn.Text = "Parallel Threads";
            parallelThreadsBtn.UseVisualStyleBackColor = true;
            parallelThreadsBtn.Click += parallelThreadsBtn_Click;
            // 
            // downscaleFactorLabel
            // 
            downscaleFactorLabel.AutoSize = true;
            downscaleFactorLabel.ForeColor = Color.LightGray;
            downscaleFactorLabel.Location = new Point(22, 37);
            downscaleFactorLabel.Name = "downscaleFactorLabel";
            downscaleFactorLabel.Size = new Size(128, 20);
            downscaleFactorLabel.TabIndex = 8;
            downscaleFactorLabel.Text = "Downscale Factor:";
            // 
            // bilinearInterpolationCheckBox
            // 
            bilinearInterpolationCheckBox.AutoSize = true;
            bilinearInterpolationCheckBox.ForeColor = Color.LightGray;
            bilinearInterpolationCheckBox.Location = new Point(31, 77);
            bilinearInterpolationCheckBox.Name = "bilinearInterpolationCheckBox";
            bilinearInterpolationCheckBox.Size = new Size(171, 24);
            bilinearInterpolationCheckBox.TabIndex = 6;
            bilinearInterpolationCheckBox.Text = "Bilinear Interpolation";
            bilinearInterpolationCheckBox.UseVisualStyleBackColor = true;
            bilinearInterpolationCheckBox.CheckedChanged += bilinearInterpolationCheckBox_CheckedChanged;
            // 
            // downscaleFactorTextBox
            // 
            downscaleFactorTextBox.Location = new Point(156, 34);
            downscaleFactorTextBox.Name = "downscaleFactorTextBox";
            downscaleFactorTextBox.Size = new Size(56, 27);
            downscaleFactorTextBox.TabIndex = 7;
            downscaleFactorTextBox.TextAlign = HorizontalAlignment.Right;
            // 
            // saveImageBtn
            // 
            saveImageBtn.Location = new Point(1028, 29);
            saveImageBtn.Name = "saveImageBtn";
            saveImageBtn.Size = new Size(120, 30);
            saveImageBtn.TabIndex = 2;
            saveImageBtn.Text = "Save Image";
            saveImageBtn.UseVisualStyleBackColor = true;
            saveImageBtn.Click += saveImageBtn_Click;
            // 
            // openImageBtn
            // 
            openImageBtn.Location = new Point(34, 29);
            openImageBtn.Name = "openImageBtn";
            openImageBtn.Size = new Size(120, 30);
            openImageBtn.TabIndex = 0;
            openImageBtn.Text = "Open Image";
            openImageBtn.UseVisualStyleBackColor = true;
            openImageBtn.Click += openImageBtn_Click;
            // 
            // leftPanel
            // 
            leftPanel.BackColor = Color.DarkGray;
            leftPanel.Controls.Add(baseImagePicBox);
            leftPanel.Location = new Point(34, 34);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size(540, 380);
            leftPanel.TabIndex = 1;
            // 
            // baseImagePicBox
            // 
            baseImagePicBox.Dock = DockStyle.Fill;
            baseImagePicBox.Location = new Point(0, 0);
            baseImagePicBox.Name = "baseImagePicBox";
            baseImagePicBox.Size = new Size(540, 380);
            baseImagePicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            baseImagePicBox.TabIndex = 0;
            baseImagePicBox.TabStop = false;
            // 
            // rightPanel
            // 
            rightPanel.BackColor = Color.DarkGray;
            rightPanel.Controls.Add(newImagePicBox);
            rightPanel.Location = new Point(608, 34);
            rightPanel.Name = "rightPanel";
            rightPanel.Size = new Size(540, 380);
            rightPanel.TabIndex = 2;
            // 
            // newImagePicBox
            // 
            newImagePicBox.Dock = DockStyle.Fill;
            newImagePicBox.Location = new Point(0, 0);
            newImagePicBox.Name = "newImagePicBox";
            newImagePicBox.Size = new Size(540, 380);
            newImagePicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            newImagePicBox.TabIndex = 0;
            newImagePicBox.TabStop = false;
            // 
            // percentLabel
            // 
            percentLabel.AutoSize = true;
            percentLabel.Location = new Point(215, 37);
            percentLabel.Name = "percentLabel";
            percentLabel.Size = new Size(21, 20);
            percentLabel.TabIndex = 10;
            percentLabel.Text = "%";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(1182, 603);
            Controls.Add(rightPanel);
            Controls.Add(leftPanel);
            Controls.Add(bottomPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Image Downsizer";
            bottomPanel.ResumeLayout(false);
            groupBox.ResumeLayout(false);
            groupBox.PerformLayout();
            leftPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)baseImagePicBox).EndInit();
            rightPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)newImagePicBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel bottomPanel;
        private Panel leftPanel;
        private Panel rightPanel;
        private Button openImageBtn;
        private PictureBox baseImagePicBox;
        private PictureBox newImagePicBox;
        private Label timeLabel;
        private Button saveImageBtn;
        private Button parallelThreadsBtn;
        private Button consequentialBtn;
        private CheckBox bilinearInterpolationCheckBox;
        private TextBox downscaleFactorTextBox;
        private Label downscaleFactorLabel;
        private GroupBox groupBox;
        private Button parallelLoopBtn;
        private Label percentLabel;
    }
}
