using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class animatorscript : MonoBehaviour
{
    Animator animator;
    
    bool isjump = false;
    int runnhash;
    float runn = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        runnhash = Animator.StringToHash("runningjump");
    }

    // Update is called once per frame
    void Update()
    {
        bool jump = Input.GetKey(KeyCode.Space);
        bool run = Input.GetKey(KeyCode.LeftShift);

        if(jump && run)
        {
            runn = 1.0f;
        }
        if(run && !jump)
        {
            runn = 0.0f;
        }
        if(jump)
        {
            isjump = true;
            animator.SetBool("isJump", isjump);
        }
        if(!jump)
        {
            isjump = false;
            animator.SetBool("isJump", isjump);
        }
        animator.SetFloat(runnhash, runn);

    }
}
