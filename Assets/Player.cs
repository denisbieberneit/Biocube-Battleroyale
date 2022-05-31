using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.HealthSystemCM;
using CodeMonkey.Utils;
using FishNet.Object;
using FishNet.Connection;

public class Player : NetworkBehaviour,IGetHealthSystem
{

    private HealthSystem healthSystem;

    [SerializeField]
    private float baseHealth;

    // Start is called before the first frame update
    void Awake()
    {
        if (!base.IsClient)
        {
            return;
        }
        healthSystem = new HealthSystem(baseHealth);

        healthSystem.OnDead += HealthSystem_OnDead;
    }

    private void Start()
    {
        if (!base.IsClient)
        {
            return;
        }
        FunctionPeriodic.Create(() =>
        {
            /*if (DamageCircle.IsOutsideCircle_Static(transform.position)) //TODO: add back
            {
                TakeDamage(33.4f);
            }
            else
            {
                GainHealth(33.4f);
            }*/
        },2f);
    }

    public void GainHealth(float health)
    {
        if (!base.IsClient)
        {
            return;
        }
        healthSystem.Heal(health);
    }

    public void TakeDamage(float takeDamage)
    {
        if (!base.IsClient)
        {
            return;
        }
        healthSystem.Damage(takeDamage);
    }

    private void HealthSystem_OnDead(object sender, System.EventArgs e)
    {
        if (!base.IsClient)
        {
            return;
        }
        Destroy(gameObject);
    }

    public HealthSystem GetHealthSystem()
    {
        if (!base.IsClient)
        {
            return null;
        }
        return healthSystem;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ability")
        {
            NetworkConnection aOwner = collision.gameObject.GetComponent<ItemObject>().getOwner();
            NetworkConnection pOwner = GetComponent<NetworkObject>().Owner;
            if (aOwner.ClientId != pOwner.ClientId)
            {
                Debug.Log(aOwner.ClientId + " hit " + pOwner.ClientId);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            NetworkConnection owner = GetComponent<NetworkObject>().Owner;
            NetworkConnection targetOwner = collision.gameObject.GetComponent<NetworkObject>().Owner;
            Debug.Log(owner.ClientId + ":" + targetOwner.ClientId);
            if (owner.ClientId != targetOwner.ClientId)
            {
                Debug.Log("Hitted " + targetOwner.ClientId);
            }

        }
    }
}
