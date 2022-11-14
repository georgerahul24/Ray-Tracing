#pragma once
#include "FileWriter.h"
class Renderer{

private:
	 int image_width,image_height;
	 double colormult;
	 FileWriter file_writer;
public:
	Renderer(int image_width,int image_height):file_writer("image.ppm"){
		Renderer::image_width=image_width;
		Renderer::image_height=image_height;
		colormult=255.99;
		file_writer.file << "P3\n" << image_width<<" "<<image_height<<"\n256\n"; //Writing the image types
	}
	
	void start(){
			for (int j=image_height-1;j>=0;--j){
		      std::cerr << "Progress: " <<j+1<< "/"<<image_height; // Progress Bar Header
		      for (int i=image_width-1;i>=0;--i){
		        double r=double(i)/(image_width-1);
		        double g=double(j)/(image_height-1);
		        double b=0.25;
		        file_writer.file<< static_cast<int>(colormult*r) << " " << static_cast<int>(colormult*g) << " " << static_cast<int>(colormult*b) << "\n";    
		      }
		    std::cerr<<'\r';

			}
			file_writer.Exit();
		}
};