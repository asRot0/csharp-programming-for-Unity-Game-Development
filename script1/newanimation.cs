using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newanimation : MonoBehaviour
{
    Animator animator;
    float velocity = 0.0f;
    public float acceleration = 0.1f;
    public float deceleration = 0.5f;
    int VelocityHash;
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

        if(walk && velocity<1.0f)
        {
            velocity += acceleration * Time.deltaTime;
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
