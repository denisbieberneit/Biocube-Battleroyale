using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    private GameObject playerObject;
    private Vector3 oldPosition;
    private Animator anim;
    private bool isJumping = false;
    private bool isFalling = false;
    private Rigidbody2D rb;
    private CharacterController2D characterController;

    private PlayerMovement movement;

    public bool isRunning = false;

    public bool isAttacking = false;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<PlayerMovement>();
        //Debug.Log(movement);
        characterController = GetComponent<CharacterController2D>();
        anim = GetComponent<Animator>();
        playerObject = this.gameObject;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        if (!isJumping || !isFalling)
        {
            HorizontalMovement();
        }

        //Debug.Log(rb.velocity.y);



        if (Input.GetButtonDown("Jump"))
        {
            anim.SetBool("isJumping", true);
            isJumping = true;

        }
        if (rb.velocity.y > 0)
        {
            anim.SetBool("isJumping", true);
        }
        if (rb.velocity.y < 0 && !movement.fullGround)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
            isFalling = true;
            isJumping = false;
        }

        /*if (isJumping && characterController.m_Grounded)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
            isFalling = true;
            isJumping = false;
        }*/


        if (movement.fullGround)
        {
            anim.SetBool("isGround", true);
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
            isFalling = false;
        }
        else
        {
            anim.SetBool("isGround", false);
            anim.SetBool("isRunning", false);
            //anim.SetBool("isJumping", false);
            //isJumping = false;
        }

        //Debug.Log(isJumping + " " + isFalling);
    }

    private void FixedUpdate()
    {
        if (spriteRenderer.sprite.name == "GroundAttackLast" || spriteRenderer.sprite.name == "AirAttackLast")
        {
            SetIsAttacking(false);
        }
    }

    private void HorizontalMovement() {
        Vector3 playerPos = playerObject.transform.position;
        if (Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Horizontal") == 1 || movement.touchController.moveLeft || movement.touchController.moveRight)
        {
            anim.SetBool("isRunning", true);
            isRunning = true;
        }
        else
        {
            anim.SetBool("isRunning", false);
            isRunning = false;
        }


        oldPosition = playerPos;
    }

    public void SetIsAttacking(bool Attacking) {
        if (Attacking)
        {
            anim.SetBool("isAttacking", true);
            isAttacking = true;
        }
        else
        {
            anim.SetBool("isAttacking", false);
            isAttacking = false;
        }
    }
}
