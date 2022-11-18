OUTPUTNAME = bin/RayTracing
IMAGENAME = image.ppm

output:	bin/main.o bin/Renderer.o bin/Vec3.o bin/Camera.o
	g++ -std=c++17 -Ofast bin/Vec3.o bin/Camera.o bin/main.o bin/Renderer.o -o $(OUTPUTNAME);

bin/main.o: main.cpp
	g++ -std=c++17 -c main.cpp -o bin/main.o

bin/Renderer.o:	src/Renderer.h src/Renderer.cpp src/FileWriter.h
	g++ -std=c++17 -c src/Renderer.cpp -o bin/Renderer.o

bin/Camera.o:	src/Camera.h src/Camera.cpp src/shaders/*.h src/Hittable.h
	g++ -std=c++17 -c src/Camera.cpp -o bin/Camera.o

bin/Vec3.o: src/Vec3.cpp
	g++ -std=c++17 -c src/Vec3.cpp -o bin/Vec3.o


target:	dependencies
	action

clean:
	rm bin/*.o test/*.o  test/test_main bin/RayTracing $(IMAGENAME);

run:
	make && ./$(OUTPUTNAME) && open ./$(IMAGENAME)

testclean:
		rm test/*.o test/test

test/test_main.o: test/test_main.cpp test/test_Vec3.h
	g++ -std=c++17 -c test/test_main.cpp -o test/test_main.o

test: test/test_main.o
	g++ -std=c++17  src/Vec3.cpp test/test_main.o -o test/test_main && ./test/test_main;
		