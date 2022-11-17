
#include "src/Renderer.h"



int main(){
  int image_height=480;
 
 
 if (__cplusplus!=201703)
  {std::cout<< "C++ Version used is not C++17 and thus might cause some errors due to the same"<<std::endl;}
  
  Renderer renderer(image_height);
 
  renderer.start();
 

}