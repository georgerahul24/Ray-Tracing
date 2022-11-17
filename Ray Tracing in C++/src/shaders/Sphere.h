#pragma once 

#include "../Ray.h"
#include "../Vec3.h"


class Sphere{
public:	
	bool Hit(const Point3& center, double radius,const Ray& r){
		Vec3 oc = r.origin()-center;
		auto a = dot(r.direction(),r.direction());
		auto b = 2.0 * dot(oc,r.direction());
		auto c = dot(oc,oc)-radius*radius;
		auto discrimanant = b*b-4*a*c;
		return (discrimanant<0);
		
	}
};