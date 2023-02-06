using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponpickup : MonoBehaviour
{
    public gunshoot weaponprefeb;
    void Start() {
    }
    private void OnTriggerEnter(Collider other) {

        Activeweapon activeweapon = other.gameObject.GetComponent<Activeweapon>();
        if(activeweapon)
        {
            gunshoot newweapon = Instantiate(weaponprefeb);
            activeweapon.Equip(newweapon);
        }

    }
    private void Update() {


    }

}
