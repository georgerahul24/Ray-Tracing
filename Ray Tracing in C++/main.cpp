
#include "src/Renderer.h"
#include "src/Vec3.h"


int main(){
  int* image_width= new int;
  int* image_height=new int;
  *image_width=256;
  *image_height=256;
  Vec3 vec;
  std::cout << vec << '\n';

 if (__cplusplus!=201703)
  {std::cout<< "C++ Version used is not C++17 and thus might cause some errors due to the same"<<std::endl;}
  
  Renderer renderer(image_width,image_height);
 
  renderer.start();
  delete image_width;
  delete image_height;
  
  
  
}