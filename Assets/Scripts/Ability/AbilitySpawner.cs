using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySpawner : MonoBehaviour
{
    [SerializeField]
    private List<ItemSpawnPoint> spawnPoints;

    [SerializeField]
    private List<ItemObject> spawnItems;

    [SerializeField]
    private int itemSpawnSeconds;

    [HideInInspector]
    public Animator anim;


    int i = 0;

   void FixedUpdate()
    {
        if (spawnItems != null)
        {
            foreach (ItemSpawnPoint spawn in spawnPoints)
            {
                if (spawn.item == null)
                {
                    if (Time.time >i)
                    {
                        i += itemSpawnSeconds;
                        ItemObject randItem = GetRandomItem();
                        spawn.item = randItem.gameObject;
                        SpawnAbility(randItem,spawn);
                    }
                }
            }
        }
    }

    private ItemObject GetRandomItem()
    {
        return spawnItems[Random.Range(0, spawnItems.Count)];
    }

    public void SpawnAbility(ItemObject respawnAbility, ItemSpawnPoint spawn)
    {
        anim = spawn.GetComponent<Animator>();
        anim.enabled = true;
        anim.SetBool(respawnAbility.referenceItem.animationName,true);
    }
}
