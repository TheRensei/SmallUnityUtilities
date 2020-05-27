# SmallUnityUtilities
Scripts for unity that do stuff.

# [GridMaker.cs](GridMaker.cs)

![](https://raw.githubusercontent.com/TheRensei/SmallUnityUtilities/master/Images/GridMakerGif.gif)

3D Grid maker
- call public CreateGrid() after specifying gridSize and divisionAmount
- it produces cellCenters which can be retrieved by grid.cellCenters

Notes:
- set size on any axis to make the 2D grid
- keep the division amount on 1 to not divide the grid further

# [State Machine](StateMachine)

 Modified version based on:
 - https://dev.to/jushii/state-machine-controller-for-unity-4fno
 - https://noahbannister.blog/2017/12/19/building-a-modular-character-controller/
