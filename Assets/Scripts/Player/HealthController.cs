using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private LayerMask deadZoneLayerMask;

    [SerializeField]
    private LayerMask deadZoneCollider2LayerMask;

    [SerializeField]
    public Transform rayCastOrigin;

    public GameObject healthObject1;
    public GameObject healthObject2;
    public GameObject healthObject3;

    private SpriteRenderer health1;
    private SpriteRenderer health2;
    private SpriteRenderer health3;

    private float life = 3;
    private float maxLifeStacks = 200f;
    private float lifeStacks = 0f;
    public bool losingLife = false;
    private float colorNumber = 1f;

    
    // Start is called before the first frame update
    void Start()
    {
        
        health1 = healthObject1.GetComponent<SpriteRenderer>();
        health2 = healthObject2.GetComponent<SpriteRenderer>();
        health3 = healthObject3.GetComponent<SpriteRenderer>();



        Debug.Log(health3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FirstCollider(){
        losingLife = false;
    }
    public void SecondCollider()
    {
        losingLife = true;
    }

    public void LoseLife() {
        life = life - 1f;
    }

    [System.Obsolete]
    private void FixedUpdate()
    {


        /*if (Physics2D.Raycast(rayCastOrigin.position, Vector2.down, .5f, deadZoneCollider2LayerMask) ||
            Physics2D.Raycast(rayCastOrigin.position, Vector2.left, .5f, deadZoneCollider2LayerMask) ||
            Physics2D.Raycast(rayCastOrigin.position, Vector2.right, .5f, deadZoneCollider2LayerMask) ||
            Physics2D.Raycast(rayCastOrigin.position, Vector2.up, .5f, deadZoneCollider2LayerMask) &&
            losingLife == false)
        {
            losingLife = true;
        }


        if (Physics2D.Raycast(rayCastOrigin.position, Vector2.down, .5f, deadZoneLayerMask) ||
            Physics2D.Raycast(rayCastOrigin.position, Vector2.left, .5f, deadZoneLayerMask) ||
            Physics2D.Raycast(rayCastOrigin.position, Vector2.right, .5f, deadZoneLayerMask) ||
            Physics2D.Raycast(rayCastOrigin.position, Vector2.up, .5f, deadZoneLayerMask) &&
            losingLife == true)
        {
            losingLife = false;
        }*/

        colorNumber = 1f - (lifeStacks / maxLifeStacks);



        //Outside the deadzone
        if (losingLife)
        {
            if (lifeStacks < maxLifeStacks)
            {
                lifeStacks = lifeStacks + 1f;

                
            }
            if (lifeStacks == maxLifeStacks)
            {
                life = life - 1f;
                lifeStacks = 0f;
            }
        }
        else
        {
            if (lifeStacks > 0f)
            {
                lifeStacks = lifeStacks - 1f;
            }
        }

        if (life == 2f)
        {
            health3.enabled = false;
        }
        if (life == 1f)
        {
            health2.enabled = false;
        }
        if (life == 0f)
        {
            health1.enabled = false;
            Application.LoadLevel(Application.loadedLevel);
        }

        if (life == 3f)
        {
            health3.material.color = new Color(colorNumber, colorNumber, colorNumber, 1f);
        }
        if (life == 2f)
        {
            health2.material.color = new Color(colorNumber, colorNumber, colorNumber, 1f);
        }
        if (life == 1f)
        {
            health1.material.color = new Color(colorNumber, colorNumber, colorNumber, 1f);
        }
    }
}
