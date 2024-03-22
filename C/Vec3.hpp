#ifndef VEC3_H
#define VEC3_H

#include <cmath>
#include <cstdlib>
#define X 0
#define Y 1
#define Z 2

typedef struct {
    double e[3];
} Vec3;

Vec3 *Vec3i() {
    Vec3 *vec = (Vec3 *) malloc(sizeof(Vec3));
    vec->e[X] = 0;
    vec->e[Y] = 0;
    vec->e[Z] = 0;
    return vec;
}

Vec3 *Vec3i(double x, double y, double z) {
    Vec3 *vec = (Vec3 *) malloc(sizeof(Vec3));
    vec->e[X] = x;
    vec->e[Y] = y;
    vec->e[Z] = z;
    return vec;
}

Vec3 * negative(Vec3 *vec){
    Vec3 *vec1 = (Vec3 *) malloc(sizeof(Vec3));
    vec1->e[X] = vec->e[X];
    vec1->e[Y] = vec->e[Y];
    vec1->e[Z] = vec->e[Z];
    return vec1;
}

#endif