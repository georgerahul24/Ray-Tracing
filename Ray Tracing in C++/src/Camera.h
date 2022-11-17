#pragma once 
#include "Vec3.h"
#include "Ray.h"
#include "shaders/Sky.h"
class Camera{
public:
	const int viewport_height=2.0;
	int viewport_width,image_height,image_width;
	
	const int focal_length=1.0;
	const Point3 origin = Point3(0,0,0);
	Vec3 horizontal,vertical,lower_left_corner;
	
	Camera(const int& aspect_ratio,const int& image_width,const int& image_height){
		viewport_width=aspect_ratio*viewport_height;
		horizontal=Vec3(viewport_width,0,0);
		vertical=Vec3(0,viewport_height,0);
		Camera::image_width=image_width;
		Camera::image_height=image_height;
		lower_left_corner=origin-horizontal/2-vertical/2-Vec3(0,0,focal_length);
	}
	
	Color colorise(const int& i,const int& j){
		const double u=double(i)/(image_width-1);
		const double v=double(j)/(image_height-1);
		Ray r(origin, lower_left_corner + u*horizontal + v*vertical - origin);
		Color ray_color=sky.ray_color(r);
		return ray_color;
	}
private:
	Sky sky;	
	
	
	
	
	
	
		
};