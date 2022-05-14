using System.Diagnostics;
using Ray_Tracing;



string file = @"image.ppm";
const double aspectRatio = 1.778;
Console.Write("Enter Resolution: ");
int imageHeight = Convert.ToInt32(Console.ReadLine());
int imageWidth = (int)(imageHeight * aspectRatio);
Console.Write("Enter Sample Size: ");
double sampleSize = Convert.ToDouble(Console.ReadLine());
Console.Write("Enter Max Depth For the Rays: ");
int maxDepth = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter the number of Cores to be used: ");
int numberOfCores = Convert.ToInt32(Console.ReadLine());
List<Thread> process = new();
File.Delete(file);
Renderer w = new(ref file, imageHeight, imageWidth, 255.99,sampleSize,numberOfCores);
HittableList scene = new();

scene.Add(new Sphere(new Vector(0, 0, -1), 0.25));
scene.Add(new Sphere(new Vector(0, -0.4, -1), 0.1));
scene.Add(new Sphere(new Vector(0, 0.4, -1), 0.1));
scene.Add(new Sphere(new Vector(-0.4, 0, -1), 0.1));
scene.Add(new Sphere(new Vector(0.4, 0, -1), 0.1));
/*
scene.Add(new Sphere(new Vector(0, -100.5, -1), 100));
*/


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

                //ScreenRenderer.Paint(u,v,RayColor.Coloured_Normal(cam.GetRay(ref u,ref v),ref scene));
                //w.WriteColor(RayColor.Coloured_Normal(cam.GetRay(ref u,ref v),ref scene));
                
            }

            w.WriteColor(pixelColor,(int)processno);
            
            


        }
       
    }
    Console.WriteLine($"Process Completed: {processno}");
    
}


for (int p=0;p < numberOfCores;p++)

{
    
    Thread t = new Thread((Main1));
    t.Start();
    process.Add(t);
  
}



foreach (Thread t in process)
{
    t.Join();
}
w.Flush();
sw.Stop();
Console.WriteLine($"Elapsed time: {sw.Elapsed}");