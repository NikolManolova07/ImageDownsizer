using System.Diagnostics;

namespace ImageDownsizer
{
    public partial class MainForm : Form
    {
        private Bitmap? baseImage;
        private Bitmap? downscaledImage;
        private Color[][] baseArray;
        private Color[][] newArray;
        private string downscaleApproach;

        // Declare Stopwatch for measuring time.
        private Stopwatch stopwatch;

        private enum DownscaleApproach
        {
            Consequential,
            ParallelThreads,
            ParallelLoop
        }

        public MainForm()
        {
            InitializeComponent();
            stopwatch = new Stopwatch();
            consequentialBtn.Enabled = false;
            parallelThreadsBtn.Enabled = false;
            parallelLoopBtn.Enabled = false;
            timeLabel.Visible = false;
        }

        private void PerformDownscale(DownscaleApproach approach)
        {
            if (baseImage == null)
            {
                MessageBox.Show("Please select an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Parse downscale factor from the TextBox.
            if (!double.TryParse(downscaleFactorTextBox.Text, out double downscaleFactor))
            {
                MessageBox.Show("Invalid downscale factor. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Start the Stopwatch.
            stopwatch.Restart();

            switch (approach)
            {
                case DownscaleApproach.Consequential:
                    {
                        baseArray = BitmapConverter.BitmapToArray(baseImage);
                        newArray = ImageProcessor.BilinearInterpolationConsequential(baseArray, (double)downscaleFactor / 100);
                        downscaledImage = BitmapConverter.ArrayToBitmap(newArray);
                        downscaleApproach = "Consequential";
                    }; break;
                case DownscaleApproach.ParallelThreads:
                    {
                        baseArray = BitmapConverter.BitmapToArray(baseImage);
                        newArray = ImageProcessorParallel.BilinearInterpolationParallelThreads(baseArray, (double)downscaleFactor / 100);
                        downscaledImage = BitmapConverter.ArrayToBitmap(newArray);
                        downscaleApproach = "Parallel Threads";
                    }; break;
                case DownscaleApproach.ParallelLoop:
                    {
                        baseArray = BitmapConverter.BitmapToArray(baseImage);
                        newArray = ImageProcessorParallel.BilinearInterpolationParallelLoop(baseArray, (double)downscaleFactor / 100);
                        downscaledImage = BitmapConverter.ArrayToBitmap(newArray);
                        downscaleApproach = "Parallel Loop";
                    }; break;
            }

            // Stop the Stopwatch.
            stopwatch.Stop();

            newImagePicBox.Image = downscaledImage;
            timeLabel.Visible = true;
            timeLabel.Text = $"Measured Time for {downscaleApproach} Execution: {stopwatch.ElapsedMilliseconds} ms";
        }

        private void openImageBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Select an Image File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    baseImage = new Bitmap(openFileDialog.FileName);
                    baseImagePicBox.Image = baseImage;
                    newImagePicBox.Image = null;
                    timeLabel.Text = string.Empty;
                }
            }
        }

        private void saveImageBtn_Click(object sender, EventArgs e)
        {
            if (downscaledImage == null)
            {
                MessageBox.Show("No downscaled image available to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*";
                saveFileDialog.Title = "Save Downscaled Image";
                saveFileDialog.DefaultExt = "jpg";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        downscaledImage.SetResolution(96, 96);
                        downscaledImage.Save(saveFileDialog.FileName);
                        MessageBox.Show("Image saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void bilinearInterpolationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (bilinearInterpolationCheckBox.Checked)
            {
                consequentialBtn.Enabled = true;
                parallelThreadsBtn.Enabled = true;
                parallelLoopBtn.Enabled = true;
            }
            else
            {
                consequentialBtn.Enabled = false;
                parallelThreadsBtn.Enabled = false;
                parallelLoopBtn.Enabled = false;
            }
        }

        private void consequentialBtn_Click(object sender, EventArgs e)
        {
            PerformDownscale(DownscaleApproach.Consequential);
        }

        private void parallelThreadsBtn_Click(object sender, EventArgs e)
        {
            PerformDownscale(DownscaleApproach.ParallelThreads);
        }

        private void parallelLoopBtn_Click(object sender, EventArgs e)
        {
            PerformDownscale(DownscaleApproach.ParallelLoop);
        }
    }
}
