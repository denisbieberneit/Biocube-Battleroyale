using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.HealthSystemCM;
using CodeMonkey.Utils;
using FishNet.Object;
using FishNet.Connection;

public class Player : MonoBehaviour,IGetHealthSystem
{

    private HealthSystem healthSystem;

    [SerializeField]
    private float baseHealth;

    // Start is called before the first frame update
    void Awake()
    {
        healthSystem = new HealthSystem(baseHealth);

        healthSystem.OnDead += HealthSystem_OnDead;
    }

    private void Start()
    {
        FunctionPeriodic.Create(() =>
        {
            if (DamageCircle.IsOutsideCircle_Static(transform.position))
            {
                TakeDamage(33.4f);
            }
            else
            {
                GainHealth(33.4f);
            }
        },2f);
    }

    public void GainHealth(float health)
    {
        healthSystem.Heal(health);
    }

    public void TakeDamage(float takeDamage)
    {
        healthSystem.Damage(takeDamage);
    }

    private void HealthSystem_OnDead(object sender, System.EventArgs e)
    {
        Destroy(gameObject);
    }

    public HealthSystem GetHealthSystem()
    {
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
}
