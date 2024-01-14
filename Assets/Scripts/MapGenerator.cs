using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class MapGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    //float spacing = 1f;
    private float spacingX = 1.28F; //prostì na pevno ... god knows jak velký to vlastnì je v pomìru na units v Unity 
    private float spacingY = 1.28F;

    public static Vector3 PlayerStart;
    
    public void GenerateMap(int[,] map, GameObject emptySpacePrefab, GameObject wallPrefab,GameObject player,GameObject konec,GameObject bodik, GameObject rasa, GameObject rasaLong,
                    GameObject Textury_Kraj_1, GameObject Textury_Kraj_2, GameObject Textury_Kraj_3, GameObject Textury_Kraj_4,
                    GameObject Textury_vnejsiRoh_1, GameObject Textury_vnejsiRoh_2, GameObject Textury_vnejsiRoh_3, GameObject Textury_vnejsiRoh_4,
                    GameObject Textury_vnitrniRoh_1, GameObject Textury_vnitrniRoh_2, GameObject Textury_vnitrniRoh_3, GameObject Textury_vnitrniRoh_4)
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
                float xPosition = col * spacingX; // Use col for horizontal position
                float yPosition = (numRows - row - 1) * spacingY; ; // Use row for vertical position

                // Instantiate the corresponding prefab based on the matrix value
                if (matrixValue == 0)
                {
                    Vector3 position = new Vector3(xPosition, yPosition, 0);
                    Instantiate(emptySpacePrefab, position, Quaternion.identity);
                    
                }
                else if (matrixValue == 1)
                {
                    Vector3 position = new Vector3(xPosition, yPosition, 0);
                    Instantiate(wallPrefab, position, Quaternion.identity);
                }
                else if (matrixValue == 2) //dvojka bude pocatecni pozice hráèe 
                {
                    PlayerStart = new Vector3(col * spacingX, (numRows - row - 1) * spacingY, 0);
                    player.transform.position = new Vector3(col * spacingX, (numRows - row - 1) * spacingY, 0);
                    //continue;
                }
                else if (matrixValue == 3) //hodnota pro pøedmìty na sbírání 
                {
                    Vector3 position = new Vector3(xPosition, yPosition-0.48F, 0);
                    Instantiate(bodik, position, Quaternion.identity);
                }
                else if (matrixValue == 4) //Konec 
                {
                    Vector3 position = new Vector3(xPosition, yPosition, 0);
                    Instantiate(konec, position, Quaternion.identity);

                }
                else if (matrixValue == 5) //Rasa 
                {
                    Vector3 position = new Vector3(xPosition, 0.58F, 0);
                    Instantiate(rasa, position, Quaternion.identity);

                }
                else if (matrixValue == 6) //RasaLong
                {
                    Vector3 position = new Vector3(xPosition, 0.58F, 0);
                    Instantiate(rasaLong, position, Quaternion.identity);

                }


                else if (matrixValue == 11) 
                {
                    Vector3 position = new Vector3(xPosition, yPosition, 0);
                    Instantiate(Textury_Kraj_1, position, Quaternion.identity);
                }
                else if (matrixValue == 12)  
                {
                    Vector3 position = new Vector3(xPosition, yPosition, 0);
                    Instantiate(Textury_Kraj_2, position, Quaternion.identity);
                }
                else if (matrixValue == 13) 
                {
                    Vector3 position = new Vector3(xPosition, yPosition, 0);
                    Instantiate(Textury_Kraj_3, position, Quaternion.identity);
                }
                else if (matrixValue == 14)
                {
                    Vector3 position = new Vector3(xPosition, yPosition, 0);
                    Instantiate(Textury_Kraj_4, position, Quaternion.identity);
                }
                else if (matrixValue == 21)
                {
                    Vector3 position = new Vector3(xPosition, yPosition, 0);
                    Instantiate(Textury_vnejsiRoh_1, position, Quaternion.identity);
                }
                else if (matrixValue == 22)
                {
                    Vector3 position = new Vector3(xPosition, yPosition, 0);
                    Instantiate(Textury_vnejsiRoh_2, position, Quaternion.identity);
                }
                else if (matrixValue == 23)
                {
                    Vector3 position = new Vector3(xPosition, yPosition, 0);
                    Instantiate(Textury_vnejsiRoh_3, position, Quaternion.identity);
                }
                else if (matrixValue == 24)
                {
                    Vector3 position = new Vector3(xPosition, yPosition, 0);
                    Instantiate(Textury_vnejsiRoh_4, position, Quaternion.identity);
                }
                else if (matrixValue == 31)
                {
                    Vector3 position = new Vector3(xPosition, yPosition, 0);
                    Instantiate(Textury_vnitrniRoh_1, position, Quaternion.identity);
                }
                else if (matrixValue == 32)
                {
                    Vector3 position = new Vector3(xPosition, yPosition, 0);
                    Instantiate(Textury_vnitrniRoh_2, position, Quaternion.identity);
                }
                else if (matrixValue == 33)
                {
                    Vector3 position = new Vector3(xPosition, yPosition, 0);
                    Instantiate(Textury_vnitrniRoh_3, position, Quaternion.identity);
                }
                else if (matrixValue == 34)
                {
                    Vector3 position = new Vector3(xPosition, yPosition, 0);
                    Instantiate(Textury_vnitrniRoh_4, position, Quaternion.identity);
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
