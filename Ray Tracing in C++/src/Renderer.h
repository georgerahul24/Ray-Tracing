#pragma once

#include "FileWriter.h"
#include "World.h"
#include "Camera.h"


class Renderer{
public:
	const double aspect_ratio=16.0/9.0;
	int image_height,image_width;
	FileWriter file_writer;	
	World world;
	int samples_per_pixel = 30;
	
	
	
	Renderer(const int& image_height);
	void start();
	
};