using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelInit : MonoBehaviour
{
    // Start is called before the first frame update
    public int currIdx;
    [SerializeField] private GameObject emptyPrefab;
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Konec;
    [SerializeField] private GameObject Bodik;

    //Kraje
    [SerializeField] private GameObject Textury_Kraj_1;
    [SerializeField] private GameObject Textury_Kraj_2;
    [SerializeField] private GameObject Textury_Kraj_3;
    [SerializeField] private GameObject Textury_Kraj_4;

    //vnejsiRoh
    [SerializeField] private GameObject Textury_vnejsiRoh_1;
    [SerializeField] private GameObject Textury_vnejsiRoh_2;
    [SerializeField] private GameObject Textury_vnejsiRoh_3;
    [SerializeField] private GameObject Textury_vnejsiRoh_4;
    
    //VnitrniRoh
    [SerializeField] private GameObject Textury_vnitrniRoh_1;
    [SerializeField] private GameObject Textury_vnitrniRoh_2;
    [SerializeField] private GameObject Textury_vnitrniRoh_3;
    [SerializeField] private GameObject Textury_vnitrniRoh_4;


    private void Start()
    {
        currIdx = SceneManager.GetActiveScene().buildIndex;
        Generate();
    }

    

    private void Update()
    {
        int possInd = SceneManager.GetActiveScene().buildIndex;
        if (currIdx != possInd)
        {
            Generate();
            currIdx = possInd;
        }

    }

    public void Generate()
    {
        int[,] randMap4 = {
            {34, 12, 12, 12, 12, 12, 12, 33},
            {13, 4 , 0 , 0 , 1 , 0 , 0 , 14},
            {13, 0 , 0 , 0 , 0 , 0 , 0 , 14},
            {13, 2 , 0 , 0 , 1 , 0 , 3 , 14},
            {32, 11, 11, 11, 11, 11, 11, 31}
        };


        System.Random rnd = new System.Random();
        int mapa = rnd.Next(1, 4);
        Debug.Log(mapa);

        MapGenerator mp = new MapGenerator(); //zavolám instanci tøídy MapGenerator a pøedám random matici pro mapu
        mp.GenerateMap(randMap4, emptyPrefab, wallPrefab,Player,Konec, Bodik,
                        Textury_Kraj_1,Textury_Kraj_2,Textury_Kraj_3,Textury_Kraj_4,
                        Textury_vnejsiRoh_1, Textury_vnejsiRoh_2, Textury_vnejsiRoh_3, Textury_vnejsiRoh_4,
                        Textury_vnitrniRoh_1, Textury_vnitrniRoh_2, Textury_vnitrniRoh_3, Textury_vnitrniRoh_4
                        );

        Debug.Log("Volám generátor...");
    }


    // Update is called once per frame
}
