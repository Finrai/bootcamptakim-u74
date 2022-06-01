using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcWalking : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject[] target;
    int currentTarget;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentTarget = 0;
        agent.SetDestination(target[currentTarget].transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (currentTarget == 0)
        {
            currentTarget = 1;
            agent.SetDestination(target[currentTarget].transform.position);
        }
        else
        {
            currentTarget = 0;
            agent.SetDestination(target[currentTarget].transform.position);
        }
    }
}
