using UnityEngine;


[RequireComponent(typeof(GameObject))]
[RequireComponent(typeof(GameObject))]

public class MapGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject emptySpacePrefab;
    public GameObject wallPrefab;

    public void GenerateMap(int[,] map)
    {
        //for (int i = 0; i < map.GetLength(0); i++)
        //{
        //    for (int j = 0; j < map.GetLength(1); j++)
        //    {
        //        Vector3 position = new Vector3(i, 0, j);

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
        Debug.Log("Mapa done...");
    }


}
