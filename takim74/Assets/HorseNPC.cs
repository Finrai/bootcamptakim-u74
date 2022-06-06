using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HorseNPC : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject[] target;
    public GameObject lookat;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
        agent.SetDestination(target[0].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target[0].transform.position);
        
        agent.SetDestination(target[0].transform.position);
        
    }

}
