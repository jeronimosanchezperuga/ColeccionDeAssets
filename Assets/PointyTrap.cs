using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointyTrap : MonoBehaviour
{
    [SerializeField] int prizeAmount;
    [SerializeField] GameObject fxFeedback;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AffectPlayer(collision.gameObject);
            Vector2 point = collision.GetContact(0).point;
            PickedUpBehavior(point);
        }
    }

    void PickedUpBehavior(Vector2 hitPoint)
    {
        Instantiate(fxFeedback, new Vector3(hitPoint.x, hitPoint.y, 0), Quaternion.identity);
    }

    void AffectPlayer(GameObject playerGO)
    {
        playerGO.GetComponent<PlayerBlink>().Blink();
        playerGO.GetComponent<KnockBack>().ActivateKnockBack(transform);
    }
}