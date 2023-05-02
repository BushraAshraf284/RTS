using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMover : MonoBehaviour
{
    /// <summary>
    /// recieve data and give result, not going to work with the game world
    /// Calculates a unit formation around a given destination
    /// </summary>
    /// <param name="moveToPos"> Position to move to </param>
    /// <param name="numUnits"> total number of units selected </param>
    /// <param name="unitGap"> distance between each unit in the formation </param>
    /// <returns></returns>
    public static Vector3[] GetUnitGroupDestintion(Vector3 moveToPos, int numUnits, float unitGap)
    {
        // vector3 array for final destinations 

        Vector3[] destinations = new Vector3[numUnits];
        int rows = Mathf.RoundToInt(Mathf.Sqrt(numUnits));
        int cols = Mathf.CeilToInt((float)numUnits/ (float) rows);
        
        //we need to know the current row and column we're calculating
        int curRow = 0; int curCol = 0;

        // to get the center of the formation
        float width = ((float)rows -1) * unitGap;
        float length = ((float)cols - 1) * unitGap;

       

        for (int i = 0; i< numUnits; i++)
        {
            destinations[i] = moveToPos + (new Vector3(curRow, 0, curCol) * unitGap) - new Vector3(length / 2, 0, width / 2);
            curCol++;

            if(curCol == rows)
            {
                curCol = 0;
                curRow++;
            }
        }
        return destinations;
    }
}
