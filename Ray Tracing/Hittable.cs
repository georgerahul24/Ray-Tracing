﻿using System.Net.Sockets;
using Microsoft.VisualBasic.CompilerServices;

namespace Ray_Tracing;

public class Hittable

{
    public bool Hit(Ray r, double t_min, double t_max, hitrecord rec)
    {
        return false;
    }
}

public struct hitrecord
{
    public Vector point;
    public Vector normal;
    public double t;
    public bool front_face;

    public void set_face_normal(Ray r, Vector outward_normal)
    {
        // if Ray.normal > 0, ray inside the sphere.
        //if Ray.normal < 0, ray outside the sphere.
        front_face = VectorOperations.Dot(r.dir, outward_normal) < 0;
        //making sure front_face and outward_normal are in the same side
        normal = front_face ? outward_normal : -1 * outward_normal;
    }
}

class HittableList
{
    private List<Sphere> HitList = new();

    public void Add(Sphere o) => HitList.Add(o);
    public void Clear() => HitList.Clear();

    public bool Hit(Ray r, double t_min, double t_max, hitrecord rec)
    {
        
        bool hit_anything = false;
        double closest_t = t_max;
        foreach (Sphere obj in HitList)
        {
            
            if (obj.Hit(r,  t_min,  closest_t,  rec))
            {
                hit_anything = true;
                closest_t = rec.t;
                
            }
            
        }

        return hit_anything;
    }
}