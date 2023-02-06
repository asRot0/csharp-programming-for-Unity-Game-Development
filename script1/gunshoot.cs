using UnityEngine;

public class gunshoot : MonoBehaviour
{
    //public ParticleSystem MuzzelSystem;
    public Transform groundcheck;
    public LayerMask groundmask;
    public float grounddistance = 0.2f;

    public GameObject Impacteffect;
    public float range = 100f;
    public float damage = 10f;
    public float firerate = 10f;
    public float impacteforce = 40f;
    public Camera fpscam;
    //GameObject impactgame;
    private float nextTimetoFire = 0f;
    private bool isGrounded = true;


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundcheck.position, grounddistance, groundmask);

        bool wkey = Input.GetKey(KeyCode.W);
        bool akey = Input.GetKey(KeyCode.A);
        bool skey = Input.GetKey(KeyCode.S);
        bool dkey = Input.GetKey(KeyCode.D);
        bool spacekey = Input.GetKey(KeyCode.Space);
        if(Input.GetButton("Fire1") && !(wkey || akey || skey || dkey || spacekey) && isGrounded)
        {
            if(Time.time >=nextTimetoFire)
            {
                nextTimetoFire =Time.time + 1f / firerate;
                shoot();
                
            }
        } 
    }
    
    void shoot()
    {
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
