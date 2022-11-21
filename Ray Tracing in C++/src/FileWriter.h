#pragma once
#include "Vec3.h"
#include <fstream>



class FileWriter{
private:
	const double colormult=255.999;
	
	
	public:
		std::ofstream file;
		 
		 FileWriter(std::string filename){
			 //TODO: Find y cant we use std::string& ?
			file.open(filename);
			
			 
		 }	 
		 void Exit(){
			 file.close();
		 }
		 
		 void WriteLine(std::string& str){
			 file<<str<<'\n';
		 }
		 
		 void WriteText(std::string& str){
			 file<<str;
		 }
		 
		 void WriteColor(Vec3& color,int& samples_per_pixel){
			 
			 color = color/samples_per_pixel;
			 
			 
			 file<<static_cast<int>(colormult*color[0]) << " " << static_cast<int>(colormult*color[1]) << " " << static_cast<int>(colormult*color[2]) << "\n"; 
		 }
		 
};