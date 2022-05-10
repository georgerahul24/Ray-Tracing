namespace Ray_Tracing;

public class Vector
{
    private double[] Point;
    public double X, Y, Z;
    public Vector(double x,double y,double z)
    {
        X = x;
        Y = y;
        Z = z;
        Point = new[]{x,y,z};
        
    }

    public static Vector  operator + (Vector a, Vector b)
    {
        Vector res = new Vector(a.Point[0] + b.Point[0], a.Point[1] + b.Point[1], a.Point[2] + b.Point[2]);
        return res;
    }

    public static Vector operator -(Vector a, Vector b)
    {
        Vector res = new Vector(a.Point[0] - b.Point[0], a.Point[1] - b.Point[1], a.Point[2] - b.Point[2]);
        return res;
    }

    public static Vector operator *(Vector a,double t)
    {
        Vector res = new Vector(a.Point[0]*t, a.Point[1] *t, a.Point[2]*t);
        return res;
    }
    public static Vector operator /(Vector a,double t)
    {
        Vector res = new(a.X/t,a.Y/t,a.Z/t);
        return res;
    }

    public double Length()
    {
        return Math.Sqrt(Math.Pow(X,2)+Math.Pow(Y,2)+Math.Pow(Z,2));
    }

    
    public override string ToString()
    {
        return $"{X}i + {Y}j + {Z}k";
    }
    
}

public class Renderer
{
    private StreamWriter _w;
    private string _filename;
    public double ColorDepth;
    public int ImageHeight;
    public int ImageWidth;
    public Renderer(string filename,int image_height = 256,int image_width = 256,double color_depth = 255.99)
    {
        _filename = filename;
        ColorDepth = color_depth;
        ImageHeight = image_height;
        ImageWidth = image_width;

        StreamWriter w = File.AppendText(filename);
        _w = w;
        w.WriteLine($"P3\n{image_height} {image_width}\n{(int)color_depth}");
    }

    public void Delete()
    {
        try
        {
            File.Delete(_filename);
        }
        catch
        {
            // ignored
        }
    }

    public void Write(string s)
    {
        _w.WriteLine(s);
    }
    public void WriteColor(double r,double g, double b)
    {
        _w.WriteLine($"{(int)(r * ColorDepth)} {(int)(g*ColorDepth)} {(int)(b * ColorDepth)}");
    }
}

public class Ray
//Ray => A +tB where A is orgin, t is a variable and B is the direction of the vector
{
    private Vector org, dir;
    public Ray(Vector org, Vector dir)
    {
        this.org = org;
        this.dir = dir;
    }

    public Vector at(double t)
    {
        return org +  dir*t;
    }
}
