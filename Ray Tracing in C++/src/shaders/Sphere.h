#pragma once 

#include "../Hittable.h"
#include "../Vec3.h"
#include "../Ray.h"

class Sphere{
public:	
	Point3 center;
	double radius;
	Sphere(){};
	Sphere(Point3 cen,double r):center(cen),radius(r){};
	
	
	bool Hit(const Ray& r, double t_min,double t_max, hit_record& rec ) const {
		Vec3 oc = r.origin()-center;
		double a=r.direction().length_squared();
		double half_b=dot(oc,r.direction());
		double c = oc.length_squared() - radius*radius;
		double discriminant = half_b*half_b-a*c;
		
		if (discriminant<0) return false;
		
		double sqrtd = std::sqrt(discriminant);
		
		//Finding the nearest root between the specified values
		double root = (-half_b-sqrtd) - a;
		
		if (root < t_min || root > t_max){
			//this means the first root we checked with '-' sign isnt the one we want
			//So, we are checking the second root  with '+' sign
			root = (-half_b+sqrtd)/a;
			
			if (root < t_min || root > t_max) // Checking if the second root satisfies the criteria {
				return false;
			}
			
			rec.t=root;
			rec.p=r.at(rec.t);
			rec.normal=(rec.p-center)/radius;
			
			return true;
			
		}
		
		
	
};