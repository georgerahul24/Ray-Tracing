using Ray_Tracing;
/*
string file = @"image.ppm";
const int image_height = 1920, image_width = 1920, color_depth = 1920;
try
{
    File.Delete(file);
}
catch
{
    
}
using StreamWriter w = File.AppendText("image.ppm");
w.Write($"P3\n{image_height} {image_width}\n{color_depth}\n");

for (int j = image_height - 1; j >= 0; j--)
{
    Console.SetCursorPosition(0,0);
    Console.WriteLine($"Remaining {j}");
    for (int i = 0; i < image_width; i++)

    {
      
        int r =(int) (i*color_depth/ (image_width-1)), g = (int)(j*color_depth / (image_height-1)), b=(int)(i+j)/2*color_depth;
        w.Write($"{r} {g} {b}\n");


    }
}
*/
Vector a = new(1,2,3);
Vector b = new(1,2,3);
Vector c = a + b;
c += b;
c = c*4;
Console.Write(c);





