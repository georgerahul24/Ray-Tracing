#pragma once 

#include "shaders/Sky.h"
#include "shaders/Sphere.h"

class Camera{
public:
	int image_width,image_height,aspect_ratio;
	const double viewport_height = 2.0;
	double viewport_width;
	const double focal_length = 1.0;
	const Point3 origin{0, 0, 0};
	Vec3 horizontal,vertical,lower_left_corner;
	Sphere sphere;
	Sky sky;
	
	
	
	Camera(const int& image_width,const int& image_height,const double& aspect_ratio);
	Color colorise(const int& i,const int& j);
};