#include "../src/Vec3.h"
#include <iostream>

int main(){
	int a = 0;
	Vec3 vec1,vec2(10.01,20.04,31.23);
	
	// Testing no param constructor 
	if (vec1.e[0]==0 && vec1.e[1]==0 && vec1.e[2]==0){
		std::cout << "Test 1 Sucessfull" << '\n';
	}
	else{
		std::cout << "Test 1 Failed" << '\n';
		a=1;
	}
	
	//Testing with param constructor
	if (vec2.e[0]==10.01 && vec2.e[1]==20.04 && vec2.e[2]==31.23){
		std::cout << "Test 2 Sucessfull" << '\n';
	}
	else{
		std::cout << "Test 2 Failed" << '\n';
		a=1;
	}
	
	
	//Testing x()
	
	if (vec1.x()==0 and vec2.x()==10.01){
		std::cout << "Test 3 Sucessfull" << '\n';
	}
	
	else{
		std::cout << "Test 3 Failed" << '\n';
		a=1;
	}
	
	//Testing y()
	
	if (vec1.y()==0 and vec2.y()==20.04){
		std::cout << "Test 4 Sucessfull" << '\n';
	}
	
	else{
		std::cout << "Test 4 Failed" << '\n';
		a=1;
	}
	
	//testing z()
	if (vec1.z()==0 and vec2.z()==31.23){
		std::cout << "Test 5 Sucessfull" << '\n';
	}
	
	else{
		std::cout << "Test 5 Failed" << '\n';
		a=1;
	}
	
	
	
	
	
	
	
	
	return a;
}