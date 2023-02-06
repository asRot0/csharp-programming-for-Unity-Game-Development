using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weicon : MonoBehaviour
{
    public GameObject[] icobox;
    private int m_CurrentWeaponIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_CurrentWeaponIndex = 0;
    }

    // Update is called once per frame
    public void icon(int index){
        if(index > icobox.Length){
            return;
        }
        m_CurrentWeaponIndex = index;
        for(int i = 0; i < icobox.Length; ++i)
        {
            if(icobox[i] == null)
            {
               break;
            }
            if(i != m_CurrentWeaponIndex)
            {
                icobox[i].gameObject.SetActive(false);
            }
            else
            {
                icobox[i].gameObject.SetActive(true);
            }
        }


    }
}
