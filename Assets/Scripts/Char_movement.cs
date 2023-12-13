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
    float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        _animatorController = GetComponent<Animator>();
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float vx = Input.GetAxisRaw("Horizontal");
        float vy = Input.GetAxisRaw("Vertical");
        if (vx != 0 || vy != 0)
        {
             _animatorController.SetBool("isSwiming", true);
            _rigidBody2D.velocity = new Vector2(vx * speed, vy*speed);
            
        }
        else
        {
            _animatorController.SetBool("isSwiming", false);
            _rigidBody2D.velocity = Vector2.zero; 
        }

    }
}
