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

}