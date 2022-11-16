#include "../src/Vec3.h"

class test_Vec3{

public:
	int run(){
		int a = 0;
		Vec3 vec1,vec2(10.01,20.04,31.23);
		
		// Testing no param constructor 
		if (vec1.e[0]==0 && vec1.e[1]==0 && vec1.e[2]==0){
			std::cout << "Test 1 Successful" << '\n';
		}
		else{
			std::cout << "Test 1 Failed" << '\n';
			a=1;
		}
		
		//Testing with param constructor
		if (vec2.e[0]==10.01 && vec2.e[1]==20.04 && vec2.e[2]==31.23){
			std::cout << "Test 2 Successful" << '\n';
		}
		else{
			std::cout << "Test 2 Failed" << '\n';
			a=1;
		}
		
		
		//Testing x()
		
		if (vec1.x()==0 and vec2.x()==10.01){
			std::cout << "Test 3 Successful" << '\n';
		}
		
		else{
			std::cout << "Test 3 Failed" << '\n';
			a=1;
		}
		
		//Testing y()
		
		if (vec1.y()==0 and vec2.y()==20.04){
			std::cout << "Test 4 Successful" << '\n';
		}
		
		else{
			std::cout << "Test 4 Failed" << '\n';
			a=1;
		}
		
		//testing z()
		if (vec1.z()==0 and vec2.z()==31.23){
			std::cout << "Test 5 Successful" << '\n';
		}
		
		else{
			std::cout << "Test 5 Failed" << '\n';
			a=1;
		}
		
		Vec3 vec3 = -vec2;
		
		
		if (vec3.e[0]==-10.01 && vec3.e[1]==-20.04 && vec3.e[2]==-31.23){
			std::cout << "Test 6 Successful" << '\n';
		}
		else{
			std::cout << "Test 6 Failed" << '\n';
			a=1;
		}

		if (vec2[0]==10.01 && vec2[1]==20.04&&vec2[2]==31.23){
			std::cout << "Test 7 Successful" << '\n';
		}

		else{
			std::cout << "Test 7 Failed" << '\n';
			a=1;
		}

		vec1+=vec2;

		if (vec1[0]==vec2[0] && vec1[1]==vec2[1] && vec1[2]==vec2[2]){
			std::cout << "Test 8 Successful" << '\n';
		}

		else{
			std::cout << "Test 8 Failed" << '\n';
			a=1;
		}


		vec1*=2;

		if (vec1[0]==vec2[0]*2 && vec1[1]==vec2[1]*2 && vec1[2]==vec2[2]*2){
			std::cout << "Test 9 Successful" << '\n';
		}

		else{
			std::cout << "Test 9 Failed" << '\n';
			a=1;
		}

		vec1/=2;

		if (vec1[0]==vec2[0] && vec1[1]==vec2[1] && vec1[2]==vec2[2]){
			std::cout << "Test 10 Successful" << '\n';

			
		}

		else{
			std::cout << "Test 10 Failed" << '\n';


			a=1;
		}


		vec3=Vec3(1,2,2);

		if (vec3.length()==3){
			std::cout << "Test 11 Successful" << '\n';

		}

		else{
			std::cout << "Test 11 Failed" << '\n';
			a=1;
		}

		if (vec3.length_squared()==9){
			std::cout << "Test 12 Successful" << '\n';

		}

		else{
			std::cout << "Test 12 Failed" << '\n';
			a=1;
		}


		vec1=Vec3(1,1,1);
		vec2=Vec3(1,2,3);

		vec3=vec1+vec2;

		if (vec3[0]==2 && vec3[1]==3 && vec3[2]==4){
			std::cout << "Test 13 Successful" << '\n';
		}

		else{
			std::cout << "Test 13 Failed" << '\n';
			a=1;
		}

		vec3=vec2-vec1;

		if (vec3[0]==0 && vec3[1]==1 && vec3[2]==2){
			std::cout << "Test 14 Successful" << '\n';
		}

		else{
			std::cout << "Test 14 Failed" << '\n';
			a=1;
		}

		vec3=vec1*vec2;

		if (vec3[0]==1 && vec3[1]==2 && vec3[2]==3){
			std::cout << "Test 15 Successful" << '\n';
		}

		else{
			std::cout << "Test 15 Failed" << '\n';
			a=1;
		}

		vec3=vec2*3;

		if (vec3[0]==3 && vec3[1]==6 && vec3[2]==9){
			std::cout << "Test 16 Successful" << '\n';
		}

		else{
			std::cout << "Test 16 Failed" << '\n';
			a=1;
		}


		vec3=3*vec2;

		if (vec3[0]==3 && vec3[1]==6 && vec3[2]==9){
			std::cout << "Test 16 Successful" << '\n';
		}

		else{
			std::cout << "Test 16 Failed" << '\n';
			a=1;
		}

		vec3=Vec3(2,4,6);
		vec3=vec3/2;

		if (vec3[0]==1 && vec3[1]==2 && vec3[2]==3){
			std::cout << "Test 17 Successful" << '\n';
		}

		else{
			std::cout << "Test 17 Failed" << '\n';
			a=1;
		}

		double dot_val=dot(vec1,vec2);

		if (dot_val==6){
			std::cout << "Test 18 Successful" << '\n';
		}

		else{
			std::cout << "Test 18 Failed" << '\n';
			a=1;
		}
		
		return a;
	}
};