using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunnme : MonoBehaviour
{
    public string Name;
    public Animator rigcontroller;
    // Start is called before the first frame update
    void Start()
    {
        rigcontroller.Play("weapon_unarmed");
    }
    // Update is called once per frame

    void Update()
    {
        rigcontroller.Play("equip_" + Name);

    }
 
}
