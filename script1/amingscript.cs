using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class amingscript : MonoBehaviour
{
    public Transform groundcheck;
    public LayerMask groundmask;
    public float grounddistance = 0.2f;
    public float aimduration=0.3f;
    public Rig aimlayer;
    private bool isGrounded = true;
    private bool norunningtime =false;
    // Update is called once per frame
    private void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundcheck.position, grounddistance, groundmask);
        bool wkey = Input.GetKey(KeyCode.W);
        bool akey = Input.GetKey(KeyCode.A);
        bool skey = Input.GetKey(KeyCode.S);
        bool dkey = Input.GetKey(KeyCode.D);        
        norunningtime = Input.GetKey(KeyCode.LeftShift);

        if(Input.GetMouseButton(0))
        {
            if(isGrounded && !norunningtime && !(wkey || akey || skey || dkey))
            {
                //muzzelflash.Play();
                //aimlayer.weight += Time.deltaTime / aimduration;
                aimlayer.weight = 1f;
            }
            else
            {
                aimlayer.weight -= Time.deltaTime / aimduration;
            }
        }
        else
        {
            aimlayer.weight -= Time.deltaTime / aimduration;
        }
    
    }

}
