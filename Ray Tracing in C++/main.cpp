#include <iostream>

int main(){
  const int image_width=256;
  const int image_height=256;
  const double colormult=255.99;
  
  
  std::cout << "P3\n" << image_width<<" "<<image_height<<"\n256\n"; //Writing the image types
  
  for (int j=image_height-1;j>=0;--j){
    std::cerr << "Progress: " <<j+1<< "/"<<image_height; // Progress Bar Header
    for (int i=image_width-1;i>=0;--i){
      

      double r=double(i)/(image_width-1);
      double g=double(j)/(image_height-1);
      double b=0.25;
      std::cout<< static_cast<int>(colormult*r) << " " << static_cast<int>(colormult*g) << " " << static_cast<int>(colormult*b) << "\n";
        
  }
  std::cerr<<'\r';

}
  
  
}