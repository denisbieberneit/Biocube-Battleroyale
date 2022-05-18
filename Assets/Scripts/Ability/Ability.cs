using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public int direction;

    public bool isUsed;

    public bool isInventory;

    protected virtual void Attack(int direction)
    {
        if (isInventory)
        {
            isUsed = true;
            this.direction = direction;
        }
    }
}
