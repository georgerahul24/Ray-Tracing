#include "Camera.h"

#include "shaders/Sky.h"
#include "shaders/Sphere.h"

Camera::Camera(const int& image_width,const int& image_height,const double& aspect_ratio){
	Camera::image_width=image_width;
	Camera::image_height=image_height;
	Camera::aspect_ratio=aspect_ratio;
	viewport_width = aspect_ratio * viewport_height;
	horizontal= Vec3(viewport_width, 0, 0);
	vertical=Vec3(0, viewport_height, 0);
	lower_left_corner=origin - horizontal/2 - vertical/2 - Vec3(0, 0, focal_length);
}

Color Camera::colorise(const int& i,const int& j){
	double u = double(i) / (image_width-1);
	double v = double(j) / (image_height-1);
	Ray r(origin, lower_left_corner + u*horizontal + v*vertical - origin);
	
	
	if (sphere.Hit(Point3(0,0,-1), 0.5, r)){
		return Color(1,0,1);
	}
	else{
		return sky.Hit(r);
	}

}