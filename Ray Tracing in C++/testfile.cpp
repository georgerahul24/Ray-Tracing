#include "src/FileWriter.h"
#include "src/Ray.h"
#include "src/Vec3.h"
#include "src/shaders/Sphere.h"

Color ray_color(Ray& r){
	Sphere sphere;
	if (sphere.Hit(Point3(0,0,-1), 0.5, r)){
		return Color(0,0,0);
	}
	Vec3 unit_direction = unit_vector(r.direction());
   double t = 0.5*(unit_direction.y() + 1.0);
   return (1.0-t)*Color(1.0, 1.0, 1.0) + t*Color(0.5, 0.7, 1.0);
}


int main() {
	FileWriter file_writer("image.ppm");
	

    // Image
    const double aspect_ratio = 16.0 / 9.0;
	const int image_height = 480;
    const int image_width = static_cast<int>(image_height * aspect_ratio);
    
	

    // Camera

    
    
  

    



    // Render

    std::cerr << "\nDone.\n";
}