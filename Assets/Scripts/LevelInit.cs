using System;
using System.Collections.Generic;
using System.Linq;
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

    public long[,] MatrixFromString(string matrixString)
    {
        List<string[]> rows = matrixString.Split(new string[] { "end" }, StringSplitOptions.RemoveEmptyEntries)
                                       .Select(row => row.Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries))
                                       .ToList();

        // Determine the dimensions of the array
        int numRows = rows.Count;
        int numCols = rows.Max(row => row.Length);

        // Create a long[,] array
        long[,] matrix = new long[numRows, numCols];

        // Convert string values to long and populate the array
        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < rows[i].Length; j++)
            {
                if (!long.TryParse(rows[i][j], out matrix[i, j]))
                {
                    Debug.Log($"Error parsing value at row {i + 1}, column {j + 1}");
                }
            }
        }

        return matrix;
    }
    public void Generate()
    {
        List<long[,]> matrixOfMaps = new();

        //int[][,] matrixOfMaps = new int[numberOfMaps][,];

        //matrixOfMaps[0] = new int[,]
        //{
        //    {34, 12, 12, 12, 12, 12, 12, 33},
        //    {13, 4 , 0 , 0 , 66 , 0 , 0 , 14},
        //    {13, 0 , 0 , 0 , 0 , 0 , 0 , 14},
        //    {13, 2 , 0 , 0 , 5 , 7 , 3 , 14},
        //    {32, 11, 11, 11, 11, 11, 11, 31}
        //};

        //matrixOfMaps[1] = new int[,]
        //{
        //    {34, 12, 12, 12, 12, 12, 12, 33},
        //    {13, 4 , 0 , 0 , 0 , 0 , 3 , 14},
        //    {13, 0 , 0 , 0 , 0 , 0 , 0 , 14},
        //    {13, 2 , 0 , 0 , 5 , 6, 7 , 14},
        //    {32, 11, 11, 11, 11, 11, 11, 31}
        //};



        matrixOfMaps.Add(new long[,]
           {
            {34, 12, 12, 12, 12, 12, 12, 33},
            {13, 4 , 0 , 0 , 66 , 0 , 0 , 14},
            {13, 0 , 0 , 0 , 0 , 0 , 0 , 14},
            {13, 2 , 0 , 0 , 5 , 7 , 3 , 14},
            {32, 11, 11, 11, 11, 11, 11, 31}
           });

        //matrixOfMaps.Add(new long[,]
        //{
        //    {34, 12, 12, 12, 12, 12, 12, 33},
        //    {13, 4 , 0 , 0 , 0 , 0 , 0 , 14},
        //    {13, 0 , 0 , 0 , 0 , 0 , 0 , 14},
        //    {13, 2 , 0 , 0 , 5 , 7 , 3 , 14},
        //    {32, 11, 11, 11, 11, 11, 11, 31}
        //});




        string matrixString = @"
1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	end
1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	34	12	12	12	12	33	1	34	12	12	33	1	1	1	1	1	end
1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	13	0	0	0	66	23	1	13	0	0	23	12	12	33	1	1	end
1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	13	0	0	0	0	0	23	24	0	0	66	0	0	14	1	1	end
1	1	1	1	34	12	12	12	33	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	34	24	0	0	0	0	0	0	66	0	0	0	0	0	14	1	1	end
1	34	12	12	24	0	66	0	23	12	12	12	33	1	1	1	1	1	1	1	1	1	1	1	1	1	1	13	66	0	0	0	0	0	0	0	0	0	0	0	3	14	1	1	end
34	24	0	66	0	0	0	0	0	0	66	3	14	1	1	1	1	1	1	1	1	1	1	1	1	1	1	13	0	0	0	0	0	0	0	0	0	0	0	0	21	31	1	1	end
13	0	0	0	0	0	0	0	0	0	0	21	31	1	1	1	1	1	1	1	1	1	1	1	1	1	34	24	0	0	0	0	0	0	0	0	0	0	0	0	14	1	1	1	end
13	2	0	0	0	0	0	0	0	0	0	14	1	1	1	1	1	1	1	1	1	1	1	1	1	1	13	0	0	0	0	0	0	0	0	0	0	0	0	0	23	12	33	1	end
32	11	22	0	0	0	0	0	0	0	0	23	12	12	12	12	12	12	12	12	12	12	12	12	12	12	24	0	0	0	0	0	5	0	0	0	0	0	0	0	0	0	14	1	end
1	1	13	0	0	0	0	0	0	0	0	0	66	0	66	0	66	0	66	0	66	0	66	0	66	0	0	0	0	0	0	0	5	0	0	0	0	0	0	0	0	0	23	1	end
1	1	13	6	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	6	0	6	0	0	0	0	7	21	11	22	0	0	0	0	0	0	0	0	3	1	end
1	1	32	22	0	0	0	0	0	0	0	6	0	6	0	6	7	6	0	6	3	6	0	21	11	22	0	0	0	0	21	1	1	13	0	0	0	0	0	0	0	0	21	1	end
1	1	1	13	0	0	0	0	5	0	0	21	11	11	11	11	11	11	11	11	11	11	11	31	1	32	22	0	0	0	14	1	1	13	0	0	0	0	0	0	0	6	14	1	end
1	1	1	13	0	0	0	21	22	0	0	14	1	1	1	1	1	1	1	1	1	1	1	1	1	1	13	0	0	0	14	1	1	13	0	0	0	0	0	0	0	21	31	1	end
1	34	12	24	0	0	21	31	13	0	0	23	12	33	1	1	1	1	1	1	1	1	1	1	1	1	13	3	0	0	14	1	1	32	22	5	0	0	0	0	0	14	1	1	end
34	24	0	0	0	0	23	1	32	22	0	0	0	14	1	1	1	1	1	1	1	1	1	1	1	1	32	22	0	0	14	1	1	1	13	5	0	0	0	0	0	14	1	1	end
13	66	0	0	0	0	0	14	1	32	11	22	0	14	1	1	1	1	1	1	1	34	12	12	33	1	1	13	0	0	23	12	33	1	32	22	0	0	0	0	0	14	1	1	end
13	0	0	0	6	7	0	14	1	1	1	13	0	23	33	1	1	34	12	12	12	24	0	66	23	33	1	13	0	0	0	66	23	12	12	24	0	0	0	0	21	31	1	1	end
13	0	3	21	11	22	0	14	34	12	12	24	0	0	23	12	12	24	66	0	0	0	0	0	0	14	1	13	0	0	0	0	0	0	66	0	0	0	21	11	1	1	1	1	end
32	11	11	31	1	13	0	23	24	0	0	0	0	0	0	0	0	0	0	0	0	0	7	0	0	14	1	32	22	0	0	0	0	0	0	0	6	4	14	1	1	1	1	1	end
1	1	1	1	1	13	0	66	0	0	0	0	0	0	0	21	11	11	22	0	3	6	21	11	11	31	1	1	13	0	0	0	0	0	0	21	11	11	31	1	1	1	1	1	end
1	1	1	1	1	32	22	0	0	0	0	0	0	0	0	14	1	1	32	11	11	11	31	1	1	1	1	1	13	0	0	0	0	21	11	31	1	1	1	1	1	1	1	1	end
1	1	1	1	1	1	13	0	3	0	6	0	21	11	11	31	1	1	1	1	1	1	1	1	1	1	1	1	13	7	6	0	0	14	1	1	1	1	1	1	1	1	1	1	end
1	1	1	1	1	1	32	11	11	11	11	11	31	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	32	11	11	11	11	31	1	1	1	1	1	1	1	1	1	1	end
";


        string matrixStr2 = @"
1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	end
1	1	1	1	34	12	12	12	12	33	34	12	12	12	33	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	34	12	12	33	1	1	1	1	1	end
1	1	34	12	24	0	0	66	0	23	24	66	0	0	14	1	1	1	1	1	1	1	1	1	1	1	1	1	1	34	12	12	24	66	0	14	1	1	1	1	1	end
1	1	13	0	0	0	0	0	0	0	0	0	0	0	14	1	1	1	1	1	1	1	1	1	1	1	1	1	1	13	66	0	0	0	0	23	33	1	1	1	1	end
1	1	13	0	0	0	0	0	0	0	0	0	0	0	14	1	1	1	1	1	34	12	12	12	12	12	12	12	33	13	0	0	0	0	0	0	14	1	1	1	1	end
1	1	13	3	0	0	0	0	0	0	6	0	21	11	31	1	1	1	1	1	13	0	66	0	0	0	0	0	23	24	0	0	0	0	0	6	14	1	1	1	1	end
1	1	32	22	0	0	0	0	0	0	21	11	31	1	1	1	1	1	1	34	24	0	0	0	0	0	0	0	66	0	0	0	0	0	3	21	31	1	1	1	1	end
1	1	1	13	7	0	0	0	0	0	23	12	33	1	1	1	1	1	34	24	0	0	0	0	0	0	0	0	0	0	0	6	0	0	21	31	1	1	1	1	1	end
1	1	1	32	22	0	0	0	0	0	0	0	14	1	34	12	12	12	24	0	0	0	0	0	0	21	11	22	0	7	0	21	11	11	31	1	1	1	1	1	1	end
1	1	1	1	13	0	0	0	0	0	0	0	23	12	24	0	0	0	0	0	0	0	0	0	0	23	33	32	11	11	11	31	1	1	1	1	1	1	1	1	1	end
1	1	1	1	13	0	6	0	0	0	0	0	66	0	0	0	0	0	0	0	6	0	0	0	0	0	14	1	1	1	1	1	1	1	1	1	1	1	1	1	1	end
1	1	1	1	32	11	22	0	0	0	0	0	0	0	3	0	0	7	21	11	22	0	0	0	0	6	14	1	1	1	1	1	1	1	1	1	1	1	1	1	1	end
1	1	1	1	1	1	13	0	0	0	0	0	0	0	21	11	11	11	31	1	13	0	0	0	21	11	31	1	1	1	1	1	1	1	1	1	1	1	1	1	1	end
1	1	1	1	1	1	32	11	22	0	0	0	21	11	31	1	1	1	1	34	24	0	0	0	23	33	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	end
1	1	1	1	1	1	1	1	32	22	0	0	23	33	1	1	1	1	1	13	0	0	0	0	66	23	12	12	12	33	1	1	1	1	1	34	12	12	12	12	33	end
1	1	1	1	1	1	1	1	1	13	0	0	0	14	1	1	1	1	34	24	0	0	0	0	0	0	0	66	0	14	1	1	1	1	34	24	0	0	66	0	14	end
1	1	1	1	1	34	12	12	12	24	0	0	0	23	12	12	12	12	24	66	0	0	0	0	0	6	0	0	0	23	12	12	12	12	24	66	0	0	0	3	14	end
1	1	34	12	12	24	0	0	66	0	0	0	0	66	0	0	66	0	0	0	0	0	0	21	11	11	22	0	0	0	0	0	0	0	0	0	0	0	0	21	31	end
34	12	24	66	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	21	11	31	1	1	13	0	0	0	0	0	21	22	0	0	0	0	21	31	1	end
13	0	0	0	0	0	0	0	0	0	0	0	21	11	11	22	0	6	0	0	0	23	12	12	33	1	32	22	7	0	6	21	31	13	0	0	0	0	14	1	1	end
13	0	0	0	0	0	0	0	0	7	0	0	14	1	1	32	11	22	0	0	0	66	0	0	23	12	33	32	11	11	11	31	1	13	4	0	0	0	14	1	1	end
13	0	0	0	0	0	0	6	0	21	11	11	31	1	1	1	1	13	0	0	0	0	0	0	0	66	23	12	33	1	1	1	1	32	22	0	6	0	14	1	1	end
13	6	0	0	0	0	0	21	11	31	1	1	1	1	1	1	34	24	0	0	0	0	0	0	0	0	0	0	23	12	12	33	1	1	13	0	21	11	31	1	1	end
32	22	2	0	0	0	0	14	1	1	1	1	1	1	1	34	24	0	0	0	0	0	7	0	0	0	0	0	66	0	0	23	33	34	24	0	14	1	1	1	1	end
1	32	22	0	0	6	3	14	1	1	1	1	1	1	1	13	0	0	0	0	0	21	22	0	0	0	0	0	0	0	0	0	23	24	66	0	14	1	1	1	1	end
1	1	32	11	11	11	11	31	1	1	1	1	1	1	1	13	0	0	0	0	21	31	32	22	0	0	0	21	11	22	0	0	0	0	0	0	14	1	1	1	1	end
1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	13	6	3	0	0	14	1	1	32	22	0	21	1	1	1	22	0	21	11	11	11	31	1	1	1	1	end
1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	32	11	11	11	11	31	1	1	1	13	0	23	1	1	12	24	0	14	1	1	1	1	1	1	1	1	end
1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	13	0	0	14	13	0	0	0	14	1	1	1	1	1	1	1	1	end
1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	13	0	0	23	24	0	21	11	31	1	1	1	1	1	1	1	1	end
1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	13	6	3	0	0	0	14	1	1	1	1	1	1	1	1	1	1	end
1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	32	11	22	0	6	0	14	1	1	1	1	1	1	1	1	1	1	end
1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	32	11	11	11	31	1	1	1	1	1	1	1	1	1	1	end
1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	end
";


        matrixOfMaps.Add(MatrixFromString(matrixString));
        matrixOfMaps.Add(MatrixFromString(matrixStr2));

        //System.Random rnd = new System.Random();
        //int mapa = rnd.Next(0, 2);
        //Debug.Log(mapa);
        int map = lvlArray[currIdx - 1];
        long[,] selectedMap = matrixOfMaps[map - 1];
        Debug.Log("Vybiram mapu:" + map);

        MapGenerator mp = new MapGenerator(); //zavolám instanci tøídy MapGenerator a pøedám random matici pro mapu
        mp.GenerateMap(selectedMap, emptyPrefab, wallPrefab, Player, Konec, Bodik, Rasa, RasaLong, Uhor,
                        Textury_Kraj_1, Textury_Kraj_2, Textury_Kraj_3, Textury_Kraj_4,
                        Textury_vnejsiRoh_1, Textury_vnejsiRoh_2, Textury_vnejsiRoh_3, Textury_vnejsiRoh_4,
                        Textury_vnitrniRoh_1, Textury_vnitrniRoh_2, Textury_vnitrniRoh_3, Textury_vnitrniRoh_4
                        );


        Debug.Log("Volám generátor...");

    }


    //{
    //    { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 12, 12, 12, 12, 1, 1, 1, 12, 12, 1, 1, 1, 1, 1, 1 },
    //{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 13, 0, 0, 0, 55, 23, 1, 13, 0, 0, 23, 12, 12, 1, 1, 1 },
    //{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 13, 0, 0, 0, 55, 0, 23, 24, 0, 0, 55, 0, 0, 14, 1, 1 },
    //{ 1, 1, 1, 1, 1, 12, 12, 12, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 24, 0, 0, 0, 0, 0, 0, 55, 0, 0, 55, 0, 0, 14, 1, 1 },
    //{ 1, 1, 12, 12, 24, 0, 55, 0, 23, 12, 12, 12, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 13, 55, 0, 0, 0, 0, 0, 0, 55, 0, 0, 0, 0, 3, 14, 1, 1 },
    //{ 1, 24, 0, 55, 0, 0, 55, 0, 0, 0, 55, 3, 14, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 13, 55, 0, 0, 0, 0, 0, 0, 55, 0, 0, 55, 0, 0, 14, 1, 1 },
    //{ 13, 0, 0, 55, 0, 0, 0, 0, 0, 0, 55, 21, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 24, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 21, 1, 1, 1 },
    //{ 13, 2,0, 0, 0, 0, 0, 0, 0, 0, 0, 14, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 12, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 23, 12, 1, 1 },
    //{ 1, 11, 22, 0, 0, 0, 0, 0, 0, 0, 0, 23, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 24, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 23, 12, 1, 1 },
    //{ 1, 1, 13, 5, 0, 0, 0, 0, 0, 0, 0, 55, 0, 55, 0, 55, 0, 55, 0, 55, 0, 55, 5, 55, 5, 0, 0, 0, 0, 7, 21, 11, 22, 0, 0, 0, 0, 3, 1 },
    //{ 1, 1, 13, 5, 0, 0, 0, 0, 0, 0, 0, 5, 55, 5, 55, 5, 55, 5, 55, 5, 55, 5, 55, 5, 55, 5, 0, 0, 0, 7, 21, 11, 22, 0, 0, 0, 0, 0, 3, 1 },
    //{ 1, 1, 1, 22, 0, 0, 0, 0, 5, 0, 0, 5, 0, 5, 0, 5, 7, 5, 0, 5, 3, 5, 0, 21, 11, 22, 0, 0, 21, 1, 1, 13, 0, 5, 0, 0, 21, 11, 1 },
    //{ 1, 1, 1, 13, 0, 0, 0, 0, 5, 0, 0, 21, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 1, 1, 1, 22, 0, 0, 14, 1, 1, 13, 0, 0, 0, 21, 1, 1 },
    //{ 1, 1, 1, 13, 0, 0, 0, 21, 22, 0, 0, 14, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 13, 0, 0, 14, 1, 1, 13, 0, 0, 0, 21, 1, 1 },
    //{ 1, 1, 12, 24, 0, 0, 21, 11, 13, 0, 0, 23, 12, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 13, 3, 0, 14, 1, 1, 1, 22, 5, 0, 0, 0, 0, 14, 1, 1 },
    //{ 1, 24, 0, 0, 0, 0, 23, 1, 1, 22, 0, 0, 0, 14, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 22, 0, 14, 1, 1, 1, 13, 5, 0, 0, 0, 0, 14, 1, 1 },
    //{ 13, 55, 0, 0, 5, 0, 0, 14, 1, 1, 11, 22, 0, 14, 1, 1, 1, 1, 1, 1, 1, 12, 12, 1, 1, 1, 13, 0, 23, 12, 1, 1, 1, 22, 0, 0, 0, 21, 1, 1, 1 },
    //{ 13, 55, 0, 0, 5, 7, 0, 14, 1, 1, 1, 13, 0, 23, 1, 1, 1, 1, 12, 12, 12, 24, 0, 55, 24, 1, 1, 13, 0, 0, 0, 55, 23, 12, 12, 24, 0, 0, 0, 21, 1, 1, 1 },
    //{ 13, 0, 3, 21, 11, 22, 0, 14, 1, 12, 12, 24, 0, 0, 23, 12, 12, 24, 55, 0, 0, 0, 0, 55, 0, 14, 1, 13, 0, 0, 0, 55, 0, 0, 55, 0, 5, 0, 21, 11, 1, 1, 1 },
    //{ 1, 11, 11, 1, 1, 13, 0, 23, 24, 0, 0, 0, 0, 0, 0, 0, 0, 0, 55, 0, 0, 5, 7, 0, 0, 14, 1, 1, 22, 0, 0, 0, 0, 0, 55, 0, 5, 4, 14, 1, 1, 1 },
    //{ 1, 1, 1, 1, 1, 13, 0, 55, 0, 0, 0, 0, 0, 0, 0, 21, 11, 11, 22, 0, 3, 5, 21, 11, 11, 1, 1, 1, 13, 0, 5, 0, 0, 21, 11, 1, 1, 1, 1 },
    //{ 1, 1, 1, 1, 1, 1, 22, 55, 0, 0, 5, 0, 0, 0, 0, 14, 1, 1, 1, 11, 11, 11, 1, 1, 1, 1, 1, 13, 7, 5, 0, 0, 14, 1, 1, 1, 1, 1, 1 },
    //{ 1, 1, 1, 1, 1, 1, 13, 0, 3, 0, 5, 0, 21, 11, 11, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 13, 7, 5, 0, 0, 14, 1, 1, 1, 1, 1, 1 },
    //{ 1, 1, 1, 1, 1, 1, 1, 11, 11, 11, 11, 11, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 11, 11, 11, 11, 1, 1, 1, 1, 1, 1, 1, 1 }
    //};

    // Update is called once per frame
}
