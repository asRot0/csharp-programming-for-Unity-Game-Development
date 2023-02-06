using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cofset : MonoBehaviour
{
    //public GameObject camObj;
    //public CinemachineFreeLook freeLook;
    public CinemachineCameraOffset offset;
    public CinemachineFollowZoom followZoom;

    //public CinemachineFollowZoom followZoom;
    //CinemachineComposer composer;
    public float nomx;
    public float nomy;
    public float nomz;
    public float zoomx;
    public float zoomy;
    public float zoomz;
    public int aimduration=1;
    public int inzoomFov = 0;
    public int outzoomFov = 0;
    [SerializeField] private GameObject dot;
    private void Start() {
        //followZoom.m_Width = 2.89f;
        followZoom.m_MinFOV = 1f;
        followZoom.m_MaxFOV = 50f;
    }
    // Update is called once per frame
    private void Update() {
        if(Input.GetButton("Fire2")||Input.GetButton("Fire1")){

            offset.m_Offset.x = zoomx;
            offset.m_Offset.y = zoomy;
            offset.m_Offset.z = zoomz;           
            //followZoom.m_MaxFOV = 25f;
            followZoom.m_MinFOV = inzoomFov;
            if (followZoom.m_MaxFOV <= inzoomFov)
                return;
            else
                followZoom.m_MaxFOV -= aimduration;
            dot.SetActive(true);

        }
        else{
            followZoom.m_MaxFOV = outzoomFov;
            //followZoom.m_MinFOV = 43f;
            if (followZoom.m_MinFOV == outzoomFov)
                return;
            else
                followZoom.m_MinFOV += aimduration;
            offset.m_Offset.x = nomx;
            offset.m_Offset.y = nomy;
            offset.m_Offset.z = nomz;
            dot.SetActive(false);
            
        }
    }   
        
}  
