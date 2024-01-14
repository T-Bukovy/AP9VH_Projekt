using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Char_movement : MonoBehaviour
{
    Animator _animatorController;
    Rigidbody2D _rigidBody2D;

    [SerializeField]
    [Tooltip("Speed")]
    [Range(0, 50)]
    public float speed = 3;

    [SerializeField]
    [Tooltip("Dash Speed")]
    [Range(0, 100)]
    float dashSpeed = 10;

    [SerializeField]
    [Tooltip("Projectile Prefab")]
    GameObject projectilePrefab;

    [SerializeField]
    [Tooltip("Max Range for Projectile")]
    float maxProjectileRange = 10f;
    float shootSpeed = 10;

    [SerializeField] private TextMeshProUGUI scoreText;

    bool isDashing = false;
    //private static bool playerExists = false;
    private bool isRepeating = false;

    // Start is called before the first frame update
    void Start()
    {
        _animatorController = GetComponent<Animator>();
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void startDashRoutine()
    {
        StartCoroutine(Dash());
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isDashing)
        {
            if (isRepeating)
            {
                // If InvokeRepeating is already active, stop it
                CancelInvoke("startDashRoutine");
                isRepeating = false;
            }
            else
            {
                // If InvokeRepeating is not active, start it
                InvokeRepeating("startDashRoutine", 0f, 8f);
                isRepeating = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            ShootProjectile();
        }

        float vx = Input.GetAxisRaw("Horizontal");
        float vy = Input.GetAxisRaw("Vertical");

        if (!isDashing)
        {
            if (vx != 0 || vy != 0)
            {
                _animatorController.SetBool("isSwimming", true);
                _rigidBody2D.velocity = new Vector2(vx * speed, vy * speed);
                if (vx < 0)
                {
                    transform.localRotation = Quaternion.Euler(0, 180, 0);
                }
                else if (vx > 0)
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
            }
            else
            {
                _animatorController.SetBool("isSwimming", false);
                _rigidBody2D.velocity = Vector2.zero;
            }
        }
    }

    IEnumerator Dash()
    {
        isDashing = true;

        float dashTime = 0.2f; // Adjust the dash duration as needed
        float startTime = Time.time;

        while (Time.time < startTime + dashTime)
        {
            float vx = Input.GetAxisRaw("Horizontal");
            float vy = Input.GetAxisRaw("Vertical");

            _rigidBody2D.velocity = new Vector2(vx * dashSpeed, vy * dashSpeed);

            yield return null;
        }

        isDashing = false;
    }

    void ShootProjectile()
    {
        if(PointCollector.levelScore > 0)
        {
            if (projectilePrefab != null)
            {
                // Instantiate the projectile
                GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

                // Set the rotation of the projectile to match the character's rotation
                projectile.transform.rotation = transform.rotation;

                // Get the Rigidbody2D of the projectile
                Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();

                // Set the velocity to move horizontally
                projectileRb.velocity = transform.right * shootSpeed; // Change this to the desired speed

                // Set gravity scale to 0 to prevent falling
                projectileRb.gravityScale = 0;

                // Ignore collisions with the character
                Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), GetComponent<Collider2D>());

                // Destroy the projectile after reaching max range
                Destroy(projectile, maxProjectileRange / shootSpeed);

                PointCollector.levelScore--;
                scoreText.text = "Skore: " + PointCollector.levelScore;

            }
        }
        
    }

}
