using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MapGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    //float spacing = 1f;
    private int spacingX = 1;
    private int spacingY = 1;

    public void GenerateMap(int[,] map, GameObject emptySpacePrefab, GameObject wallPrefab,GameObject player,GameObject konec)
    {
        int numRows = map.GetLength(0);
        int numCols = map.GetLength(1);
        Debug.Log($"Pocet radku {numRows}");
        Debug.Log($"Pocet sloupecku {numCols}");
        GameObject prefabToInstantiate;

        for (int row = numRows - 1; row >= 0; row--)
        {
            for (int col = 0; col < numCols; col++)
            {
                int matrixValue = map[row, col];

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
                    continue;
                }
                else if (matrixValue == 3) //hodnota pro pøedmìty na sbírání 
                {
                    //TODO: nìjaký random generator, který urèí, jestli na tom bodì nìco bude a nebo ne 
                    //      emh... nìjaký asset pro pøedmìty
                    continue;
                }
                else if (matrixValue == 4) //Konec 
                {

                    Vector3 endPoint = new Vector3(col * spacingX, row * spacingY, 0);
                    Instantiate(konec, endPoint, Quaternion.identity);
                    continue;
                }
                else if (matrixValue == 6) //levy dolni roh 
                {
                    continue;
                }
                else if (matrixValue == 7) //levy horni roh 
                {
                    continue;
                }
                else if (matrixValue == 8) //pravy dolni roh 
                {
                    continue;
                }
                else if (matrixValue == 9) //pravy horni roh 
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
