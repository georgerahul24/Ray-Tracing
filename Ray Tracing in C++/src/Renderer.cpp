#include "Renderer.h"
Renderer::Renderer(int* image_width):file_writer("image.ppm"){
	
	Renderer::image_width = *image_width;
	Renderer::image_height = static_cast<int>(*image_width/aspect_ratio);
	
	file_writer.file << "P3\n" << Renderer::image_width<<" "<<Renderer::image_height<<"\n256\n"; //Writing the image types
}


void Renderer::start(){
	Camera camera(aspect_ratio,image_width,image_height);
	
	
	for (int j=image_height-1;j>=0;j--){
	  std::cerr << "Progress: " <<j+1<< "/"<<image_height; // Progress Bar Header
	  for (int i=0; i<image_width; i++){
			
		Color pixel_color=camera.colorise(i,j);
		
		file_writer.WriteColor(pixel_color);   
	  	
	  
	  
	  }
	std::cerr<<'\r';

	}
	file_writer.Exit();
}
