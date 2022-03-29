using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update
    float cooldown = 60F;
    float period;
    public Transform[] goal;
    Transform agentPos;
    Vector3 agentLastPos;
    UnityEngine.AI.NavMeshAgent agent;
    Vector2 velocity = Vector2.zero;
    Animator anim;

    private GameObject chair;
    private bool situp = false;
    private LayerMask chairLayer;

    private float timer = 0f;

    void Start () {
        anim = gameObject.GetComponent<Animator>();
        agentPos = gameObject.GetComponent<Transform>();
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        // agent.speed = 3;
        // agent.destination = goal[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        bool shouldMove = agentPos.position != agentLastPos && agent.remainingDistance > agent.radius;
        if (shouldMove)
        {
            agentLastPos = agentPos.position;
            anim.SetBool("isMoving", true);
        }else{
            if(Time.time > period)
            {
                    period = Time.time + cooldown;
            }
            anim.SetBool("isMoving", false);
            // transform.position = goal[0].position;
            // transform.forward = goal[0].forward;
        }
        //if NPc need to leave chair 
    }

    private void LateUpdate()
    {
        Collider[] hitChair = Physics.OverlapSphere(transform.position, 0.5f, LayerMask.GetMask("Chair"));
        if (hitChair.Length != 0 && gameObject.GetComponent<Animator>().GetBool("sitAtTable") == false && situp == false)
        {
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = false;

            chair = hitChair[0].gameObject;
            chairLayer = hitChair[0].gameObject.layer;

            transform.position = new Vector3(
                hitChair[0].transform.position.x,
                hitChair[0].transform.position.y + 0.62f,
                hitChair[0].transform.position.z);
            transform.rotation = hitChair[0].transform.rotation;

            hitChair[0].transform.localPosition = new Vector3(
                hitChair[0].transform.localPosition.x,
                hitChair[0].transform.localPosition.y,
                hitChair[0].transform.localPosition.z - 0.2f);

            hitChair[0].gameObject.layer = LayerMask.GetMask("Default");

            gameObject.GetComponent<Animator>().SetBool("sitAtTable", true);
        }

        Collider[] hitAmphi = Physics.OverlapCapsule(transform.position, transform.GetChild(0).position, 0.8f, LayerMask.GetMask("Amphi"));
        if (hitAmphi.Length != 0 && gameObject.GetComponent<Animator>().GetBool("sitWithLaptop") == false && situp == false)
        {
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = false;

            chair = hitAmphi[0].gameObject;
            chairLayer = hitAmphi[0].gameObject.layer;

            transform.position = new Vector3(
                hitAmphi[0].transform.position.x - 0.25f,
                hitAmphi[0].transform.position.y + 0.65f,
                hitAmphi[0].transform.position.z - 0.185f);

            transform.rotation = Quaternion.Euler(0, 180, hitAmphi[0].transform.rotation.z);

            hitAmphi[0].gameObject.layer = LayerMask.GetMask("Default");

            gameObject.GetComponent<Animator>().SetBool("sitWithLaptop", true);
        }

        if (situp == true)
        {
            if(chair != null)
            {
                chair.layer = chairLayer;

                gameObject.GetComponent<Animator>().SetBool("sitWithLaptop", false);
                gameObject.GetComponent<Animator>().SetBool("sitAtTable", false);

                gameObject.GetComponent<Collider>().enabled = true;
                gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
                gameObject.GetComponent<Rigidbody>().useGravity = true;

                transform.position = new Vector3(
                hitAmphi[0].transform.position.x - 0.25f,
                hitAmphi[0].transform.position.y + 0.65f,
                hitAmphi[0].transform.position.z - 0.185f);

                timer += Time.deltaTime;

                if(timer > 3)
                {
                    timer = 0f;
                    situp = false;
                }
            }
        }
    }
}