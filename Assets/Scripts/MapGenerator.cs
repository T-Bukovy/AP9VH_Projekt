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
        //for (int i = 0; i < map.GetLength(0); i++)
        //{
        //    for (int j = 0; j < map.GetLength(1); j++)
        //    {
        //        Vector3 position = new(i * spacing,0, j * spacing);

        //        if (map[i, j] == 0)
        //        {
        //            Instantiate(emptySpacePrefab, position, Quaternion.identity);
        //        }
        //        else if (map[i, j] == 1)
        //        {
        //            Instantiate(wallPrefab, position, Quaternion.identity);
        //        }

        //    }
        //}
        int numRows = map.GetLength(0);
        int numCols = map.GetLength(1);
        Debug.Log($"Pocet radku {numRows}");
        Debug.Log($"Pocet sloupecku {numCols}");
        GameObject prefabToInstantiate;

        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numCols; col++)
            {
                int matrixValue = map[row, col];

                // Instantiate the corresponding prefab based on the matrix value
                if (matrixValue == 0)
                {
                    prefabToInstantiate = emptySpacePrefab;
                }
                else if (matrixValue == 1)
                {
                    prefabToInstantiate = wallPrefab;
                }
                else if (matrixValue == 2) //dvojka bude pocatecni pozice hr��e 
                {
                    Transform transform = player.transform;
                    transform.position = new Vector3(col * spacingX, row * spacingY, 0);
                    continue;
                }
                else if (matrixValue == 3) //hodnota pro p�edm�ty na sb�r�n� 
                {
                    //TODO: n�jak� random generator, kter� ur��, jestli na tom bod� n�co bude a nebo ne 
                    //      emh... n�jak� asset pro p�edm�ty
                    continue; 
                }
                else if (matrixValue == 4) //Konec 
                {
                   
                    Vector3 endPoint = new Vector3(col * spacingX, row * spacingY, 0);
                    Instantiate(konec, endPoint, Quaternion.identity);
                    continue;
                }
                else
                {
                    // Handle other matrix values or leave it as null if there's no corresponding prefab
                    continue;
                }

                // Adjust the x and y positions to create a grid-like structure
                float xPosition = col * spacingX; // Use col for horizontal position
                float yPosition = row * spacingY; // Use row for vertical position
                Vector3 position = new Vector3(xPosition, yPosition, 0);

                // Instantiate the prefab at the specified position
                Instantiate(prefabToInstantiate, position, Quaternion.identity);
            }
        }



        Debug.Log("Mapa done...");
    }


}
