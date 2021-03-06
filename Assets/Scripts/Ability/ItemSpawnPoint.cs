using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using FishNet.Object;

public class ItemSpawnPoint : NetworkBehaviour
{
    public Transform spawnPoint;

    public bool occupied;

    public GameObject item;

    private SpriteRenderer sprite;

    private Animator anim;

    private void Awake()
    {
        spawnPoint = transform;
        occupied = false;
        item = null;
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && item != null && collider.gameObject.GetComponent<InventorySystem>().inventory == null) 
        {
            ItemObject copy = item.GetComponent<ItemObject>();
            copy.setOwner(collider.gameObject.GetComponent<NetworkObject>().LocalConnection);
            Debug.Log("ClientId of owner: "+  collider.gameObject.GetComponent<NetworkObject>().LocalConnection.ClientId);
            copy.referenceItem.inInventory = true;
            collider.gameObject.GetComponent<InventorySystem>().Add(copy);
            item = null;
            sprite.sprite = null;
            anim.enabled = false;
        }
    }


    [ServerRpc]
    public void ServerSetAnim(string animationName)
    {
        Debug.Log("ServerSetAnim: " + animationName);
        ObserversSetAnim(animationName);
    }

    [ObserversRpc]
    private void ObserversSetAnim(string animationName)
    {
        
        foreach (AnimatorControllerParameter parameter in anim.parameters)
        {
            anim.SetBool(parameter.name, false);
        }
        anim.enabled = true;
        Debug.Log("ObserversSetAnim: " + animationName);
        anim.SetBool(animationName, true);
    }
}
