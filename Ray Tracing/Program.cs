
using System.Diagnostics;
using Ray_Tracing;


string file = @"image.ppm";
const double aspectRatio = 1.778;
const int imageHeight = 1080;
const int imageWidth = (int)(imageHeight * aspectRatio);
const double sampleSize = 10;
const int maxDepth = 4;
const int numberOfCores = 4;
List<Thread> process = new();
File.Delete(file);
Renderer w = new(ref file, imageHeight, imageWidth, 255.99,sampleSize,numberOfCores);
HittableList scene = new();
scene.Add(new Sphere(new Vector(0, 0, -1), 0.3));

scene.Add(new Sphere(new Vector(0, -100.5, -1), 100));



Random random = new Random();
Camera cam = new Camera();
Stopwatch sw = new Stopwatch();
sw.Start();
int procno = 0;
void Main1()
{
    int processno = procno;
    procno++;
    for (double j = (processno + 1) * ((double)imageHeight / numberOfCores); j>=(processno)* ((double)imageHeight / numberOfCores); --j)
    {   // Console.SetCursorPosition(0, processno);
        //Console.WriteLine($"Remaining {j * 100 / imageHeight/numberOfCores}....%");
      
        for (double i = 0; i < imageWidth; ++i)
        {
            Vector pixelColor = new(0, 0, 0);
            for (int s = 0; s < sampleSize; s++)
            {
                double u = (i + random.NextDouble()) / (imageWidth - 1);
                double v = (j + random.NextDouble()) / (imageHeight - 1);

                pixelColor += RayColor.Diffuser_1(cam.GetRay(ref u, ref v), maxDepth, ref scene);

                //w.WriteColor(RayColor.Coloured_Normal(cam.GetRay(ref u,ref v),ref scene));
            }

            w.WriteColor(pixelColor,(int)processno);

        }
        
    }
    Console.WriteLine($"Process Completed: {processno}");
    
}


int processno = 0;
while (processno < numberOfCores)

{
    
    Thread t = new Thread((Main1));
    t.Start();
    process.Add(t);
    processno++;
}



foreach (Thread t in process)
{
    t.Join();
}
w.Flush();
sw.Stop();
Console.WriteLine($"Elapsed time: {sw.Elapsed}");