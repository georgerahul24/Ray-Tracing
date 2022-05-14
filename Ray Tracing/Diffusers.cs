using System.Text;

namespace Ray_Tracing;

public static class RayColor
{
    
    private static Color baseColor1 = new(1.0, 1.0, 1.0);
    private static Color baseColor2 = new(0.5, 0.7, 1.0);public static Vector Coloured_Normal(Ray r, ref HittableList scene)
    {
        hitrecord rec = new();

        if (scene.Hit(r, 0, 100, ref rec))
        {
            return 0.5 * new Vector(rec.normal.X + 1, rec.normal.Y, rec.normal.Z);
        }

        Vector unitDirection = VectorTools.UnitVector(r.dir); // Unit vector between -1 and 1
        double t = 0.5 * (unitDirection.Y + 1.0);
        Color baseColor1 = new(1.0, 1.0, 1.0);
        Color baseColor2 = new(0.5, 0.7, 1.0);
        // blendedValue=(1−t)⋅startValueColor+t⋅endValueColor,
        return (1.0 - t) * baseColor1 + t * baseColor2;
    }
    
    public static Vector SimpleColourer(Ray r, ref HittableList scene)
    {
        hitrecord rec = new();
        

        if (scene.Hit(r, 0, 100, ref rec))
        {

            return new(0, 1, 0);
        }

        Vector unitDirection = VectorTools.UnitVector(r.dir); // Unit vector between -1 and 1
        double t = 0.5 * (unitDirection.Y + 1.0);

        //return new(1, 1, 1);
        return (1.0 - t) * baseColor1 + t * baseColor2;
    }

    
    public static Vector Diffuser_1(Ray r, int depth, ref HittableList scene)
    {
        hitrecord rec = new();
        if (depth <= 0)
            return new Vector(0, 0, 0);

        if (scene.Hit(r, 0, 100, ref rec))
        {
            Vector target = rec.point + rec.normal + RandomTools.RandomInUnitSphere();
            return 0.5 * Diffuser_1(new Ray(rec.point, target - rec.point), depth - 1, ref scene);
        }

        Vector unitDirection = VectorTools.UnitVector(r.dir); // Unit vector between -1 and 1
        double t = 0.5 * (unitDirection.Y + 1.0);

        //return new(1, 1, 1);
        return (1.0 - t) * baseColor1 + t * baseColor2;
    }
}
