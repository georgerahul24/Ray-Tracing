#pragma once

#include <iostream>
#include <fstream>
class FileWriter{
	public:
		std::ofstream file;
		 
		 FileWriter(std::string filename){
			file.open(filename);
			 
		 }	 
		 void Exit(){
			 file.close();
		 }
		 
		 void WriteLine(std::string str){
			 file<<str<<'\n';
		 }
		 
		 void WriteText(std::string str){
			 file<<str;
		 }
		 
};