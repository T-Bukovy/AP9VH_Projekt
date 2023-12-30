using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    float spacing = 1f;
    public void GenerateMap(int[,] map,GameObject emptySpacePrefab, GameObject wallPrefab)
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                Vector3 position = new Vector3(i * spacing, j * spacing,0);

                if (map[i, j] == 0)
                {
                    Instantiate(emptySpacePrefab, position, Quaternion.identity);
                }
                else if (map[i, j] == 1)
                {
                    Instantiate(wallPrefab, position, Quaternion.identity);
                }
            }
        }
        Debug.Log("Mapa done...");
    }


}
