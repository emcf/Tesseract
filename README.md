# Tesseract

View and rotate the row vectors of a matrix
 		 
### How to create models in all dimensions

Simply create a text file containing a matrix of row vectors.

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

Pentachoron.xyz
```
 1, 1, 1, 0
 1,-1,-1, 0
-1, 1,-1, 0
-1,-1, 1, 0
 0, 0, 0, 3
```

### Mesh Algorithm

The algorithm simply draws lines from point i to nearest point j.
