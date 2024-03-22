//
// Created by George Rahul on 24/02/24.
//

#ifndef C_IMAGEHANDLER_H
#define C_IMAGEHANDLER_H

#include "stdio.h"


FILE *openWriteFile(char *filename, int image_height, int image_width) {
    FILE *f = fopen(filename, "w");
    fprintf(f, "P3\n");
    fprintf(f, "%d %d\n255\n", image_width, image_height);
    return f;
}

void writeColor(FILE *file, double r, double g, double b) {

    int ir = 255.999 * r;
    int ig = 255.999 * g;
    int ib = 255.999 * b;

    fprintf(file, "%d %d %d\n", ir, ig, ib);
}


#endif //C_IMAGEHANDLER_H
