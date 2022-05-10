using Ray_Tracing;

string file = @"image.ppm";
const int image_height = 256, image_width = 256;
File.Delete(file);
Renderer w = new(file,image_height,image_height,255.99);


for (int j = image_height - 1; j >= 0; j--)
{
    Console.SetCursorPosition(0,0);
    Console.WriteLine($"Remaining {j}");
    for (int i = 0; i < image_width; i++)

    {
        w.WriteColor((double)i/ (image_height - 1),(double)j/ (image_width - 1), 0.25);


    }
}

Vector a = new(1,2,3);
Vector ab = new(1,2,3);
Vector c = a + ab;
c += ab;
c *= 4;
c = c/4;

Console.Write(c);
Console.WriteLine(c.Length());





