OUTPUTNAME=RayTracing
IMAGENAME=image.ppm

output:	main.o
	g++ main.o -o $(OUTPUTNAME);

main.o:	main.cpp FileWriter.h Renderer.h
	g++ -c main.cpp

target:	dependencies
	action

clean:
	rm *.o RayTracing $(IMAGENAME);

run:
	make && ./$(OUTPUTNAME)