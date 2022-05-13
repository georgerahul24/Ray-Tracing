using System.Diagnostics.CodeAnalysis;

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
        front_face = VectorTools.Dot(r.dir, outward_normal) < 0;
        //making sure front_face and outward_normal are in the same side
        //TODO:Clarify this part
        normal = front_face ? outward_normal : outward_normal;
    }
}

class HittableList
{
    private List<Sphere> HitList = new();

    public void Add(Sphere o) => HitList.Add(o);
    public void Clear() => HitList.Clear();

    [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH",
        MessageId = "type: Ray_Tracing.Vector")]
    public bool Hit(Ray r, double t_min, double t_max, ref hitrecord rec)
    {
        hitrecord temprec = new();
        bool hit_anything = false;
        double closest_t = t_max;
        foreach (Sphere obj in HitList)
        {
            if (obj.Hit(r, t_min, closest_t, ref temprec))
            {
                hit_anything = true;
                closest_t = temprec.t;
                rec = temprec;
            }
        }

        return hit_anything;
    }
}