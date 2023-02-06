using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using UnityEngine.UI;


public class Activeweapon : MonoBehaviour
{
    public enum WeaponSlot {
        Primary = 0,
        Secondary =1
    }
    public UnityEngine.Animations.Rigging.Rig handriglayer;
    public UnityEngine.Animations.Rigging.Rig handleftriglayer;

    public Camera fpscam;
    public Text currentammodisplay;
    public Text maxammodisplay;
    public Text ammodividerdisplay;
    public Transform groundcheck;
    public Animator rigcontroller;
    public Transform[] weaponSlots;
    gunshoot[] equipped_weapons = new gunshoot[2];
    int activeWeaponIndex;
    bool isholdstar = false;
    //public Rig weaponposition;
    
   
    // Start is called before the first frame update
    void Start()
    {
       ammodividerdisplay.enabled = false; 
        gunshoot existingweapon = GetComponentInChildren<gunshoot>();
        if(existingweapon){
            Equip(existingweapon);
        }
        
    }
    
    gunshoot GetWeapon(int index) {
        if(index < 0 || index >= equipped_weapons.Length){
            return null;
        }
        return equipped_weapons[index];
        
    }

    // Update is called once per frame
    void Update()
    {
        var weapon = GetWeapon(activeWeaponIndex);
        if(weapon)
        {
            amingscript weaponaim = GetComponent<amingscript>();
           // weaponaim.gunholdster(isholdstar);
            //handriglayer.weight = 1.0f;
            //weaponposition.weight = 1.0f;
            //weapon.gunpoint(gunstr);
            weapon.gunfire(isholdstar);
            
            if(Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2))
            {
                ToggleActiveWeapon();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            SetActiveWeapon(WeaponSlot.Primary);
        }
        /**if (Input.GetKeyDown(KeyCode.Alpha2)) {
           SetActiveWeapon(WeaponSlot.Primary);
        }**/
        /**if (Input.GetKeyDown(KeyCode.Alpha3)) {
            SetActiveWeapon(WeaponSlot.Secondary);
        }**/
    }

    public void Equip(gunshoot newweapon)
    {
        int weaponSlotIndex = (int)newweapon.weaponSlot;
        var weapon = GetWeapon(weaponSlotIndex);
        if(weapon)
        {
            Destroy(weapon.gameObject);
        }
        weapon = newweapon;
        weapon.groundcheck = groundcheck;
        weapon.fpscam = fpscam;
        weapon.currentammoDisplay = currentammodisplay;
        weapon.maxammoDisplay = maxammodisplay;
        weapon.ammodividerDisplay = ammodividerdisplay;
        weapon.transform.SetParent(weaponSlots[weaponSlotIndex], false);
        equipped_weapons[weaponSlotIndex] = weapon;

        SetActiveWeapon(newweapon.weaponSlot);
    }

    void ToggleActiveWeapon() {
        bool isholdstar = rigcontroller.GetBool("holdup_weapon");
        if (isholdstar) {
            StartCoroutine(ActivateWeapon(activeWeaponIndex));
        }else {
            StartCoroutine(HolsterWeapon(activeWeaponIndex));
        }
    }
    void SetActiveWeapon(WeaponSlot weaponSlot) {
        int holsterIndex = activeWeaponIndex;
        int activateIndex = (int)weaponSlot;
        if (holsterIndex == activateIndex) {
            holsterIndex = -1;
        }
        StartCoroutine(SwitchWeapon(holsterIndex, activateIndex));
    }
    IEnumerator SwitchWeapon(int holsterIndex, int activateIndex) {
        yield return StartCoroutine(HolsterWeapon(holsterIndex));
        yield return StartCoroutine(ActivateWeapon(activateIndex));
        activeWeaponIndex = activateIndex;
    }
    IEnumerator HolsterWeapon(int index) {
        isholdstar = true;
        var weapon = GetWeapon(index);
        if (weapon) {
            rigcontroller.SetBool("holdup_weapon", true);
            do{
                yield return new WaitForEndOfFrame();
            }while (rigcontroller.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f);
            
        }
    }
    IEnumerator ActivateWeapon(int index) {

        var weapon = GetWeapon(index);
        if (weapon) {
            rigcontroller.SetBool("holdup_weapon", false);
            rigcontroller.Play("equip_" + weapon.weaponname);
            do{
                yield return new WaitForEndOfFrame();
            }while (rigcontroller.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f);
            isholdstar = false;
        }
    }
    /***
    [ContextMenu("save weapon pose")]
    void saveweaponpose()
    {
        GameObjectRecorder recorder = new GameObjectRecorder(gameObject);
        recorder.BindComponentsOfType<Transform>(weaponparent.gameObject, false);
        recorder.BindComponentsOfType<Transform>(weaponrightgrip.gameObject, false);
        recorder.BindComponentsOfType<Transform>(weaponleftgrip.gameObject, false);
        recorder.TakeSnapshot(0.0f);
        recorder.SaveToClip(weapon.weaponanimation);
        //UnityEditor.AssetDatabase.SaveAssets();
    }**/
    
}
