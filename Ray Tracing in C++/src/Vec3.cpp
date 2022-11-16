#include "Vec3.h"
Vec3::Vec3():e{0,0,0}{}


Vec3::Vec3(double e0, double e1, double e2) : e{e0, e1, e2} {}
double Vec3::x(){return e[0];}
double Vec3::y(){return e[1];}
double Vec3::z(){return e[2];}

Vec3 Vec3::operator -(){
	
	return Vec3(-e[0],-e[1],-e[2]);
}

double Vec3::operator [] (int i){
	return e[i];
}



Vec3& Vec3::operator +=(const Vec3 &v){
	e[0]+=v.e[0];
	e[1]+=v.e[1];
	e[2]+=v.e[2];
	return *this;
}


Vec3& Vec3::operator *=(const double term){
	e[0]*=term;
	e[1]*=term;
	e[2]*=term;
	return *this;
}

Vec3& Vec3::operator /=(const double term){
	return ( *this *= (1/term) );
}


double Vec3::length(){
	return std::sqrt(length_squared());
}

double Vec3::length_squared(){
	return e[0]*e[0] + e[1]*e[1] + e[2]*e[2];
}



// Type aliases for vec3
using point3 = Vec3;   // 3D point
using color = Vec3;    // RGB colorcl




