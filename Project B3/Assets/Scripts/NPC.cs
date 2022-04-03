using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update
    float cooldown = 60F;
    float period;
    public Transform[] goal = new Transform[10];
    Transform agentPos;
    Vector3 agentLastPos;
    UnityEngine.AI.NavMeshAgent agent;
    Vector2 velocity = Vector2.zero;
    protected Animator anim;
    private int timeNumber;
    private bool situp = false;
    bool noui;

    private Transform Target;
    private Transform lastTarget;
    private bool sandwichMricowave = false;

    void Start () {
        anim = gameObject.GetComponent<Animator>();
        agentPos = gameObject.GetComponent<Transform>();
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        int pPref = PlayerPrefs.GetInt("day", 0) * 2;
        Target = goal[pPref];
        agent.destination = Target.position;
        timeNumber = pPref+1;
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
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            situp = true;
        }
    }

    private void LateUpdate()
    {
        Physics.SyncTransforms();
        //Chair
        if ((Vector3.Distance(transform.position, Target.position) < 1) && situp == false
            && gameObject.GetComponent<Animator>().GetBool("sitAtTable") == false
            && Target.gameObject.layer == LayerMask.NameToLayer("Chair"))
        {
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = false;

            transform.rotation = Target.transform.rotation;

            Target.Translate(Vector3.back * 0.2f);
            lastTarget = Target;

            transform.position = Target.transform.position;
            transform.Translate(Vector3.up * 0.642f);

            gameObject.GetComponent<Animator>().SetBool("sitAtTable", true);
        }

        //Amphitheater chair
        if ((Vector3.Distance(transform.position, Target.position) < 1) && situp == false
            && gameObject.GetComponent<Animator>().GetBool("sitWithLaptop") == false
            && Target.gameObject.layer == LayerMask.NameToLayer("Amphi"))
        {
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = false;

            lastTarget = Target;

            transform.position = new Vector3(
                Target.transform.position.x - 0.25f,
                Target.transform.position.y + 0.65f,
                Target.transform.position.z - 0.185f);

            transform.rotation = Quaternion.Euler(0, 180, 0);

            gameObject.GetComponent<Animator>().SetBool("sitWithLaptop", true);
        }

        //Microwave
        //if ((Vector3.Distance(transform.position, Target.position) < 2) && (Target.gameObject.layer == LayerMask.GetMask("Amphi"))
        //&& situp == false && (gameObject.GetComponent<Animator>().GetBool("sitWithLaptop") == false) && sandwichMricowave == false)
        //{
        //    Target.gameObject.SetActive(false);

        //    gameObject.GetComponent<Collider>().enabled = false;
        //    gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        //    gameObject.GetComponent<Rigidbody>().Sleep();

        //    transform.position = new Vector3(
        //        Target.transform.position.x,
        //        Target.transform.position.y,
        //        Target.transform.position.z);

        //    transform.Translate(Vector3.back * 0.87f);
        //    transform.Translate(Vector3.down * 0.315f);

        //    transform.rotation = Quaternion.Euler(0, 0, goal[1 * 2 - 1].transform.rotation.z);

        //    gameObject.GetComponent<Animator>().SetBool("microwave", true);

        //    sandwichMricowave = true;
        //}

        //Leave Chair
        if (situp == true)
        {
            if(lastTarget.gameObject.layer == LayerMask.NameToLayer("Chair"))
            {
                Target.Translate(Vector3.forward * 0.2f);
            }

            gameObject.GetComponent<Animator>().SetBool("sitWithLaptop", false);
            gameObject.GetComponent<Animator>().SetBool("sitAtTable", false);
            gameObject.GetComponent<Animator>().SetBool("microwave", false);

            gameObject.GetComponent<Collider>().enabled = true;
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
            gameObject.GetComponent<Rigidbody>().WakeUp();
            situp = false;
        }
    }

    public void TimeChange(){
        gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
        situp = true;
        Target = goal[timeNumber];
        agent.destination = Target.position;
        timeNumber++;
    }
}