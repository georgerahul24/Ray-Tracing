#pragma once 
#include "Ray.h"


struct hit_record{
	Point3 p;
	Vec3 normal;
	double t;
	bool front_face; //to check if the normal is out/inside the object
	
	inline void set_face_normal(const Ray& r,Vec3& outward_normal){
		front_face=dot(r.direction(),outward_normal)>0;
		normal= front_face? outward_normal: - outward_normal; //to make sure that always the normal point outwards
	}
	
	
	
};











class Hittable{
public:
	virtual bool Hit(const Ray&r,double t_min,double t_max,hit_record& rec) const=0;
};