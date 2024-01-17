using UnityEngine;

public class UhorScrip : MonoBehaviour
{

    [SerializeField] private Sprite[] leftFacingSprites;
    [SerializeField] private Sprite[] rightFacingSprites;
    [SerializeField] private AudioSource popAudio;
    [SerializeField] private AudioSource shotAudio;

    Animator _animatorController;

    private SpriteRenderer spriteRenderer;
    public GameObject lighting;
    public float maxDistance = 10f;
    public float shootDelay = 10f;
    public float bulletSpeed = 5f;
    private float lastShootTime;

    private float distance;
    private GameObject Player;
    private bool isFacingLeft;
    // Start is called before the first frame update
    void Start()
    {
        isFacingLeft = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        _animatorController = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
        lastShootTime = -shootDelay; // Initialize to allow immediate shooting
        _animatorController.SetTrigger("PlayerLeft");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ammo"))
        {

            popAudio.Play();
            Destroy(collision.gameObject);
            Destroy(gameObject, popAudio.clip.length/2);

        }
    }

    // Update is called once per frame

    void Update()
    {
        if (Player != null)
        {
            // Get the direction from the player to this object
            Vector3 directionToPlayer = Player.transform.position - transform.position;

            //spriteRenderer.sprite = rightFacingSprites[0];
            //spriteRenderer.sprite = leftFacingSprites[0];
            if (directionToPlayer.magnitude <= maxDistance)
            {
                if (directionToPlayer.x > 0)
                {
                    if (Time.time - lastShootTime >= shootDelay)
                    {
                        _animatorController.SetTrigger("ShootPlayerRight");
                        shotAudio.Play();
                        Shoot();
                        lastShootTime = Time.time;
                    }
                    else if (isFacingLeft)
                    {
                        _animatorController.SetTrigger("PlayerRight");
                        isFacingLeft = false;
                    }
                }
                else
                {
                    if (Time.time - lastShootTime >= shootDelay)
                    {
                        _animatorController.SetTrigger("ShootPlayerLeft");
                        shotAudio.Play();
                        Shoot();
                        lastShootTime = Time.time;
                    }
                    else if (!isFacingLeft)
                    {
                        _animatorController.SetTrigger("PlayerLeft");
                        isFacingLeft = true;
                    }
                }
            }
        }
    }

    void Shoot()
    {
        if (Player != null)
        {
            
            GameObject bullet = Instantiate(lighting, transform.position, Quaternion.identity);
            
            // Get the direction to the player
            Vector3 directionToPlayer = (Player.transform.position - transform.position).normalized;

            // Calculate the angle between the bullet's forward direction and the direction to the player
            float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

            // Set the rotation of the bullet to match the calculated angle
            bullet.transform.rotation = Quaternion.Euler(0, 0, angle - 45); // Adjust for the 45-degree sprite rotation

            // Get the Rigidbody2D of the bullet
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

            // Set the velocity to move only horizontally
            bulletRb.velocity = directionToPlayer * bulletSpeed;

            // Set gravity scale to 0 to prevent falling
            bulletRb.gravityScale = 0;

            // Ignore collisions with the character
            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());

            // Destroy the bullet after reaching max range
            Destroy(bullet, maxDistance / bulletSpeed);
        }
    }
}
