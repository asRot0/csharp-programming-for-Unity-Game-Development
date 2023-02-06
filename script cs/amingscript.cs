using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class amingscript : MonoBehaviour
{
    [SerializeField] public relodtime relodtime;
    public Transform groundcheck;
    public LayerMask groundmask;
    public float grounddistance = 0.2f;
    public float aimduration=0.3f;
    public Rig aimlayer;
    private bool isGrounded = true;
    private bool norunningtime = false;
    private bool moveplayer = false;
    //Animator animator;
    private bool relodchek = false;
    public void relodgun(bool isrelod)
    {
        if (isrelod){
            relodchek = true;
            relodtime.relodtext(relodchek);
        }else{
            relodchek = false;
            relodtime.relodtext(relodchek);
        }

    }
    private void Start() {
         
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

        if(Input.GetButton("Fire1") && !moveplayer)
        {
            if(isGrounded&&!relodchek)
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
