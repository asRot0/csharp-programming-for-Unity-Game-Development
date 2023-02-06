using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyaitra : MonoBehaviour
{
    private NavMeshAgent agent;
    Animator animator;
    bool isattackenemy = false;
    bool isrunningenemy = false;
    public Transform targetPlayer;
    public float radius;
    public float fov = 120f;
    public int damage = 50;
    public bool canAttack = true;
    public bool inSight;
    public bool AwareofPlayer;
    public float Awakedistance = 200f;
    public float range = 10f;
    public float normalmove = 2f;
    public float cheasemove = 6f;
    //public bool isplayervision;
    [SerializeField]
    float attacktime = 2f;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float Playerdistace = Vector3.Distance(targetPlayer.position, transform.position);
        Vector3 Playerdiraction = transform.position - transform.position;
        float Playerangle = Vector3.Angle(transform.forward, Playerdiraction);

        if(Playerangle <= fov/2f){
            inSight = true;
        }else{
            inSight = false;
        }
        if(inSight == true){
            AwareofPlayer = true;
            if(Playerdistace < Awakedistance){
                AwareofPlayer = true;
                isrunningenemy = true;
            }else{
                AwareofPlayer = false;
                isrunningenemy = false;
            }
        }    
        if(AwareofPlayer == true){
            agent.speed = cheasemove;
            agent.SetDestination(targetPlayer.position);
            if(Playerdistace < 2f && canAttack){
                StartCoroutine(Attacktime());
                isattackenemy = true;
            }
            else{
                isattackenemy = false;  
            }
            animator.SetBool("isattack", isattackenemy);
            animator.SetBool("isrunning", isrunningenemy);
        }
        else if(AwareofPlayer == false || !agent.hasPath)
        {
            isrunningenemy = false;
            animator.SetBool("isrunning", isrunningenemy);
            agent.speed = normalmove;
            //position base
            agent.SetDestination(GetPoint.Instance.GetRandomPoint (transform, radius));
            //point base
            //agent.SetDestination(GetPoint.Instance.GetRandomPoint ());
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

}
