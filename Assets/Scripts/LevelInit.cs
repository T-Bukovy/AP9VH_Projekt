using UnityEngine;
public class LevelInit : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject emptyPrefab;
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Konec;
    void Start()
    {
        int[,] randMap4 = {
            {1, 1, 1, 1, 1, 1, 1, 1},
            {1, 4, 0, 0, 1, 0, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 1},
            {1, 0, 0, 0, 0, 0, 4, 1},
            {1, 1, 1, 1, 1, 1, 1, 1}
        };


        System.Random rnd = new System.Random();
        int mapa = rnd.Next(1, 4);
        Debug.Log(mapa);

        MapGenerator mp = new MapGenerator(); //zavol�m instanci t��dy MapGenerator a p�ed�m random matici pro mapu
        mp.GenerateMap(randMap4, emptyPrefab, wallPrefab,Player,Konec);

        Debug.Log("Vol�m gener�tor...");
    }


    // Update is called once per frame
}
