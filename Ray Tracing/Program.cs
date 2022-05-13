
using System.Diagnostics;
using Ray_Tracing;

//Thread t = new Thread();
string file = @"image.ppm";
const double aspectRatio = 1.778;
const int imageHeight = 1080;
const int imageWidth = (int)(imageHeight * aspectRatio);
const int sampleSize = 1;
const int maxDepth = 1;
File.Delete(file);
Renderer w = new(ref file, imageHeight, imageWidth, 255.99,sampleSize);

HittableList scene = new();
//scene.Add(new Sphere(new Vector(0.8, -0.3, -1), 0.3));
scene.Add(new Sphere(new Vector(0.22, 1, -1), 0.2));
scene.Add(new Sphere(new Vector(-0.33, -0.5, -1), 0.1));
scene.Add(new Sphere(new Vector(0, 0, -1), 0.2));
//scene.Add(new Sphere(new Vector(-.8, 0, -1), 0.3));
scene.Add(new Sphere(new Vector(0, -100.5, -1), 100));



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

            pixelColor += Diffuser_1.RayColor(cam.GetRay(ref u, ref v),maxDepth, ref scene);
            
           //w.WriteColor(RayColor.Coloured_Normal(cam.GetRay(ref u,ref v),ref scene));
        }
        w.WriteColor(pixelColor);
        
    }
}
w.Flush();
sw.Stop();
Console.WriteLine($"Elapsed time: {sw.Elapsed}");