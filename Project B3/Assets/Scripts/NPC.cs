using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform goal;
    public Transform agentPos;
    public UnityEngine.AI.NavMeshAgent agent;
    
    void Start () {
        agent.speed = 3;
        agent.destination = goal.position;

    }


    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(agentPos.position, Vector3.forward, Color.red);
    }
}
