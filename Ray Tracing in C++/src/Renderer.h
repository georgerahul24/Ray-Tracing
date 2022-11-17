#pragma once
# include "FileWriter.h"
# include "Ray.h"
#include "Camera.h"
# include "Vec3.h"




class Renderer{

private:
	 int image_width,image_height;
	 const double aspect_ratio=16.0/9.0;
	 FileWriter file_writer;
public:
	Renderer(int image_width);
	void start();
			
};