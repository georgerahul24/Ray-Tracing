using System.Net.Http.Headers;

namespace Ray_Tracing;


public class Cube
{
    public Vector center,origin;
    private double length;
    private Vector side;
    
    public Cube(Vector center, double length, Vector? origin = null)
    {
        this.center = center;
        this.length= length;
        this.origin = origin ?? new Vector(0, 0, 0);
        
    }
    
    public bool Hit(Ray r, double t_min, double t_max, ref hitrecord rec)
        //if rec is not passed by reference, new instance is created and thus rec's vlaue is not reflected properly to the function that calls it.
    {//t_min and t_max are the min and max value that t can have when solved

      
        { 
            double tmin = (r.org.X) / r.dir.X; 
            double tmax = (r.org.X) / r.dir.X;

            if (tmin > tmax)
            {
                (tmin, tmax) = (tmax, tmin);
            } 
 
            double tymin = (r.org.Y) / r.dir.Y; 
            double tymax = (r.org.Y) / r.dir.Y;

            if (tymin > tymax)
            {
                (tymin, tymax) = (tymax, tymin);
            } 
 
            if ((tmin > tymax) || (tymin > tmax)) 
                return false; 
 
            if (tymin > tmin) 
                tmin = tymin; 
 
            if (tymax < tmax) 
                tmax = tymax; 
 
            double tzmin = (r.org.Z) / r.dir.Z; 
            double tzmax = (r.org.Z) / r.dir.Z;

            if (tzmin > tzmax)
            {
                (tzmin, tzmax) = (tzmax, tzmin);
            } 
 
            if ((tmin > tzmax) || (tzmin > tmax)) 
                return false;

            
            
            return true; 
        }
      
    }
}