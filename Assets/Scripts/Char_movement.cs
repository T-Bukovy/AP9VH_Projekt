using System.Collections;
using System.Collections.Generic;
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

    bool isDashing = false;

    // Start is called before the first frame update
    void Start()
    {
        _animatorController = GetComponent<Animator>();
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isDashing)
        {
            StartCoroutine(Dash());
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

}
