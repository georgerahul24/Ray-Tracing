using Ray_Tracing;

string file = @"image.ppm";
const double aspect_ratio = 1.77778;
const int image_height = 1080;
const int image_width = (int)(image_height * aspect_ratio);



const double view_port_height = 2.00;
const double view_port_width = (view_port_height * aspect_ratio);
Vector horizontal = new(view_port_width, 0, 0);
Vector vertical = new(0, view_port_height, 0);


File.Delete(file);
Renderer w = new(file, image_height, image_width, 255.99);
Vector origin = new(0, 0, 0);
double focal_length = 1.0;
Vector focalLengthV = new Vector(0, 0, focal_length);


Vector pixel_color(Ray r)
{
    var unit_direction = r.dir; // Unit vector between -1 and 1
    var t = 0.5 * (unit_direction.Y + 1.0);
    Color baseColor1 = new(1.0, 1.0, 1.0);
    Color baseColor2 = new(0.5, 0.7, 1.0);
    // blendedValue=(1−t)⋅startValueColor+t⋅endValueColor,
    return (1.0 - t) * baseColor1 + t * baseColor2;
}

Vector spherecen = new Vector(0, 0, 1);

Vector sphere_color = new Vector(1, 0, 0);


Vector pixel_color_sphere(Ray r)
{
    if (Sphere.Hit(spherecen, 0.5, r))
    {
        return sphere_color;
    }

    var unit_direction = r.dir; // Unit vector between -1 and 1
    var t = 0.5 * (unit_direction.Y + 1.0);
    Color baseColor1 = new(1.0, 1.0, 1.0);
    Color baseColor2 = new(0.5, 0.7, 1.0);
    // blendedValue=(1−t)⋅startValueColor+t⋅endValueColor,
    return (1.0 - t) * baseColor1 + t * baseColor2;
}

var lowerLeftCorner = origin - (horizontal / 2) - (vertical / 2) - focalLengthV;
Console.WriteLine(lowerLeftCorner);
for (double j = image_height - 1; j >= 0; --j)

{
    //Console.SetCursorPosition(0, 0);
    //Console.WriteLine($"Remaining {j}");

    for (double i = 0; i < image_width; ++i)
    {
        var u = i / (image_width - 1);
        var v = j / (image_height - 1);
        //Console.WriteLine($"{u} {v}");
        Ray r = new(origin, lowerLeftCorner + (u * horizontal) + (v * vertical) - origin);
        Vector fc = pixel_color_sphere(r);
        w.WriteColor(fc);
    }
}