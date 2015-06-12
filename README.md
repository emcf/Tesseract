# Tesseract
![Tesseract loading a pyramid shape](http://i.imgur.com/T0SliZZ.png)

A low-level 3D model viewer with some overly complex projection and transformation formulas.

![2D](https://img.shields.io/badge/2D%20Models-Unimplemented-red.svg)
![3D](https://img.shields.io/badge/3D%20Models-Implemented-green.svg)
![4D](https://img.shields.io/badge/4D%20Models-Unimplemented-red.svg)

### How to create models

To create a 2D model, plot the points in a .xy file

Triangle.xy
```
 1,-1
-1,-1
 0, 3
```

To create a 3D model, plot the points in a .xyz file

Pyramid.xyz
```
-1,-1, 0
-1, 1, 0
 1, 1, 0
 1,-1, 0
 0, 0, 3
```

To create a 4D model, plot the points in a .xyzw file

Pentachoron.xyzw (www.tiny.cc/5cell)
```
 1, 1, 1,-0.4
 1,-1,-1,-0.4
-1, 1,-1,-0.4
-1,-1, 1,-0.4
 0, 0, 0, 1.8
```

### Mesh Algorithm

Right now, the mesh algorithm sucks. I am using a distance formula, but distance isn't necesarily the best way to calculate which sides create faces.

### How to contribute
Fork the project, or, even better, commit to the master project! I am always looking for help.
