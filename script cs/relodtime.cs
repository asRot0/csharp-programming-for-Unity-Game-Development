using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class relodtime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }
    public void relodtext(bool isrelod)
    {
        if (isrelod)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }
}
