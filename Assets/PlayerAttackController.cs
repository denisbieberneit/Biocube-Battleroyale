using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    private CapsuleCollider2D col;

    private void Start()
    {
        col = GetComponent<CapsuleCollider2D>();
        col.enabled = true;
    }

    public void OnStartHit()
    {
        //col.enabled = true;
    }

    public void OnEndHit()
    {
        // col.enabled = false;
    }
}
