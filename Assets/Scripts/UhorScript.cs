using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UhorScrip : MonoBehaviour
{

    [SerializeField] private Sprite[] leftFacingSprites;
    [SerializeField] private Sprite[] rightFacingSprites;
    public GameObject Player;
    private SpriteRenderer spriteRenderer;
    public GameObject lighting;
    public float maxDistance = 10f;
    public float shootDelay = 10f;
    public float bulletSpeed = 5f;
    private float lastShootTime;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        lastShootTime = -shootDelay; // Initialize to allow immediate shooting
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

                if (Time.time - lastShootTime >= shootDelay)
                {
                    Shoot();
                    lastShootTime = Time.time; // Record the time of the last shot
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

    void Shoot()
    {
        if (Player != null)
        {
            // Instantiate a bullet or projectile at Uhor's position
            GameObject bullet = Instantiate(lighting, transform.position, Quaternion.identity);

            // Get the direction to the player
            Vector3 directionToPlayer = (Player.transform.position - transform.position).normalized;

            // Set the rotation of the bullet to match the character's rotation
            bullet.transform.rotation = transform.rotation;

            // Get the Rigidbody2D of the bullet
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

            // Set the velocity to move only horizontally
            bulletRb.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y) * bulletSpeed;

            // Set gravity scale to 0 to prevent falling
            bulletRb.gravityScale = 0;

            // Ignore collisions with the character
            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());

          
            // Destroy the bullet after reaching max range
           

            //if (Physics2D.Raycast(transform.position, directionToPlayer, maxDistance, LayerMask.GetMask("Player")))
            //{
            //    Player.transform.position = MapGenerator.PlayerStart;

            //}
            Destroy(bullet, maxDistance / bulletSpeed);

        }
    }
}
