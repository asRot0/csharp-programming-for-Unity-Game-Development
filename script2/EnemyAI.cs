using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    public float radius;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!agent.hasPath)
        {
            //position base
            //agent.SetDestination(GetPoint.Instance.GetRandomPoint (transform, radius));
            //point base
            agent.SetDestination(GetPoint.Instance.GetRandomPoint ());
        }
    }

}
