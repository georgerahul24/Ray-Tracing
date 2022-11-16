OUTPUTNAME = bin/RayTracing
IMAGENAME = image.ppm

output:	bin/main.o bin/Renderer.o bin/Vec3.o
	g++ -std=c++17 -Ofast bin/Vec3.o bin/main.o bin/Renderer.o -o $(OUTPUTNAME);

bin/main.o:	main.cpp  src/Vec3.h
	g++ -std=c++17 -c main.cpp -o bin/main.o

bin/Renderer.o:	src/Renderer.h src/Renderer.cpp src/FileWriter.h
	g++ -std=c++17 -c src/Renderer.cpp -o bin/Renderer.o



bin/Vec3.o:	src/Vec3.cpp src/FileWriter.h
	g++ -std=c++17 -c src/Vec3.cpp -o bin/Vec3.o


target:	dependencies
	action

clean:
	rm bin/*.o test/*.o  test/test bin/RayTracing $(IMAGENAME);

run:
	make && ./$(OUTPUTNAME)

testclean:
		rm test/*.o test/test

test/main.o: test/main.cpp
	g++ -std=c++17 -c test/main.cpp -o test/main.o

test: test/main.o
	g++ -std=c++17  src/Vec3.cpp test/main.o -o test/test && ./test/test;
		