﻿using System.Diagnostics.CodeAnalysis;

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
    private string _filename;
    public double ColorDepth;
    public int ImageHeight;
    public int ImageWidth;

    public Renderer(string filename, int imageHeight = 256, int imageWidth = 256, double colorDepth = 255.99)
    {
        _filename = filename;
        ColorDepth = colorDepth;
        ImageHeight = imageHeight;
        ImageWidth = imageWidth;

        StreamWriter w = File.AppendText(filename);
        _w = w;
        w.WriteLine($"P3\n{imageWidth} {imageHeight}\n{(int)colorDepth}");
    }

    public void WriteColor(double r, double g, double b)
    {
        _w.WriteLine($"{(int)(r * ColorDepth)} {(int)(g * ColorDepth)} {(int)(b * ColorDepth)}");
    }

    private double Clamp(double x, double min = 0.00, double max = 0.999) {
        if (x < min) return min;
        if (x > max) return max;
        return x;
    }

    public void WriteColor(Vector a, double SamplesPerPixel)
    {
        //Color/SamplesPerPixel gives the average colour for anti-aliasing
        _w.WriteLine($"{(int)(Clamp(a.X/SamplesPerPixel) * ColorDepth)} {(int)(Clamp(a.Y/SamplesPerPixel) * ColorDepth)} {(int)(Clamp(a.Z/SamplesPerPixel) * ColorDepth)}");
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
public class RandomTools{
    public readonly Random Random = new Random();
public double RandomNumber(double minimum, double maximum)
{
    
    return Random.NextDouble() * (maximum - minimum) + minimum;
}
}