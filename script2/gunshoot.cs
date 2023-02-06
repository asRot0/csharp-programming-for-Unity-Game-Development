using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gunshoot : MonoBehaviour
{
    //public ParticleSystem MuzzelSystem;
    public Activeweapon.WeaponSlot weaponSlot;
    public AnimationClip weaponanimation;
    public Transform groundcheck;
    public LayerMask groundmask;
    public float grounddistance = 0.2f;

    public GameObject Impacteffect;
    public float range = 100f;
    public int damage = 10;
    public float firerate = 10f;
    public float impacteforce = 40f;
    public Camera fpscam;
    GameObject impactgame;
    private float nextTimetoFire = 0f;
    private bool isGrounded = true;
    private bool moveplayer = false;
    public string weaponname;
    public int maxAmmo = 100;
    public int currentAmmo;
    public int ammorange = 10;
    private int ammoslotcheck;
    public float reloadTime = 1f;
    private bool isReloading = false;
    public Text currentammoDisplay;
    public Text maxammoDisplay;
    public Text ammodividerDisplay;
    void Start() {
        currentAmmo = ammorange;
        //ammodividerDisplay.enabled = false;
    }
    void OnEnable() {
       isReloading = false; 
    }
    public void gunfire(bool isholdstar)
    {
        ammodividerDisplay.enabled = true;
        currentammoDisplay.text = currentAmmo.ToString();
        maxammoDisplay.text = maxAmmo.ToString();
        if(isReloading)
            return;
        if(maxAmmo <= 0 && currentAmmo == 0)
            return;    
        if(currentAmmo <= 0 || (currentAmmo < ammorange && Input.GetKey(KeyCode.R) && isholdstar))
        {
            StartCoroutine(Reload());
            return;
        }
        isGrounded = Physics.CheckSphere(groundcheck.position, grounddistance, groundmask);
        bool spacekey = Input.GetKey(KeyCode.Space);

        if(Input.GetAxisRaw("Horizontal") != 0.0f){
            moveplayer = true;
        }else if(Input.GetAxisRaw("Vertical") != 0.0f){
            moveplayer = true;
        }else{
            moveplayer = false;
        }
        if(Input.GetKey(KeyCode.Tab) && isholdstar && Input.GetButton("Fire1") && !(moveplayer || spacekey) && isGrounded)
        {
            if(Time.time >=nextTimetoFire)
            {
                nextTimetoFire =Time.time + 1f / firerate;
                shoot();
            }
        }
    }
    IEnumerator Reload(){
        isReloading = true;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);
        ammoslotcheck = ammorange - currentAmmo;
        maxAmmo = maxAmmo - ammoslotcheck;
        currentAmmo = currentAmmo + ammoslotcheck;
        //maxAmmo = maxAmmo - ammorange;
        //currentAmmo = ammorange;
        if(maxAmmo<0){
            maxAmmo = 0;
        }
        isReloading = false;
    }
    public void shoot()
    {
        currentAmmo--;
        RaycastHit hit;
        if(Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {
            Targetenimy target = hit.transform.GetComponent<Targetenimy>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impacteforce);
            }
            if(!Input.GetKey(KeyCode.LeftShift))
            {
                //if(!(hit.transform.gameObject.layer == LayerMask.NameToLayer("Player")))
                if(!(hit.transform.gameObject.tag == "Player"))
                {
                    //MuzzelSystem.Play();
                    GameObject impactgame =Instantiate(Impacteffect, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(impactgame, 1f);

                }

            }
        }
    }

}
