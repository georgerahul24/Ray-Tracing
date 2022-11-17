#pragma once

#include "FileWriter.h"
#include "Ray.h"
#include "Vec3.h"
#include "Camera.h"


class Renderer{
public:
	const double aspect_ratio=16.0/9.0;
	int image_height,image_width;
	FileWriter file_writer;	
	
	
	
	Renderer(const int& image_height);
	void start();
	
};