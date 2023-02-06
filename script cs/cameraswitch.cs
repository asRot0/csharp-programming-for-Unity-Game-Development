using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraswitch : MonoBehaviour
{
    //[SerializeField]
    public Camera Fpscamera;
    public Camera Tpscamera;
    public Canvas Dotpoint;
    
    // Start is called before the first frame update
    void Start()
    {
        Tpscamera.enabled = true;
        Fpscamera.enabled = false;
        Dotpoint.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(!Input.GetKey(KeyCode.Tab)){
            Dotpoint.enabled = false;
            Tpscamera.enabled = true;
            Fpscamera.enabled = false;
        }
        if(Input.GetKey(KeyCode.Tab)){
            Tpscamera.enabled = false;
            Fpscamera.enabled = true;
            Dotpoint.enabled = true;            
        }
    }
    
}