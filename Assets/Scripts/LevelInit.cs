using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelInit : MonoBehaviour
{
    // Start is called before the first frame update
    public int currIdx;
    public int sceneCount;
    public int[] lvlArray;
    public int numberOfMaps = 3;
    [SerializeField] private GameObject emptyPrefab;
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Konec;
    [SerializeField] private GameObject Bodik;
    [SerializeField] private GameObject Rasa;
    [SerializeField] private GameObject RasaLong;
    [SerializeField] private GameObject Uhor;


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

        

        sceneCount = SceneManager.sceneCountInBuildSettings;
        lvlArray = GenerateMapIndices(sceneCount - 2, numberOfMaps);

        Generate();
    }



    private void Update()
    {
        int possInd = SceneManager.GetActiveScene().buildIndex;
        if (currIdx != possInd)
        {
            
            currIdx = possInd;
            Generate();
        }
    }

    public static int[] GenerateMapIndices(int numberOfScenes, int numberOfMaps)
    {

        int[] mapIndices = new int[numberOfScenes];

        // Populate the array with sequential indices starting from 1 up to the number of maps
        for (int i = 0; i < numberOfScenes; i++)
        {
            mapIndices[i] = ((i + 1) % numberOfMaps) + 1;
        }

        // Shuffle the array to create a random order (Fisher-Yates shuffle)
        System.Random random = new System.Random();
        for (int i = numberOfScenes - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            int temp = mapIndices[i];
            mapIndices[i] = mapIndices[j];
            mapIndices[j] = temp;
        }

        return mapIndices;
    }

    public void Generate()
    {
        int[][,] matrixOfMaps = new int[numberOfMaps][,];

        matrixOfMaps[0] = new int[,]
        {
            {34, 12, 12, 12, 12, 12, 12, 33},
            {13, 4 , 0 , 0 , 66 , 0 , 0 , 14},
            {13, 0 , 0 , 0 , 0 , 0 , 0 , 14},
            {13, 2 , 0 , 0 , 5 , 7 , 3 , 14},
            {32, 11, 11, 11, 11, 11, 11, 31}
        };

        matrixOfMaps[1] = new int[,]
        {
            {34, 12, 12, 12, 12, 12, 12, 33},
            {13, 4 , 0 , 0 , 0 , 0 , 3 , 14},
            {13, 0 , 0 , 0 , 0 , 0 , 0 , 14},
            {13, 2 , 0 , 0 , 5 , 6, 7 , 14},
            {32, 11, 11, 11, 11, 11, 11, 31}
        };
        matrixOfMaps[2] = new int[,]
      {
            {34, 12, 12, 12, 12, 12, 12, 33},
            {13, 4 , 0 , 0 , 0 , 0 , 3 , 14},
            {13, 0 , 0 , 0 , 0 , 0 , 0 , 14},
            {13, 2 , 0 , 0 , 0 , 6, 7 , 14},
            {32, 11, 11, 11, 11, 11, 11, 31}
      };




        //System.Random rnd = new System.Random();
        //int mapa = rnd.Next(0, 2);
        //Debug.Log(mapa);
        int map = lvlArray[currIdx - 1];
        int[,] selectedMap = matrixOfMaps[map - 1];
        Debug.Log("Vybiram mapu:" + map);

        MapGenerator mp = new MapGenerator(); //zavolám instanci tøídy MapGenerator a pøedám random matici pro mapu
        mp.GenerateMap(selectedMap, emptyPrefab, wallPrefab, Player, Konec, Bodik, Rasa, RasaLong, Uhor,
                        Textury_Kraj_1, Textury_Kraj_2, Textury_Kraj_3, Textury_Kraj_4,
                        Textury_vnejsiRoh_1, Textury_vnejsiRoh_2, Textury_vnejsiRoh_3, Textury_vnejsiRoh_4,
                        Textury_vnitrniRoh_1, Textury_vnitrniRoh_2, Textury_vnitrniRoh_3, Textury_vnitrniRoh_4
                        );


        Debug.Log("Volám generátor...");

    }


    // Update is called once per frame
}
