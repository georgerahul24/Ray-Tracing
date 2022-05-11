using Ray_Tracing;

namespace DefaultNamespace;

public static class Sphere
{
    public static bool Hit(Vector center, double radius, Ray r, Vector? origin = null)
    {
        Vector oc = r.org - center;
        var a = VectorOperations.dot(r.dir, r.dir);
        var b = 2.0 * VectorOperations.dot(oc, r.dir);
        var c = VectorOperations.dot(oc, oc) - radius * radius;
        var discriminant = b * b - 4 * a * c;
        return (discriminant > 0);
    }
}