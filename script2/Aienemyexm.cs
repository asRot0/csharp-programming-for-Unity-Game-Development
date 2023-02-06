using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Aienemyexm : MonoBehaviour
{
    Animator animator;
    bool isattackenemy = false;
    bool isrunningenemy = false;
    public enum WanderType { Random, waypoint};

    public WanderType wanderType = WanderType.Random;
    public bool canAttack = true;
 
    public float fov = 120f;
    public int damage = 50;
    public Transform targetplayer;
    public NavMeshAgent enemyagent;
    public bool inSight;
    public bool AwareofPlayer;
    public float Awakedistance = 10f;
    public float cheaseSpeed  = 6f;
    public float wanderSpeed  = 2f;
    public float range = 10f;
    //public bool isplayervision;
    [SerializeField]
    float attacktime = 2f;
    public float wanderRadius = 7f;
    private Vector3 wanderpoint;
    public Transform[] waypoints; //Array of waypoints is only used when waypoint wandering is selected
    private int waypointIndex = 0;

    void Start() 
    {
        animator = GetComponent<Animator>();
        wanderpoint = RandomWanderPoint();
    }
    // Update is called once per frame
    void Update()
    {
        float Playerdistace = Vector3.Distance(targetplayer.position, transform.position);
        Vector3 Playerdiraction = targetplayer.position - transform.position;
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
                enemyagent.speed = cheaseSpeed;
                isrunningenemy = true;
            }else{
                AwareofPlayer = false;
                isrunningenemy = false;
            }
        }
        if(AwareofPlayer == true){
            enemyagent.SetDestination(targetplayer.position);
           
            if(Playerdistace < 2f && canAttack){
                StartCoroutine(Attacktime());
                isattackenemy = true;                
            }else{
                isattackenemy = false;
                
            }
            animator.SetBool("isattack", isattackenemy);
            animator.SetBool("isrunning", isrunningenemy);
        }else{
            isrunningenemy = false;
            animator.SetBool("isrunning", isrunningenemy);
            Wander();
            enemyagent.speed = wanderSpeed;
        }

    }

    public void Wander()
    {
        if(wanderType == WanderType.Random)
        {
            if(Vector3.Distance(transform.position, wanderpoint) < 2f)
            {
                wanderpoint = RandomWanderPoint();
            }else{
                enemyagent.SetDestination(wanderpoint);
            }
        }else
        {
            //waypoint wandering
            if(Vector3.Distance(waypoints[waypointIndex].position, transform.position) < 2f)
            {
                if(waypointIndex == waypoints.Length - 1){
                    waypointIndex = 0;
                }else{
                    waypointIndex++;
                }
            }else{
                enemyagent.SetDestination(waypoints[waypointIndex].position);
            }
        }
    }
    public Vector3 RandomWanderPoint()
    {
        Vector3 randomPoint = (Random.insideUnitSphere * wanderRadius) + transform.position;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomPoint, out navHit, wanderRadius, -1);
        return new Vector3(navHit.position.x, transform.position.y, navHit.position.z);

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
