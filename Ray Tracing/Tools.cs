namespace Ray_Tracing;

public class Vector
{
    private int[] Point;
    private int _x, _y, _z;
    public Vector(int x,int y,int z)
    {
        _x = x;
        _y = y;
        _z = z;
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

    public static Vector operator *(Vector a,int t)
    {
        Vector res = new Vector(a.Point[0]*t, a.Point[1] *t, a.Point[2]*t);
        return res;
    }
 
    
   
    

    public override string ToString()
    {
        return $"{_x}i + {_y}j + {_z}k";
    }
    
}