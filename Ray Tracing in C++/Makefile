OUTPUTNAME = bin/RayTracing
IMAGENAME = image.ppm

output:	bin/main.o
	g++ -std=c++17 -Ofast bin/main.o -o $(OUTPUTNAME);

bin/main.o:	main.cpp Renderer.h
	g++ -std=c++17 -c main.cpp -o bin/main.o

target:	dependencies
	action

clean:
	rm bin/*.o bin/RayTracing $(IMAGENAME);

run:
	make && ./$(OUTPUTNAME)