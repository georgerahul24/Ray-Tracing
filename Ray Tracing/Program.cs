using Ray_Tracing;

string file = @"image.ppm";
const double aspectRatio = 1.77778;
const int imageHeight = 1080;
const int imageWidth = (int)(imageHeight * aspectRatio);



const double viewPortHeight = 2.00;
const double viewPortWidth = (viewPortHeight * aspectRatio);
Vector horizontal = new(viewPortWidth, 0, 0);
Vector vertical = new(0, viewPortHeight, 0);


File.Delete(file);
Renderer w = new(file, imageHeight, imageWidth, 256.99);
Vector origin = new(0, 0, 0);
double focal_length = 1.0;
Vector focalLengthV = new Vector(0, 0, focal_length);


Vector PixelColor(Ray r)
{
    var unitDirection = r.dir; // Unit vector between -1 and 1
    var t = 0.5 * (unitDirection.Y + 1.0);
    Color baseColor1 = new(1.0, 1.0, 1.0);
    Color baseColor2 = new(0.5, 0.7, 1.0);
    // blendedValue=(1−t)⋅startValueColor+t⋅endValueColor,
    return (1.0 - t) * baseColor1 + t * baseColor2;
}

HittableList list = new();
list.Add(new Sphere(new Vector(0, -0.3, -1), 0.1));
list.Add(new Sphere(new Vector(0, 0.4, -1), 0.5));
list.Add(new Sphere(new Vector(0, 0, -1), 0.2));
Vector PixelColorSphere(Ray r)
{
    
    if (list.Hit(r, -10, 10, new hitrecord()))
    {
        return new(0,1,0);
    }

    var unitDirection = r.dir; // Unit vector between -1 and 1
    var t = 0.5 * (unitDirection.Y + 1.0);
    Color baseColor1 = new(1.0, 1.0, 1.0);
    Color baseColor2 = new(0.5, 0.7, 1.0);
    // blendedValue=(1−t)⋅startValueColor+t⋅endValueColor,
    return (1.0 - t) * baseColor1 + t * baseColor2;
}

var lowerLeftCorner = origin - (horizontal / 2) - (vertical / 2) - focalLengthV;
for (double j = imageHeight - 1; j >= 0; --j)
{
    Console.SetCursorPosition(0, 0);
    Console.WriteLine($"Remaining {j}");

    for (double i = 0; i < imageWidth; ++i)
    {
        var u = i / (imageWidth - 1);
        var v = j / (imageHeight - 1);
        //Console.WriteLine($"{u} {v}");
        Ray r = new(origin, lowerLeftCorner + (u * horizontal) + (v * vertical) - origin);
        Vector fc = PixelColorSphere(r);
        w.WriteColor(fc);
    }
}