# Tesseract
![Tesseract loading a pyramid shape](http://i.imgur.com/T0SliZZ.png)

A low-level 3D model viewer with some overly complex projection and transformation formulas.

![2D](https://img.shields.io/badge/2D%20Models-Unimplemented-red.svg)
![3D](https://img.shields.io/badge/3D%20Models-Implemented-green.svg)
![4D](https://img.shields.io/badge/4D%20Models-Unimplemented-red.svg)

### How to create models

To create a model, create a .xyz file and write out each point followed by a new line.

Pyramid.xyz
```
-1,-1, 0
-1, 1, 0
 1, 1, 0
 1,-1, 0
 0, 0, 3
```

Easiest modeller ever, right?

### Projection Formula

This formula helps convert XYZ points to XY points. It uses rotation to draw a perspective view.

![Projection Formula](http://emcf.github.io/projects_files/PerspectiveProjection.png)

### How to contribute
Fork the project, or, even better, commit to the master project! I am always looking for help.
