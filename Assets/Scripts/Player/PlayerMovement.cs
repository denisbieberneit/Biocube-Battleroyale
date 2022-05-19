using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public bool isPlayer;
    public CharacterController2D controller;
    public float runSpeed = 40f;
    public float horizontalMove = 0f;
    public bool jump = false;
    public bool holdingJump = false;

    public float lastMovement;

    private float maxForceStacks = 30f;
    public float forceStacks = 0;

    public PhysicsMaterial2D noFriction;
    public PhysicsMaterial2D friction;
    private SlopeCheck slopeCheck;

    public Rigidbody2D rb;

    private AnimationController ac;

    public bool fullGround = false;

    public TouchController touchController;

    private float width;
    private float height;

    public bool forceStackSetZero = false;

    public bool isStunned = false;

    public bool isGased = false;

    public GameObject gameObjecTouchSkill;
    public GameObject gameObjecTouchAttack;

    private InventorySystem inventory;

    private void Start()
    {
        gameObjecTouchSkill = GameObject.Find("MobileSkill");
        gameObjecTouchAttack = GameObject.Find("MobileAttack");
        inventory = GetComponent<InventorySystem>();
        slopeCheck = GetComponent<SlopeCheck>();

        rb = GetComponent<Rigidbody2D>();
        ac = GetComponent<AnimationController>();
        touchController = GetComponent<TouchController>();
    }


    // Update is called once per frame
    void Update()
    {

        if (slopeCheck.onGround || slopeCheck.onSlope)
         {
             fullGround = true;
         }
         else
         {
             fullGround = false;
         }

       
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            ac.SetIsAttacking(true);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            OnAbility();
        }

            if (!ac.isRunning)
        {
            if (slopeCheck.onSlope)
            {
                rb.sharedMaterial = friction;
            }
                
        }
        else
        {
            if (!isStunned)
            {
                rb.sharedMaterial = noFriction;
            }
        }

        //controller.m_JumpForce = 600f;

        
        horizontalMove = Input.GetAxisRaw("Horizontal");
        
        if (touchController.moveLeft)
        {
            horizontalMove = -1f;
        }
        if (touchController.moveRight)
        {
            horizontalMove = 1f;
        }
        //Debug.Log(horizontalMove);


        if (horizontalMove < 0f){
            lastMovement = horizontalMove;
        }
        if (horizontalMove > 0f){
            lastMovement = horizontalMove;
        }
        

        if (Input.GetButtonDown("Jump") && !ac.isAttacking && fullGround)
        {
            OnJumpDown();
        }
        
        if (Input.GetButtonUp("Jump"))
        {
            OnJumpUp();
        }
    }

    void FixedUpdate()
    {
        if (holdingJump && forceStacks < maxForceStacks)
        {
            rb.AddForce(new Vector2(0f, 31f));
            forceStacks = forceStacks + 1;
        }

        if (isPlayer)
        {
            controller.Move(horizontalMove * runSpeed * Time.fixedDeltaTime, false, jump);
            jump = false;
        }
       
    }

    public void OnJumpUp()
    {
        holdingJump = false;
        forceStacks = maxForceStacks;
        forceStackSetZero = true;
    }

    public void OnJumpDown()
    {
        jump = true;
        holdingJump = true;
        forceStacks = 0;
        forceStackSetZero = false;
    }

    public void OnAbility()
    {
        if (inventory.inventory != null)
        {
            ac.SetIsAttacking(true);
            //inventory attack
            Vector3 v = new Vector3(transform.position.x + (.6f * lastMovement), transform.position.y, transform.position.z);
            Instantiate(inventory.inventory.prefab, v, Quaternion.identity);
            inventory.Remove();
        }
    }
}
