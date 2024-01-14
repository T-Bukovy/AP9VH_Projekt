using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UhorScrip : MonoBehaviour
{

    [SerializeField] private Sprite[] leftFacingSprites;
    [SerializeField] private Sprite[] rightFacingSprites;
    public GameObject Player;
    private SpriteRenderer spriteRenderer;
    public float maxDistance = 10f;


    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ammo"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame

    void Update()
    {
        if (Player != null)
        {
            // Get the direction from the player to this object
            Vector3 directionToPlayer = Player.transform.position - transform.position;

            if (directionToPlayer.magnitude <= maxDistance)
            {
                // Check if the player is to the left or right
                if (directionToPlayer.x > 0)
                {
                    // Player is to the right
                    ChangeSprite(rightFacingSprites);
                }
                else
                {
                    // Player is to the left
                    ChangeSprite(leftFacingSprites);
                }
            }
        }
    }

    void ChangeSprite(Sprite[] sprites)
    {
        // Rotate towards the player
 

        // Change the sprite based on direction
        spriteRenderer.sprite = sprites[0]; // Assuming you only have one sprite for each direction
    }
}
