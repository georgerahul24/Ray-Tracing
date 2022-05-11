namespace Ray_Tracing;

public static class Sphere
{
    public static bool Hit(Vector center, double radius, Ray r, Vector? origin = null)
    {
        Vector relativeCenter = r.org - center;
        var a = VectorOperations.Dot(r.dir, r.dir);
        var b = 2.0 * VectorOperations.Dot(relativeCenter, r.dir);
        var c = VectorOperations.Dot(relativeCenter, relativeCenter) - (radius * radius);
        var discriminant = (b * b) - (4 * a * c);
        //Console.WriteLine($"{r.org},{r.dir}");
        //Console.WriteLine($"{a},{b},{c},{discriminant}");
        return (discriminant > 0);
    }
}