# Tesseract

![Tesseract loading a pyramid shape](http://i.imgur.com/0BS7TqX.png)

A vertex-based multidimensional model viewer

![2D](https://img.shields.io/badge/2D%20Models-Implemented-green.svg)
![3D](https://img.shields.io/badge/3D%20Models-Implemented-green.svg)
![4D](https://img.shields.io/badge/4D%20Models-Unimplemented-red.svg)

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

Right now, the mesh algorithm sucks. I am using a distance formula, but distance isn't necesarily the best way to calculate which sides create faces.

### How to contribute
Fork the project, or, even better, commit to the master project! I am always looking for help.
