using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    private Collider2D col;

    private void Start()
    {
        col = GetComponent<Collider2D>();
    }

    public void OnStartHit()
    {
        col.enabled = true;
    }

    public void OnEndHit()
    {
        col.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && col.enabled == true)
        {
            Debug.Log(collision.gameObject.tag);
            /*NetworkConnection owner = GetComponent<NetworkObject>().Owner;
            NetworkConnection targetOwner = collision.gameObject.GetComponent<NetworkObject>().Owner;
            Debug.Log(owner.ClientId + ":" + targetOwner.ClientId);
            if (owner.ClientId != targetOwner.ClientId)
            {
                Debug.Log("Hitted " + targetOwner.ClientId);
            }*/
        }
        
    }
}