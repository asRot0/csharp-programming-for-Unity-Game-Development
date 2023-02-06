using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyaitra : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform targetPlayer;
    public float radius;
    public float fov = 120f;
    public bool inSight;
    public bool AwareofPlayer;
    public float Awakedistance = 200f;
    public float range = 10f;
    //public bool isplayervision;
    [SerializeField]
    float attacktime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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
            }else{
                AwareofPlayer = false;
            }
        }    
        if(AwareofPlayer == true){
            agent.SetDestination(targetPlayer.position);
        }
        else if(AwareofPlayer == false || !agent.hasPath)
        {
            //position base
            //agent.SetDestination(GetPoint.Instance.GetRandomPoint (transform, radius));
            //point base
            agent.SetDestination(GetPoint.Instance.GetRandomPoint ());
        }
    }

}
