# pragma once
# include "Vec3.h"

class Ray{
public:
	Point3 orig;
	Vec3 dir;
	
	Ray(){}
	
	Ray(const Point3& origin, const Vec3& direction):orig(origin),dir(direction){}
	
	Point3 origin() const{
		return orig;
	}
	
	Vec3 direction()const{
		return dir;		
	}
	
	Point3 at(const double& term) const{
		return orig + term*dir;
	}
	
	
};