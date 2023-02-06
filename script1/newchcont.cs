using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newcontrol2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform charactercontroler;
    public float speed;
    public float turnsmooth;

    void Start() 
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        float horijon = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveplayer = new Vector3(horijon, 0, vertical);
        moveplayer.Normalize();

        transform.Translate(moveplayer * speed * Time.deltaTime, Space.World);

        if(moveplayer!= Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveplayer, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, turnsmooth * Time.deltaTime);
        }

    }
}
