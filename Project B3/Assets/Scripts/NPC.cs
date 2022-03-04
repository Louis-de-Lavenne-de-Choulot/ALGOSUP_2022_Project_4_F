using System.Collections;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] goal;
    public Transform agentPos;
    public UnityEngine.AI.NavMeshAgent agent;
    Vector2 velocity = Vector2.zero;
    Animator anim;

    void Start () {
        anim = gameObject.GetComponent<Animator>();
        // agent.speed = 3;
        // agent.destination = goal[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        bool shouldMove = velocity.magnitude > 0.5f && agent.remainingDistance > agent.radius;
        anim.SetBool("IsMoving", shouldMove);
        Debug.DrawRay(agentPos.position, Vector3.forward, Color.red);
    }
}