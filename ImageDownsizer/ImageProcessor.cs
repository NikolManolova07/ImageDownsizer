using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageDownsizer
{
    public class ImageProcessor
    {
        // Bilinear interpolation.
        // We need to estimate the pixel values at non-integer coordinates (x, y) by considering the weighted average of the nearest four pixels.
        
        /* (x_floor, y_floor)...........(x_ceil, y_floor) */
        /* .............................................. */
        /* .....................(x, y)................... */
        /* .............................................. */
        /* (x_floor, y_ceil).............(x_ceil, y_ceil) */

        public static Color[][] BilinearInterpolationConsequential(Color[][] inputImage, double scale)
        {
            // Calculate the dimensions of the new image.
            int newWidth = (int)(inputImage[0].Length * scale);
            int newHeight = (int)(inputImage.Length * scale);

            // Create a new 2D array to store the interpolated image.
            Color[][] outputImage = new Color[newHeight][];

            // Iterate through each row in the new image.
            for (int row = 0; row < newHeight; row++)
            {
                // Create a new row in the output image.
                outputImage[row] = new Color[newWidth];

                // Iterate through each column in the new image.
                for (int col = 0; col < newWidth; col++)
                {
                    // Calculate the original coordinates in the input image.
                    double x = col / scale;
                    double y = row / scale;

                    // Find the integer coordinates of the surrounding grid points.
                    int xFloor = (int)Math.Floor(x);
                    int yFloor = (int)Math.Floor(y);

                    // Ensure that the coordinates are within the bounds of the input image.
                    int xCeil = Math.Min(xFloor + 1, inputImage[0].Length - 1);
                    int yCeil = Math.Min(yFloor + 1, inputImage.Length - 1);

                    // Calculate the fractional distances from the floor coordinates.
                    double xRatio = x - xFloor;
                    double yRatio = y - yFloor;

                    // Perform Bilinear interpolation to get the color at the current position.
                    Color interpolatedColor = BilinearInterpolate(
                        inputImage[yFloor][xFloor],
                        inputImage[yFloor][xCeil],
                        inputImage[yCeil][xFloor],
                        inputImage[yCeil][xCeil],
                        xRatio,
                        yRatio
                    );

                    // Assign the interpolated color to the corresponding position in the output image.
                    outputImage[row][col] = interpolatedColor;
                }
            }

            // Return the final interpolated image.
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
