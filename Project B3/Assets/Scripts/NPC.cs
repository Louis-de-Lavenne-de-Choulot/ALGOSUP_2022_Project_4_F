using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] goal;
    Transform agentPos;
    Vector3 agentLastPos;
    UnityEngine.AI.NavMeshAgent agent;
    Vector2 velocity = Vector2.zero;
    Animator anim;

    void Start () {
        anim = gameObject.GetComponent<Animator>();
        agentPos = gameObject.GetComponent<Transform>();
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.speed = 3;
        agent.destination = goal[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        bool shouldMove = agentPos.position != agentLastPos && agent.remainingDistance > agent.radius;
        if (shouldMove){
            agentLastPos = agentPos.position;
            anim.SetBool("isMoving", false);
        }
        anim.SetBool("isMoving", true);
    }
}