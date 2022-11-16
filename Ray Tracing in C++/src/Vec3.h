#pragma once

#include <cmath>
#include <iostream>
#include "FileWriter.h"

class Vec3{

	
	
public:
	double e[3];
	Vec3();
    Vec3(double e0, double e1, double e2);
	double x();
	double y();
	double z();
	
	Vec3 operator -();
	
	double operator [] (int i);

	
	Vec3& operator +=(const Vec3 &v);
	
	Vec3& operator *=(const double term);
	
	Vec3& operator /=(const double term);
	
	double length();
	
	double length_squared();

};

//Vec3 Utilities
inline std::ostream& operator<<(std::ostream &out, const Vec3 &v){
	return out<<"X: "<<v.e[0]<<" Y: "<<v.e[1] << " Z: " <<v.e[2]<<'\n';
}


inline Vec3 operator+(const Vec3 &u, const Vec3&v){
	return Vec3(u.e[0]+v.e[0], u.e[1]+v.e[1], u.e[2]+v.e[2]);
}

inline Vec3 operator-(const Vec3 &u, const Vec3&v){
	return Vec3(u.e[0]-v.e[0], u.e[1]-v.e[1], u.e[2]-v.e[2]);

}

inline Vec3 operator*(const Vec3 &u, const Vec3&v){
	return Vec3(u.e[0]*v.e[0], u.e[1]*v.e[1], u.e[2]*v.e[2]);

}

inline Vec3 operator*(const Vec3 &u, const double term){
	return Vec3(u.e[0]*term, u.e[1]*term, u.e[2]*term);

}

inline Vec3 operator*(const double term,const Vec3 &u ){
	return Vec3(u.e[0]*term, u.e[1]*term, u.e[2]*term);

}

inline Vec3 operator/(const Vec3 &u, const double term){
	return Vec3(u.e[0]/term, u.e[1]/term, u.e[2]/term);

}


inline double dot(const Vec3& u,const Vec3& v){
	return (u.e[0]*v.e[0]) + (u.e[1]*v.e[1]) + (u.e[2]*v.e[2]);
}

inline Vec3 unit_vector(Vec3& v ){
	return v/v.length();
}














