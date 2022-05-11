using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Ray_Tracing;

public  class Sphere:Hittable
{
    private Vector center,origin;
    private double radius;
    public hitrecord rec;
    public Sphere(Vector center, double radius, Vector? orgin = null)
    {
        this.center = center;
        this.radius = radius;
        this.origin = orgin ?? new Vector(0, 0, 0);
    }
    
    public bool Hit(Ray r, double t_min, double t_max, hitrecord rec)
    {//t_min and t_max are the min and max value that t can have when solved
        this.rec = rec;
        Vector relativeCenter = r.org - center;
        var a = VectorOperations.Dot(r.dir, r.dir);
        var b = 2.0 * VectorOperations.Dot(relativeCenter, r.dir);
        var c = VectorOperations.Dot(relativeCenter, relativeCenter) - (radius * radius);
        var discriminant = (b * b) - (4 * a * c);
        
        

        if (discriminant < 0)
        {
            return false;
        }
        
        var root = (-b - discriminant)/2*a;

        if (root < t_min || t_max < root)
        {
            root = ((-b + discriminant) / 2 * a) / a; //checking the second root
            if (root < t_min || t_max < root)
                return false; //if still root is not in the limits of t, we do not consider the root
        }
/*
        if (discriminant < 0)
        {
            return false;
        }
        */

        rec.t = root;
        rec.point = r.at(rec.t);
        rec.normal = (rec.point - center) / radius;

        return true;    
    }
}