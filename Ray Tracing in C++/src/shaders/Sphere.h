#pragma once 

#include "../Ray.h"
#include "../Vec3.h"


class Sphere{
public:	
	double Hit(const Point3& center, double radius,const Ray& r){
		Vec3 oc = r.origin()-center;
		auto a=r.direction().length_squared();
		auto half_b=dot(oc,r.direction());
		auto c = oc.length_squared() - radius*radius;
		auto discriminant = half_b*half_b-a*c;
		return discriminant<0?-1.0:(-half_b-std::sqrt(discriminant)/a);
		
	}
};