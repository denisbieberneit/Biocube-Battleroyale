using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DzMovement : MonoBehaviour
{
    private Vector2 newPosition;
    private float newScaleNumber;
    private Vector3 scaleChange;

    private float scaleStep = -.1f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("test");
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
        newPosition = new Vector2(Random.Range(-6f, 43.5f), Random.Range(-3f, 32.77f));
        newScaleNumber = 40f;
        scaleChange = new Vector3(scaleStep, scaleStep, scaleStep);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.localScale.x > newScaleNumber)
        {
            transform.localScale += scaleChange;
        }
        transform.position = Vector2.MoveTowards(transform.position, newPosition, .01f);
    }
}
