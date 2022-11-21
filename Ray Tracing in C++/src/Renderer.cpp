#include "Renderer.h"


Renderer::Renderer(const int& image_height):file_writer("image.ppm"),world(){
	Renderer::image_height=image_height;
	Renderer::image_width=static_cast<int>(image_height*aspect_ratio);
	
}

void Renderer::start(){
file_writer.file<< "P3\n" << image_width << " " << image_height << "\n255\n";	
Camera camera(image_width,image_height,aspect_ratio,world);
for (int j = image_height-1; j >= 0; --j)
 {
	std::cerr << "\rScanlines remaining: " << j << ' ' << std::flush;
	for (int i = 0; i < image_width; ++i) 
	{
		Color pixel_color = Color(0,0,0);
		for (int s=0;s<samples_per_pixel;++s){
			pixel_color += camera.colorise(i,j);
		}
		
		

		file_writer.WriteColor(pixel_color,samples_per_pixel);


	}
}
}  