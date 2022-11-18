#pragma once 
#include "Hittable.h"
#include <memory>
#include <vector>

using std::shared_ptr;
using std::make_shared;

class Hittable_List:public Hittable{
public:
	std::vector<shared_ptr<Hittable>> objects;
	Hittable_List(){};
	Hittable_List(shared_ptr<Hittable> object){objects.push_back(object);};
	
	
	void Clear(){objects.clear();}
	void Add(shared_ptr<Hittable> object){objects.push_back(object);}
	
	
	virtual bool Hit(const Ray& r,double t_min,double t_max,hit_record& rec) const override{
		hit_record temp_rec;
		bool hit_anything=false;
		double closest_so_far=t_max;
		
		for (const shared_ptr<Hittable>& object:objects)
		{
			
			if (object->Hit(r,t_min,closest_so_far,temp_rec))
			{
				hit_anything=true;
				closest_so_far=temp_rec.t; // changing the value of t_max to the nearest hit point bascially
				rec=temp_rec;
			}
			
		}
		return hit_anything;
	}
	

};
