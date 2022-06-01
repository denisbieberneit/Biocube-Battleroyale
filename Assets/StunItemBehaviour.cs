using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;

public class StunItemBehaviour : NetworkBehaviour
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
        anim.SetBool("CircleStun", true);
        rb.AddForce(new Vector2(7f * lastMovement, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collided with " + collision.gameObject.tag);
            rb.simulated = false;
            anim.SetBool("CircleStun", true);
            anim.SetBool("CircleStunExplosion", true);
            rb.bodyType = RigidbodyType2D.Static;
            collision.gameObject.GetComponent<Player>().StunPlayer();
        }
    }
}
