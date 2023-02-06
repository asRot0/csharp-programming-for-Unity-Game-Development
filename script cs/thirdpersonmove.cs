using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[RequireComponent(typeof(CharacterController))]
public class thirdpersonmove : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    public Transform cam;
    public float speed = 3f;
    public float turnsmoothtime = 0.1f;
    float turnsmoothvelocity;
    public float gravity = 9.8f;
    public float jumpSpeed = 8.0f;
    
    
    void Start() 
    {
        controller = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        Vector3 diraction = new Vector3(horizontal, 0f, Vertical).normalized;


        if(diraction.magnitude >=0.1f)
        {

            float targetangle = Mathf.Atan2(diraction.x, diraction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetangle, ref turnsmoothvelocity, turnsmoothtime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);



            Vector3 movedir = Quaternion.Euler(0f, targetangle, 0f) * Vector3.forward;
            controller.Move(movedir.normalized * speed * Time.deltaTime);
            

        }
    }
}
