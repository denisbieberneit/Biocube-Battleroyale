using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeItemBehaviour : Ability
{
    private Animator anim;

    private Rigidbody2D rb;

    private float lastMovement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        lastMovement = FindObjectOfType<PlayerMovement>().lastMovement;
    }

    void FixedUpdate()
    {
        anim.SetBool("CircleGas",true);
        rb.AddForce(new Vector2(10f*lastMovement, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
            {
            Debug.Log("Collided with " + collision.gameObject.tag);
            anim.SetBool("CircleGas", true);
            anim.SetBool("CircleGasExplosion", true);
        
            rb.bodyType = RigidbodyType2D.Static;   
            //Gets destroyed by behaviour in animator
        }
    }
}
