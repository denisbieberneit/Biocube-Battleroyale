using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemSpawnPoint : MonoBehaviour
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
            InventoryItemData copy = item.GetComponent<ItemObject>().referenceItem;
            copy.inInventory = true;
            collider.gameObject.GetComponent<InventorySystem>().Add(copy);
            item = null;
            sprite.sprite = null;
            anim.enabled = false;
        }
    }
}
