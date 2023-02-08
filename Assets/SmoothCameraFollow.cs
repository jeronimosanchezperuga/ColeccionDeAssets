using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float damping;
    public float minX;
    public float minY;

    Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        Vector3 movePosition = target.position + offset;
        Vector3 newPosition = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping);
        transform.position = new Vector3(Mathf.Clamp(newPosition.x, minX, Mathf.Infinity), Mathf.Clamp(newPosition.y, minY, Mathf.Infinity), newPosition.z);
    }
}
