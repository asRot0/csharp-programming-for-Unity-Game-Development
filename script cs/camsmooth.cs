using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camsmooth : MonoBehaviour
{
    public Transform target;
    public float smoothspeed = 0.124f;

    void FixedUpdate() 
    {
        
        Vector3 smoothposition = Vector3.Lerp(transform.position, target.position, smoothspeed*Time.deltaTime);
        transform.position = smoothposition;

        transform.LookAt(target);
    }
}
