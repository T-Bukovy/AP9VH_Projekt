using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfItHittedPlayer : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField] private AudioSource death;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            death.Play();
            GameObject Player = GameObject.FindGameObjectWithTag("Player");
            Player.transform.position = MapGenerator.PlayerStart;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
