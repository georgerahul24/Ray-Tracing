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

        
        return false;
    }
}