using UnityEngine;
public class LevelInit : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject emptyPrefab;
    [SerializeField] private GameObject wallPrefab;
    void Start()
    {
        int[,] randMap1 = {
            {0, 0, 0, 0, 0},
            {0, 1, 1, 1, 0},
            {0, 1, 0, 1, 0},
            {0, 1, 1, 1, 0},
            {0, 0, 0, 0, 0}
        };
        int[,] randMap2 = {
            {0, 1, 1, 1, 0},
            {0, 1, 0, 1, 0},
            {0, 1, 0, 1, 0},
            {0, 1, 0, 1, 0},
            {0, 1, 1, 1, 0}
        };
        int[,] randMap3 = {
            {1, 1, 1, 1, 0},
            {1, 0, 0, 1, 0},
            {1, 0, 0, 1, 0},
            {1, 0, 0, 1, 0},
            {1, 1, 1, 1, 0}
        };

        int[,] randMap4 = {
            {1, 1, 1, 1, 1},
            {1, 0, 0, 0, 1},
            {1, 0, 1, 0, 1},
            {1, 0, 0, 0, 1},
            {1, 1, 1, 1, 1}
        };


        System.Random rnd = new System.Random();
        int mapa = rnd.Next(1, 4);
        Debug.Log(mapa);

        MapGenerator mp = new MapGenerator(); //zavolám instanci tøídy MapGenerator a pøedám random matici pro mapu
        mp.GenerateMap(randMap1, emptyPrefab, wallPrefab);
        switch (mapa)
        {
            case 1:
                mp.GenerateMap(randMap1, emptyPrefab, wallPrefab);
                break;
            case 2:
                mp.GenerateMap(randMap2, emptyPrefab, wallPrefab);
                break;
            case 3:
                mp.GenerateMap(randMap3, emptyPrefab, wallPrefab);
                break;
            case 4:
                mp.GenerateMap(randMap4, emptyPrefab, wallPrefab);
                break;

        }
        Debug.Log("Volám generátor...");
    }


    // Update is called once per frame
}
