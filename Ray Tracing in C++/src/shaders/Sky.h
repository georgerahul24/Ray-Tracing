#pragma once 

#include "../Ray.h"
#include "../Vec3.h"

class Sky{
public:
	Color Hit(const Ray& r) const{
		Vec3 unit_direction = unit_vector(r.direction());
		double t = 0.5*(unit_direction.y()+1.0);
		return (1.0-t)*Color(1.0,1.0,1.0) + t*Color(0.5,0.7,1.0);
	}
	
};