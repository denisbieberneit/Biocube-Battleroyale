using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;

public class CameraFollow : NetworkBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 1f;

    public override void OnStartClient()
    {
        base.OnStartClient();
        if (base.IsOwner)
        {
            gameObject.SetActive(true);
        }
    }   
}