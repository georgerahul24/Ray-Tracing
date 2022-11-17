
#include "src/Renderer.h"



int main(){
  int image_width=400;
 
 
 if (__cplusplus!=201703)
  {std::cout<< "C++ Version used is not C++17 and thus might cause some errors due to the same"<<std::endl;}
  
  Renderer renderer(image_width);
 
  renderer.start();
 

}