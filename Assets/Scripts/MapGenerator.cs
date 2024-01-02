using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class MapGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    //float spacing = 1f;
    private float spacingX = 1.28F; //prostì na pevno ... god knows jak velký to vlastnì je v pomìru na units v Unity 
    private float spacingY = 1.28F;

    public void GenerateMap(int[,] map, GameObject emptySpacePrefab, GameObject wallPrefab,GameObject player,GameObject konec)
    {
        int numRows = map.GetLength(0);
        int numCols = map.GetLength(1);
        Debug.Log($"Pocet radku {numRows}");
        Debug.Log($"Pocet sloupecku {numCols}");
            
        for (int row = numRows - 1; row >= 0; row--)
        //for (int row = 0; row < numRows; row++)
        {
            //for (int col = numCols - 1; col >= 0; col--)
            for (int col = 0; col < numCols; col++)
            {
                int matrixValue = map[row, col];
                Console.Write(map[row, col] + " ");
                // Instantiate the corresponding prefab based on the matrix value
                if (matrixValue == 0)
                {
                    // Adjust the x and y positions to create a grid-like structure
                    float xPosition = col * spacingX; // Use col for horizontal position
                    float yPosition = row * spacingY; // Use row for vertical position
                    Vector3 position = new Vector3(xPosition, yPosition, 0);

                    // Instantiate the prefab at the specified position
                    Instantiate(emptySpacePrefab, position, Quaternion.identity);
                    
                }
                else if (matrixValue == 1)
                {
                    // Adjust the x and y positions to create a grid-like structure
                    float xPosition = col * spacingX; // Use col for horizontal position
                    float yPosition = row * spacingY; // Use row for vertical position
                    Vector3 position = new Vector3(xPosition, yPosition, 0);

                    // Instantiate the prefab at the specified position
                    Instantiate(wallPrefab, position, Quaternion.identity);
                }
                else if (matrixValue == 2) //dvojka bude pocatecni pozice hráèe 
                {
                    Transform transform = player.transform;
                    transform.position = new Vector3(col * spacingX, row * spacingY, 0);
                    //continue;
                }
                else if (matrixValue == 3) //hodnota pro pøedmìty na sbírání 
                {
                    //TODO: nìjaký random generator, který urèí, jestli na tom bodì nìco bude a nebo ne 
                    //      emh... nìjaký asset pro pøedmìty
                    continue;
                }
                else if (matrixValue == 4) //Konec 
                {
                    float xPosition = col * spacingX; // Use col for horizontal position
                    float yPosition = row * spacingY; // Use row for vertical position
                    Vector3 position = new Vector3(xPosition, yPosition, 0);

                    // Instantiate the prefab at the specified position
                    Instantiate(konec, position, Quaternion.identity);

                }
                else if (matrixValue == 11) 
                {
                    continue;
                }
                else if (matrixValue == 12)  
                {
                    continue;
                }
                else if (matrixValue == 13) 
                {
                    continue;
                }
                else if (matrixValue == 14)
                {
                    continue;
                }
                else
                {
                    // Handle other matrix values or leave it as null if there's no corresponding prefab
                    continue;
                }
            }
        }



        Debug.Log("Mapa done...");
        
    }


}
