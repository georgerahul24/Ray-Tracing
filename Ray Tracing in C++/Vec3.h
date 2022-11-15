#pragma once

#include <cmath>
#include <iostream>
#include "FileWriter.h"

class Vec3{
private:
	double e[3];
	
public:
	Vec3() : e{0,0,0}{}
    Vec3(double e0, double e1, double e2) : e{e0, e1, e2} {}
	double x(){return e[0];}
	double y(){return e[1];}
	double z(){return e[2];}
	
	Vec3 operator -(){
		Vec3(-e[0],-e[1],-e[2]);
		return;
	}
	
	double operator [] (int i){
		return e[i];
	}
	

	
	Vec3& operator +=(const Vec3 &v){
		e[0]+=v.e[0];
		e[1]+=v.e[1];
		e[2]+=v.e[2];
		return *this;
	}
	
	
	Vec3& operator *=(const double term){
		e[0]*=term;
		e[1]*=term;
		e[2]*=term;
		return *this;
	}
	
	Vec3& operator /=(const double term){
		return ( *this *= (1/term) );
	}
	
	
	double length(){
		return std::sqrt(length_squared());
	}
	
	double length_squared(){
		return e[0]*e[0] + e[1]*e[1] + e[2]*e[2];
	}

};



// Type aliases for vec3
using point3 = Vec3;   // 3D point
using color = Vec3;    // RGB colorcl



