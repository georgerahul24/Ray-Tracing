#pragma once
#include "FileWriter.h"

class Renderer{

private:
	 int image_width,image_height;
	 double colormult;
	 FileWriter file_writer;
public:
	Renderer(int* image_width,int* image_height);
	void start();
			
};