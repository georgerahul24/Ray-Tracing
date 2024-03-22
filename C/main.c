#include "ImageHandler.hpp"
#include "stdio.h"

int main() {
    int image_width = 1000;
    int image_height = 1000;

    FILE *fw = openWriteFile("image.ppm", image_height, image_width);

    for (int j = 0; j < image_height; ++j) {
        for (int i = 0; i < image_width; ++i) {
            double r = (double) (i) / (image_width - 1);
            double g = (double) (j) / (image_height - 1);
            double b = 0;

            writeColor(fw, r, g, b);


        }
    }


    return 0;
}
