using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[,] randMap = {
            {0, 0, 0, 0, 0},
            {0, 1, 1, 1, 0},
            {0, 1, 0, 1, 0},
            {0, 1, 1, 1, 0},
            {0, 0, 0, 0, 0}
        };

        MapGenerator mp = new MapGenerator(); //zavol�m instanci t��dy MapGenerator a p�ed�m random matici pro mapu
        mp.GenerateMap(randMap);
        Debug.Log("Vol�m gener�tor...");
    }


    // Update is called once per frame
}
