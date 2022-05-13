using System.Diagnostics.CodeAnalysis;

namespace Ray_Tracing;

public class Vector
{
    private readonly double[] _point;
    public double X, Y, Z;

    public Vector(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
        _point = new[] { x, y, z };
    }

    public static Vector operator +(Vector a, Vector b)
    {
        Vector res = new Vector(a._point[0] + b._point[0], a._point[1] + b._point[1], a._point[2] + b._point[2]);
        return res;
    }

    [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH",
        MessageId = "type: System.Double[]")]
    public static Vector operator -(Vector a, Vector? b)
    {
        Vector res = new Vector(a._point[0] - b._point[0], a._point[1] - b._point[1], a._point[2] - b._point[2]);
        return res;
    }

    public static Vector operator *(Vector a, double t)
    {
        Vector res = new Vector(a._point[0] * t, a._point[1] * t, a._point[2] * t);
        return res;
    }

    public static Vector operator *(double t, Vector a)
    {
        Vector res = new Vector(a._point[0] * t, a._point[1] * t, a._point[2] * t);
        return res;
    }

    public static Vector operator /(Vector a, double t) => (1 / t) * a;

    public static Vector operator *(Vector a, Vector b) //Dot Product
    {
        Vector res = new(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
        return res;
    }

    public double Length() => Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2));
    public double LengthSquared() => (Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2));


    public override string ToString() => $"{X}i + {Y}j + {Z}k";
}

public static class VectorTools
{
    public static Vector UnitVector(Vector a)
    {
        return a / a.Length();
    }

    public static double Dot(Vector a, Vector b)
    {
        return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
    }
}

public class Renderer
{
    private StreamWriter _w;
    private double SamplePerPixels;
    public double ColorDepth;
   

    public Renderer(ref string filename, int imageHeight = 256, int imageWidth = 256, double colorDepth = 255.99,double samplePerPixels=4)
    {
        
        ColorDepth = colorDepth;
        SamplePerPixels = samplePerPixels;
        StreamWriter w = File.AppendText(filename);
        _w = w;
        w.WriteLine($"P3\n{imageWidth} {imageHeight}\n{(int)colorDepth}");
    }



    private double Clamp(double x, double min = 0.00, double max = 0.999)
    {
        if (x < min) return min;
        if (x > max) return max;
        return x;
    }


    
    public void WriteColor(Vector a)
    {
        //Color/SamplesPerPixel gives the average colour for anti-aliasing
        
        double scale = 1 / SamplePerPixels;
        // using gamma-2 correction
        
        double r = Math.Sqrt(scale * a.X);
        double g = Math.Sqrt(scale * a.Y);
        double b = Math.Sqrt(scale * a.Z);
        /*
        double r = (scale * a.X);
        double g = (scale * a.Y);
        double b = (scale * a.Z);
        */
        
        
        _w.WriteLine(
            $"{(int)(Clamp(r) * (int)(ColorDepth+1))} {(int)(Clamp(g) * (int)(ColorDepth+1))} {(int)(Clamp(b) * (int)(ColorDepth+1))}");

    }

    public void Flush()
    {
        
        _w.Flush();
    }
}

public class Ray
//Ray => A +tB where A is orgin, t is a variable and B is the direction of the vector
{
    public Vector org, dir;

    public Ray(Vector org, Vector dir)
    {
        this.org = org;
        this.dir = dir;
    }

    public Vector at(double t)
    {
        return org + dir * t;
    }
}

public class Color : Vector
{
    public Color(double x, double y, double z) : base(x, y, z)
    {
    }
}

public  class RandomTools
{
  
    private static Random _random = new();
    public static Vector RandomInUnitSphere()
    {
        while (true)
        {
            Vector p = new(_random.Next(-1, 1), _random.Next(-1, 1), _random.Next(-1, 1));
            if (p.LengthSquared()>=1)continue;
            return p;


        }
    }
}