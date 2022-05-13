namespace Ray_Tracing;
public class Camera {
    
    
        public const double aspect_ratio = 1.778;
        public const double viewport_height = 2.0;
        public const double viewport_width = aspect_ratio * viewport_height;
        public  const double focal_length = 1.0;

        public static Vector origin = new(0, 0, 0);
        public static Vector horizontal = new(viewport_width, 0.0, 0.0);
        public static Vector vertical= new(0.0, viewport_height, 0.0);
        public  static  Vector lower_left_corner = origin - horizontal/2 - vertical/2 - new Vector(0, 0, focal_length);
    

    public Ray GetRay(ref double u, ref double v)  {
        return new Ray(origin, lower_left_corner + u*horizontal + v*vertical - origin);
    }

};