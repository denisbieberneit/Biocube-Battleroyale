using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject zone;

    private void Start()
    {
        startMatch();
    }


    void startMatch()
    {
        zone.SetActive(true);
    }
}
