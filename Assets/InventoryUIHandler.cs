using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIHandler : MonoBehaviour
{
    private Animator anim;

    private InventoryItemData current;

    private void Start()
    {
            anim = GetComponent<Animator>();
    }

    public void UpdateView(InventoryItemData data)
    {
        current = data;
        anim.SetBool(data.animationName, true);
    }

    public void Remove()
    {
        anim.SetBool(current.animationName, false);
        current = null;
    }
}
