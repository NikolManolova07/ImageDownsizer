using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ImageDownsizer
{
    public class BitmapConverter
    {
        public static Color[][] BitmapToArray(Bitmap bitmap)
        {
            // Retrieve the width and height of the input bitmap.
            int width = bitmap.Width;
            int height = bitmap.Height;

            // Initialize a 2D array to store the Color values.
            // The outer array represents rows, and each inner array represents pixels in a row.
            Color[][] resultArray = new Color[height][];

            // Lock the bits of the bitmap in memory to access its pixel data directly.
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            unsafe
            {
                // Iterate through each row (y) in the bitmap.
                for (int y = 0; y < height; y++)
                {
                    // Create a new inner array for each row.
                    resultArray[y] = new Color[width];

                    // Create a pointer that points to the start of the pixel data for the specified row (y) in the locked memory region.
                    // Stride represents the number of bytes occupied by a single row of pixels in memory.
                    // We use the pointer to access and manipulate the individual bytes representing the pixel values in the row. 
                    byte* row = (byte*)bitmapData.Scan0 + (y * bitmapData.Stride);

                    for (int x = 0; x < width; x++)
                    {
                        int b = row[x * 4];
                        int g = row[x * 4 + 1];
                        int r = row[x * 4 + 2];
                        int a = row[x * 4 + 3];

                        // Retrieve the pixel data for each pixel in the row and store it in the resultArray.
                        resultArray[y][x] = Color.FromArgb(a, r, g, b);
                    }
                }
            }

            // Unlock the bits of the bitmap after accessing its pixel data.
            bitmap.UnlockBits(bitmapData);

            return resultArray;
        }

        public static Bitmap ArrayToBitmap(Color[][] pixelArray)
        {
            // Retrieve the dimensions of the input 2D array.
            int height = pixelArray.Length;
            int width = pixelArray[0].Length;

            // Create a new bitmap with the specified width and height.
            Bitmap resultBitmap = new Bitmap(width, height);

            // Lock the bits of the new bitmap for writing.
            BitmapData bitmapData = resultBitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            unsafe
            {
                // Iterate through each row (y) in the bitmap.
                for (int y = 0; y < height; y++)
                {
                    // Create a pointer that points to the start of the pixel data for the specified row (y) in the locked memory region.
                    // Stride represents the number of bytes occupied by a single row of pixels in memory.
                    // We use the pointer to access and manipulate the individual bytes representing the pixel values in the row. 
                    byte* row = (byte*)bitmapData.Scan0 + (y * bitmapData.Stride);

                    for (int x = 0; x < width; x++)
                    {
                        Color pixelColor = pixelArray[y][x];

                        // Retrieve the pixel data from the input 2D array and write it to the new.
                        row[x * 4] = pixelColor.B;
                        row[x * 4 + 1] = pixelColor.G;
                        row[x * 4 + 2] = pixelColor.R;
                        row[x * 4 + 3] = pixelColor.A;
                    }
                }
            }

            // Unlock the bits of the new bitmap.
            resultBitmap.UnlockBits(bitmapData);

            return resultBitmap;
        }
    }
}
