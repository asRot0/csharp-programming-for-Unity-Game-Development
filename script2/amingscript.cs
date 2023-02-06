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
    private bool norunningtime = false;
    private bool moveplayer = false;
    private bool gunishold;

    public void gunholdster(bool isholdstar)
    {
        if(isholdstar == true){
            gunishold = true;
        }else{
            gunishold = false;
        }
    }
    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundcheck.position, grounddistance, groundmask);

        if(Input.GetAxisRaw("Horizontal") != 0.0f){
            moveplayer = true;
        }else if(Input.GetAxisRaw("Vertical") != 0.0f){
            moveplayer = true;
        }else{
            moveplayer = false;
        }
        norunningtime = Input.GetKey(KeyCode.LeftShift);

        if(Input.GetButton("Fire1") && Input.GetKey(KeyCode.Tab))
        {
            if(gunishold && isGrounded && !norunningtime && !moveplayer)
            {
                //muzzelflash.Play();
                //aimlayer.weight += Time.deltaTime / aimduration;
                aimlayer.weight = 1f;
                gunishold = false;

            }    
            else
            {
                aimlayer.weight -= Time.deltaTime / aimduration;
            }
        }
        else
        {
            gunishold = false;
            aimlayer.weight -= Time.deltaTime / aimduration;
        }
    
    }

}
