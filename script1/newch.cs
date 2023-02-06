using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newch : MonoBehaviour
{
    Animator animator;
    float velocity = 0.0f;
    public float acceleration = 0.1f;
    public float deceleration = 0.9f;
    int VelocityHash;
    //bool isjump = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        VelocityHash = Animator.StringToHash("Velocity");
    }

    // Update is called once per frame
    void Update()
    {
        bool walk = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
        bool run = Input.GetKey(KeyCode.LeftShift);
        bool jump = Input.GetKey(KeyCode.Space);


        /**if(jump)
        {
            isjump = true;
            animator.SetBool("isJump", isjump);
        }
        if(!jump)
        {
            isjump = false;
            animator.SetBool("isJump", isjump);
        }**/
        if(walk && velocity<0.5f)
        {
            velocity += acceleration * Time.deltaTime;
            if(velocity > 0.5f)
            {
                velocity = 0.6f;
            }
        }
        if( walk && run && velocity > 0f)
        {
            velocity += acceleration * Time.deltaTime;
            if(velocity > 1.0f)
            {
                velocity = 1f;
            }
        }
        if(!run && velocity>0.6f)
        {
            velocity -= deceleration * Time.deltaTime;
            if(velocity < 0.7)
            {
                velocity = 0.6f;
            }
        }
        if(!walk && velocity>0.0f)
        {
            velocity -= deceleration * Time.deltaTime;
        }
        if(!walk && velocity<0.0f)
        {
            velocity = 0.0f;
        }
        animator.SetFloat(VelocityHash, velocity);

    }
}
