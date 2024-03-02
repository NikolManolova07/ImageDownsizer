# ImageDownsizer
**1. Task:**<br>

Create a **WinForms** application which downsizes images. The app must let users select an image using the standard open file dialog, enter a downscaling factor (real number), and produce a new downscaled image. The downscaling factor is a percentage of the original size. The image aspect ratio must be preserved. Implement a downscaling algorithm in two ways: consequential and parallel, measure the performance with different image sizes and report the results.

**2. Solution:**<br>

**Bilinear interpolation** is a method for estimating values at non-grid points within a grid of known values. In the context of image processing, it is often used to interpolate pixel values for resizing or transforming images.
Suppose you have a grid of values with four known corners:<br>
<img src="https://github.com/NikolManolova07/ImageDownsizer/assets/83454633/9869ab62-6e4d-4848-8d0a-62c52d50e0b3" width="20%"><br>
You want to estimate the value at a point *P* inside this grid. The interpolation is done separately for each component (e.g., red, green, blue, alpha for colors in an image). Let’s use *x* and *y* as the interpolation ratios for the horizontal and vertical directions, respectively. The formula for bilinear interpolation is as follows:<br>
<img src="https://github.com/NikolManolova07/ImageDownsizer/assets/83454633/827ea045-880e-4745-a717-6fe65a1a3043" width="80%"><br>
This formula represents a weighted average of the values at the four corners of the grid, where *x* and *y* are the interpolation ratios indicating the fractional distances between the point *P* and the nearest grid points. In the provided C# code, the bilinear interpolation is performed separately for each color component (alpha, red, green, blue), and the formula is applied to calculate the interpolated value for each component. The weighted averages are calculated based on the provided interpolation ratios (xRatio and yRatio) for the horizontal and vertical directions. A figure to illustrate the bilinear interpolation is provided below:<br>

<img src="https://github.com/NikolManolova07/ImageDownsizer/assets/83454633/ae464f2b-a1b8-4738-81c3-d35d1798030a" width="30%"><br>

**3. Test Results:**<br>

The original largish image to experiment with has size as follows: 25 000 x 15 000 px. As the downscaling factor is a percentage of the original size, then we get the following size for width and height of the image regarding the downscaling factor:
- 25% - 6250 x 3750 px
- 50% - 12 500 x 7500 px
- 75% - 18 750 x 11 250 px<br>

The image downsizing is done with Consequential, Parallel Threads and Parallel Loop approaches with measured time for execution, presented in the table below for each downscaling factor:<br>

<img src="https://github.com/NikolManolova07/ImageDownsizer/assets/83454633/d60e98ac-055c-4384-811b-14191c408aa8" width="70%"><br>

Test screenshots of the application with the measured execution time for each approach are provided in the *Test* folder of the project.

**4. Resources:**<br>

Bilinear Interpolation:<br>
- https://www.codeproject.com/Articles/5312360/2-D-Interpolation-Functions
- https://www.scratchapixel.com/lessons/mathematics-physics-for-computer-graphics/interpolation/bilinear-filtering.html
- https://meghal-darji.medium.com/implementing-bilinear-interpolation-for-image-resizing-357cbb2c2722
- https://en.wikipedia.org/wiki/Bilinear_interpolation

Parallel Loop:<br>
- https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.parallel.for?view=net-8.0
- https://medium.com/@luisalexandre.rodrigues/c-parallel-programming-working-with-parallel-loops-part-i-6fedc922642b

Image Processing:<br>
- https://www.cambridgeincolour.com/tutorials/image-resize-for-web.htm
- https://medium.com/@oleg.shipitko/what-does-stride-mean-in-image-processing-bba158a72bcd
