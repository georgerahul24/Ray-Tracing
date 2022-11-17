#pragma once

#include "FileWriter.h"
#include "Ray.h"
#include "Vec3.h"


class Renderer{
public:
	const double aspect_ratio=16.0/9.0;
	int image_height,image_width;
	FileWriter file_writer;	
	Sphere sphere;
	
	
	Renderer(const int& image_height):file_writer("image.ppm"){
		Renderer::image_height=image_height;
		Renderer::image_width=static_cast<int>(image_height*aspect_ratio);
	}
	
	
	void start(){
	file_writer.file<< "P3\n" << image_width << " " << image_height << "\n255\n";	
	auto viewport_height = 2.0;
    auto viewport_width = aspect_ratio * viewport_height;
    auto focal_length = 1.0;

    auto origin = Point3(0, 0, 0);
    auto horizontal = Vec3(viewport_width, 0, 0);
    auto vertical = Vec3(0, viewport_height, 0);
    auto lower_left_corner = origin - horizontal/2 - vertical/2 - Vec3(0, 0, focal_length);
	
	for (int j = image_height-1; j >= 0; --j)
	 {
        std::cerr << "\rScanlines remaining: " << j << ' ' << std::flush;
        for (int i = 0; i < image_width; ++i) 
		{
            auto u = double(i) / (image_width-1);
            auto v = double(j) / (image_height-1);
            Ray r(origin, lower_left_corner + u*horizontal + v*vertical - origin);
            Color pixel_color;
			
			if (sphere.Hit(Point3(0,0,-1), 0.5, r)){
				pixel_color=Color(1,0,0);
			}
			else{
				pixel_color=Color(0,1,0);
			}
			
			
			
            file_writer.WriteColor(pixel_color);

	
	    }
   }
}  
	
};