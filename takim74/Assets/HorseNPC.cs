using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HorseNPC : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject[] target;
    int currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentTarget = 0;
        agent.SetDestination(target[currentTarget].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        currentTarget = 0;
        agent.SetDestination(target[currentTarget].transform.position);
    }
}
