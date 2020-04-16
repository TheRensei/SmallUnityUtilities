# SmallUnityUtilities
Scripts for unity that do small stuff that I couldn't find anywhere so I wrote them.

# [GridMaker.cs](https://github.com/TheRensei/SmallUnityUtilities/blob/master/GridMaker.cs)

![](https://raw.githubusercontent.com/TheRensei/SmallUnityUtilities/master/Images/GridMakerGif.gif)

3D Grid maker
- call public CreateGrid() after specifying gridSize and divisionAmount
- it produces cellCenters which can be retrieved by grid.cellCenters

Notes:
- set size on any axis to make the 2D grid
- keep the division amount on 1 to not divide the grid further
