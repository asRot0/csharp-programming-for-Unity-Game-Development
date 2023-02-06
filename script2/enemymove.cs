using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemymove : MonoBehaviour
{
    Animator animator;
    bool iswalkingenemy = false;
    bool isattackenemy = false;
    public bool canAttack = true;
    public float fov = 120f;
    public int damage = 50;
    public Transform targetplayer;
    public NavMeshAgent enemyagent;
    public bool inSight;
    public bool AwareofPlayer;
    public float Awakedistance = 200f;
    public float range = 10f;
    //public bool isplayervision;
    [SerializeField]
    float attacktime = 2f;

    void Start() 
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        //Targetenimy target = GetComponent<Targetenimy>();
        float Playerdistace = Vector3.Distance(targetplayer.position, transform.position);
        Vector3 Playerdiraction = targetplayer.position - transform.position;
        float Playerangle = Vector3.Angle(transform.forward, Playerdiraction);
        //playervision(Playerdiraction);

        if(Playerangle <= fov/2f){
            inSight = true;
        }else{
            inSight = false;
        }

        //if((inSight == true) && (Playerdistace < Awakedistance) && (isplayervision == true))
        if((inSight == true) && (Playerdistace < Awakedistance)){
            AwareofPlayer = true;
            
        }
        if(AwareofPlayer == true){
            enemyagent.SetDestination(targetplayer.position);

            if(Playerdistace < 2f && canAttack){
                isattackenemy = true;
                iswalkingenemy = false;
                //target.TakeDamage(damage);
                StartCoroutine(Attacktime());
            }else{
                isattackenemy = false;
                iswalkingenemy = true;
            }
            animator.SetBool("iswalk", iswalkingenemy);
            animator.SetBool("isattack", isattackenemy);
            //damagepass();
        }
    }
    IEnumerator Attacktime()
    {
        canAttack = false;
        yield return new WaitForSeconds(0.1f);
        Targetplayer.singleton.TakeDamage(damage);
        yield return new WaitForSeconds(attacktime);
        canAttack = true;
    }
    /**void playervision(Vector3 plydi)
    {
        //Vector3 Playerdiraction = target.position - transform.position;
        RaycastHit hit;
        if(Physics.Raycast(transform.position, plydi, out hit, rnge))
        {
            if(hit.collider.tag == "Player")
            {
                Debug.Log("playerfound");
                isplayervision = true;
            }
            else
            {
                isplayervision = false;
            }
        }
    }**/
    /**void damagepass(){
        targetplayer target = GetComponentInChildren<targetplayer>();
        if(isattackenemy == true)
        {
            target.TakeDamage2(damage);
        }
    }**/
}
