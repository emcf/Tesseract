# Tesseract
![Tesseract loading a pyramid shape](http://i.imgur.com/T0SliZZ.png)

A low-level 3D model viewer with some overly complex projection and transformation formulas.

![2D](https://img.shields.io/badge/2D%20Models-Unimplemented-red.svg)
![3D](https://img.shields.io/badge/3D%20Models-Implemented-green.svg)
![4D](https://img.shields.io/badge/4D%20Models-Unimplemented-red.svg)

# How to create models

To create a model, simply create a .xyz file and write the co-ordinates of each vertex in the file followed by a newline for each new vertex.

Pyramid.xyz
```
-1,-1, 0
-1, 1, 0
 1, 1, 0
 1,-1, 0
 0, 0, 3
```

# Formulas to Understand
If you want to make changes to the formulas or even help out with 4D transformations and projections, you'll have to understand how the code works. Here are the essential functions:

### 3D Distance Formula

![Distance Formula](http://emcf.github.io/projects_files/Distance.png)

### Projection Formula

![Projection Formula](http://emcf.github.io/projects_files/PerspectiveProjection.png)

### And lastly, the more simple slope Formula

![Slope Formula](http://emcf.github.io/projects_files/Slope.png)

Thanks for reading!

# How to contribute
Fork the project, or, even better, commit to the master project!
