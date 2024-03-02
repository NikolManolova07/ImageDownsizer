using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDownsizer
{
    public class ImageProcessorParallel
    {
        // Bilinear interpolation with threads.
        public static Color[][] BilinearInterpolationParallelThreads(Color[][] inputImage, double scale)
        {
            int newWidth = (int)(inputImage[0].Length * scale);
            int newHeight = (int)(inputImage.Length * scale);

            Color[][] outputImage = new Color[newHeight][];

            int threadCount = Environment.ProcessorCount;
            // Calculate the number of rows each thread should process.
            int rowsPerThread = newHeight / threadCount;

            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < threadCount; i++)
            {
                // Calculate the starting row index for the current thread based on its index and the number of rows each thread should process.
                int startRow = i * rowsPerThread;
                // Calculate the ending row index for the current thread.
                int endRow = (i == threadCount - 1) ? newHeight : (i + 1) * rowsPerThread;

                Thread thread = new Thread(() =>
                {
                    for (int row = startRow; row < endRow; row++)
                    {
                        outputImage[row] = new Color[newWidth];

                        for (int col = 0; col < newWidth; col++)
                        {
                            double x = col / scale;
                            double y = row / scale;

                            int xFloor = (int)Math.Floor(x);
                            int yFloor = (int)Math.Floor(y);

                            int xCeil = Math.Min(xFloor + 1, inputImage[0].Length - 1);
                            int yCeil = Math.Min(yFloor + 1, inputImage.Length - 1);

                            double xRatio = x - xFloor;
                            double yRatio = y - yFloor;

                            Color interpolatedColor = BilinearInterpolate(
                                inputImage[yFloor][xFloor],
                                inputImage[yFloor][xCeil],
                                inputImage[yCeil][xFloor],
                                inputImage[yCeil][xCeil],
                                xRatio,
                                yRatio
                            );

                            outputImage[row][col] = interpolatedColor;
                        }
                    }
                });

                threads.Add(thread);
            }

            foreach (Thread thread in threads)
            {
                thread.Start();
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            return outputImage;
        }

        // Bilinear interpolation with a parallel loop.
        public static Color[][] BilinearInterpolationParallelLoop(Color[][] inputImage, double scale)
        {
            int newWidth = (int)(inputImage[0].Length * scale);
            int newHeight = (int)(inputImage.Length * scale);

            Color[][] outputImage = new Color[newHeight][];

            // Parallelize the outer loop.
            // The outer loop in the consequential version is: for (int row = 0; row < newHeight; row++) { ... }.
            // Now each iteration of the outer loop can be executed concurrently by different threads.
            Parallel.For(0, newHeight, row =>
            {
                // Each thread creates its own row in the output image.
                outputImage[row] = new Color[newWidth];

                // Process each column in parallel within the same row. The inner loop is still serial within each thread. 
                for (int col = 0; col < newWidth; col++)
                {
                    double x = col / scale;
                    double y = row / scale;

                    int xFloor = (int)Math.Floor(x);
                    int yFloor = (int)Math.Floor(y);

                    int xCeil = Math.Min(xFloor + 1, inputImage[0].Length - 1);
                    int yCeil = Math.Min(yFloor + 1, inputImage.Length - 1);

                    double xRatio = x - xFloor;
                    double yRatio = y - yFloor;

                    Color interpolatedColor = BilinearInterpolate(
                        inputImage[yFloor][xFloor],
                        inputImage[yFloor][xCeil],
                        inputImage[yCeil][xFloor],
                        inputImage[yCeil][xCeil],
                        xRatio,
                        yRatio
                    );

                    outputImage[row][col] = interpolatedColor;
                }
            });

            return outputImage;
        }

        // Perform Bilinear interpolation between the four given colors.
        // We estimate the color value at a non-grid position within a rectangular grid of colors.
        // The colors at the corners of a rectangular grid are represented by topLeft, topRight, bottomLeft and bottomRight.
        // The interpolation ratios in the horizontal and vertical directions are represented by xRatio and yRatio.
        // The ratios are the fractional distances between the target position and the two nearest grid points in each direction.
        private static Color BilinearInterpolate(Color topLeft, Color topRight, Color bottomLeft, Color bottomRight, double xRatio, double yRatio)
        {
            // Perform Bilinear interpolation separately for the alpha component, using weighted averages based on the provided ratios.
            int alpha = (int)(topLeft.A * (1 - xRatio) * (1 - yRatio) +
                              topRight.A * xRatio * (1 - yRatio) +
                              bottomLeft.A * (1 - xRatio) * yRatio +
                              bottomRight.A * xRatio * yRatio);

            // Perform Bilinear interpolation separately for the red component, using weighted averages based on the provided ratios.
            int red = (int)(topLeft.R * (1 - xRatio) * (1 - yRatio) +
                            topRight.R * xRatio * (1 - yRatio) +
                            bottomLeft.R * (1 - xRatio) * yRatio +
                            bottomRight.R * xRatio * yRatio);

            // Perform Bilinear interpolation separately for the green component, using weighted averages based on the provided ratios.
            int green = (int)(topLeft.G * (1 - xRatio) * (1 - yRatio) +
                              topRight.G * xRatio * (1 - yRatio) +
                              bottomLeft.G * (1 - xRatio) * yRatio +
                              bottomRight.G * xRatio * yRatio);

            // Perform Bilinear interpolation separately for the blue component, using weighted averages based on the provided ratios.
            int blue = (int)(topLeft.B * (1 - xRatio) * (1 - yRatio) +
                             topRight.B * xRatio * (1 - yRatio) +
                             bottomLeft.B * (1 - xRatio) * yRatio +
                             bottomRight.B * xRatio * yRatio);

            // Return the interpolated color.
            return Color.FromArgb(alpha, red, green, blue);
        }
    }
}
