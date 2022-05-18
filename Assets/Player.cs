using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.HealthSystemCM;
using CodeMonkey.Utils;

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
                TakeDamage(1f);
            }
        },.2f);
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
}
