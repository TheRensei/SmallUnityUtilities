using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[ExecuteInEditMode]
public class GridMaker : MonoBehaviour
{
    public Vector3 gridSize = Vector3.one;
    //public int divisionAmount = 1;
    public Vector3 divisionAmount = Vector3.one;
    [ReadOnly]
    public int cellCount;
    [ReadOnly]
    public Vector3 cellSize = Vector3.zero;
    [Space]
    [HideInInspector] public Vector3[] cellCenters;

    [Space]
    public bool showCellCenters = false;
    public bool showGrid = false;

    private void OnValidate()
    {
        CreateGrid();
    }

    public void CreateGrid()
    {
        Vector3 divisions = new Vector3(
            Mathf.CeilToInt(divisionAmount.x),
            Mathf.CeilToInt(divisionAmount.y),
            Mathf.CeilToInt(divisionAmount.z)
            );

        cellCount = Mathf.CeilToInt(divisions.x * divisions.y * divisions.z);
        cellCenters = new Vector3[cellCount];

        cellSize.x = gridSize.x / (divisions.x);
        cellSize.y = gridSize.y / (divisions.y);
        cellSize.z = gridSize.z / (divisions.z);

        float xOffset = transform.position.x - (gridSize.x / 2);
        float yOffset = transform.position.y - (gridSize.y / 2);
        float zOffset = transform.position.z - (gridSize.z / 2);



        int index = 0;
        for (int x = 0; x < divisions.x; x++)
        {
            for (int y = 0; y < divisions.y; y++)
            {
                for (int z = 0; z < divisions.z; z++, index++)
                {
                    cellCenters[index] = new Vector3(
                        x * cellSize.x + xOffset,
                        y * cellSize.y + yOffset, 
                        z * cellSize.z + zOffset);

                    cellCenters[index].x += cellSize.x / 2;
                    cellCenters[index].y += cellSize.y / 2;
                    cellCenters[index].z += cellSize.z / 2;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (showCellCenters)
        {
            for (int i = 0; i < cellCenters.Length; i++)
            {
                Vector3 pos = cellCenters[i];
                Gizmos.DrawSphere(pos, 1f);
            }
        }

        if (showGrid)
        {
            for (int i = 0; i < cellCenters.Length; i++)
            {
                Vector3 p = cellCenters[i];
                Gizmos.color = Color.blue;
                Gizmos.DrawWireCube(p, cellSize);
            }
        }
    }

}
