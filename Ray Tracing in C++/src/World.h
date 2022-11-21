#pragma once

#include "Vec3.h"
#include "Hittable_List.h"
#include "shaders/Sphere.h"

class World{
	
public:
	Hittable_List world;
	
	World(){
		world.Add(make_shared<Sphere>(Point3(0,0,-1),0.5));
		
		
		world.Add(make_shared<Sphere>(Point3(0,-100,-0.9),100));
	};

	
	
};
