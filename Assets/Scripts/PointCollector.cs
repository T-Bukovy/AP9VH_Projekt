using TMPro;
using UnityEngine;

public class PointCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private AudioSource pointCollected;
    [SerializeField] private AudioSource perlaOpen;
    public static int globalScore = 0;
    public static int levelScore = 0;
    public Transform player;
    public Transform bodik;
    // Start is called before the first frame update


    public Sprite closeSprite;
    public Sprite farSprite;
    public Sprite mediumSprite;

    public float closeDistance = 2.0f;
    public float farDistance = 3.0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Perla"))
        {
            pointCollected.Play();
            Destroy(collision.gameObject);
            levelScore++;
            scoreText.text = "Skore: " + levelScore;
        }


    }

    private void Update()
    {
        UpdateCollectibles();
    }


    void Start()
    {
        scoreText.text = "Score = " + levelScore;
    }

    private void UpdateCollectibles()
    {
        GameObject[] collectibles = GameObject.FindGameObjectsWithTag("Perla");

        foreach (GameObject collectible in collectibles)
        {
            float distanceToCollectible = Vector3.Distance(transform.position, collectible.transform.position);

            SpriteRenderer collectibleRenderer = collectible.GetComponent<SpriteRenderer>();

            if (distanceToCollectible < closeDistance)
            {
                // Set the sprite for close distance
                
                collectibleRenderer.sprite = closeSprite;
            }
            else if (distanceToCollectible >= closeDistance && distanceToCollectible < farDistance)
            {
                // Set the sprite for medium distance
                collectibleRenderer.sprite = mediumSprite; 
                perlaOpen.Play();

            }
            else
            {
                
                // Set the sprite for far distance
                collectibleRenderer.sprite = farSprite;
            }
        }
    }

}
