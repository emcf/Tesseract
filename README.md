# Tesseract

A vertex-based multidimensional model viewer - http://emcf.github.io/tesseract

![Tesseract loading a pyramid shape](http://emcf.github.io/tesseract_files/3D.png)
 		 
![2D](https://img.shields.io/badge/2D%20Models-Implemented-green.svg)		 ![2D](https://img.shields.io/badge/2D%20Models-Implemented-green.svg)
![4D](https://img.shields.io/badge/4D%20Models-I'm working on it-yellow.svg)		

### How to create models in all dimensions

Simply create a text file with a point cloud in it. Easy right?

Triangle.xyz
```
 1,-1
-1,-1
 0, 3
```

Pyramid.xyz
```
-1,-1, 0
-1, 1, 0
 1, 1, 0
 1,-1, 0
 0, 0, 3
```

Pentachoron.xyz (www.tiny.cc/5cell)
```
 1, 1, 1, 0
 1,-1,-1, 0
-1, 1,-1, 0
-1,-1, 1, 0
 0, 0, 0, 3
```

### Mesh Algorithm

This is the algorithm (which still needs some efficiency fixes) that detects which verticies to draw lines to. The algorithm takes the number of dimensions you are working with and draws lines from one vertex to that amount of its closest verticies.

### How to contribute
Fork the project, or, even better, commit to the master project! I am always looking for help.
