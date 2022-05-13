namespace Ray_Tracing;

public  class Sphere
{
    public Vector center,origin;
    public double radius;
    
    public Sphere(Vector center, double radius, Vector? origin = null)
    {
        this.center = center;
        this.radius = radius;
        this.origin = origin ?? new Vector(0, 0, 0);
    }
    
    public bool Hit(Ray r, double t_min, double t_max, ref hitrecord rec)
    //if rec is not passed by reference, new instance is created and thus rec's vlaue is not reflected properly to the function that calls it.
    {//t_min and t_max are the min and max value that t can have when solved
        
        Vector oc = r.org - center;
        double a = r.dir.LengthSquared();
        double half_b = VectorTools.Dot(oc, r.dir);
        double c = oc.LengthSquared() - radius*radius;

        double discriminant = half_b*half_b - a*c;
        if (discriminant < 0) return false;
        double sqrtd = Math.Sqrt(discriminant);

        // Find the nearest root that lies in the acceptable range.
        double root = (-half_b - sqrtd) / a;
        if (root < t_min || t_max < root) {
            root = (-half_b + sqrtd) / a;
            if (root < t_min || t_max < root)
                return false;
        }

        rec.t = root;
        rec.point = r.at(rec.t);
        //rec.normal = (rec.point - center) / radius; TODO: is this part needed?
        Vector outward_normal = (rec.point - center) / radius;
        rec.set_face_normal(ref r, ref outward_normal);

        return true;
     
    }
}