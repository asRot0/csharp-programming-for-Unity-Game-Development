using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorcontrol : MonoBehaviour
{
    Animator anim;
    bool walk = false;
    bool jump = false;
    bool movekey = false;
    //int wlak = Animator.StringToHash("iswalk");

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        //walk = Input.GetKey(KeyCode.W);
        if(Input.GetAxisRaw("Horizontal")!=0f)
        {
            movekey = true;

        }
        else if(Input.GetAxisRaw("Vertical")!=0f)
        {
            movekey = true;
        }
        else
        {
            movekey = false;
        }
        /**bool wkey = Input.GetKey(KeyCode.W);
        bool akey = Input.GetKey(KeyCode.A);
        bool skey = Input.GetKey(KeyCode.S);
        bool dkey = Input.GetKey(KeyCode.D);**/
        bool space = Input.GetKey(KeyCode.Space);
        if(space)
        {
            //Jump();
            jump = true;
        }
        //else if(wkey||akey||skey||dkey)
        else if(movekey)
        {
            walk = true;
        }
        else
        {
            walk = false;
            jump = false;
        }
        anim.SetBool("iswalk", walk);
        anim.SetBool("isjump", jump);

    }
}
