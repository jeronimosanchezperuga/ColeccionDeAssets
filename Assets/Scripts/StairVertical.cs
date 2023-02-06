using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairVertical : MonoBehaviour
{
    public float playerHeightDifference;
    float minY;

    // Start is called before the first frame update
    void Start()
    {
        minY = transform.position.y + 0.5f; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject go = collision.gameObject;
        if (go.CompareTag("Player"))
        {
            go.GetComponent<Rigidbody2D>().gravityScale = 0;
            go.GetComponent<PlayerMovement>().minY = minY;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject go = collision.gameObject;
        if (go.CompareTag("Player"))
        {
            go.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }


}
