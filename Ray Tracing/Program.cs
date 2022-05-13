
using System.Diagnostics;
using Ray_Tracing;

string file = @"image.ppm";
const double aspectRatio = 1.778;
const int imageHeight = 400;
const int imageWidth = (int)(imageHeight * aspectRatio);
const int sampleSize = 2;
const int maxDepth = 3;
File.Delete(file);
Renderer w = new(file, imageHeight, imageWidth, 256.99);

HittableList scene = new();
scene.Add(new Sphere(new Vector(0.8, -0.3, -1), 0.3));
scene.Add(new Sphere(new Vector(0, 0, -1), 0.1));
scene.Add(new Sphere(new Vector(-.8, 0, -1), 0.3));
scene.Add(new Sphere(new Vector(0, -100.5, -1), 100));


Vector RayColor(Ray r,int depth)
{
    hitrecord rec = new();
    if (depth <= 0)
        return new Vector(0,0,0);

    if (scene.Hit(r, 0.001, 100, ref rec)) {
        Vector target = rec.point + rec.normal + RandomTools.RandomInUnitSphere();
        return 0.5 * RayColor(new Ray(rec.point, target - rec.point), depth-1);
    }
    var unitDirection = VectorTools.UnitVector(r.dir); // Unit vector between -1 and 1
    var t = 0.5 * (unitDirection.Y + 1.0);
    Color baseColor1 = new(1.0, 1.0, 1.0);
    Color baseColor2 = new(0.5, 0.7, 1.0);
    // blendedValue=(1−t)⋅startValueColor+t⋅endValueColor,
    return (1.0 - t) * baseColor1 + t * baseColor2;
}

Random random = new Random();
Camera cam = new Camera();
Stopwatch sw = new Stopwatch();
sw.Start();
for (double j = imageHeight - 1; j >= 0; --j)
{
    Console.SetCursorPosition(0, 0);
    Console.WriteLine($"Remaining {j*100/imageHeight}....%");

    for (double i = 0; i < imageWidth; ++i)
    {
        Vector pixelColor = new(0, 0, 0);
        for (int s = 0; s < sampleSize; s++)
        {
            double u = (i+random.NextDouble())/ (imageWidth - 1);
            double v = (j+random.NextDouble()) / (imageHeight - 1);

            pixelColor += RayColor(cam.GetRay(u, v),maxDepth);
        }

        w.WriteColor(pixelColor, sampleSize);
    }
}
sw.Stop();
Console.WriteLine($"Elapsed time: {sw.Elapsed}");