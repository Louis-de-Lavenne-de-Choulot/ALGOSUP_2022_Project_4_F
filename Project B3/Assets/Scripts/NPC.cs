using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update
    float cooldown = 60F;
    float period;
    public Transform[] goal = new Transform[11];
    Transform agentPos;
    Vector3 agentLastPos;
    UnityEngine.AI.NavMeshAgent agent;
    Vector2 velocity = Vector2.zero;
    Animator anim;
    int timeNumber = 0;
    int[] times = new int[8]{85, 100, 160, 280, 340, 355, 415, 440};

    private bool situp = false;
    private LayerMask chairLayer;
    bool noui;

    private bool sandwichMricowave = false;

    void Start () {
        anim = gameObject.GetComponent<Animator>();
        agentPos = gameObject.GetComponent<Transform>();
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal[PlayerPrefs.GetInt("day", 0)*2-1].position;
        InvokeRepeating("TimeCheck", 20f, 5f);
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
    }

    private void LateUpdate()
    {
        Physics.SyncTransforms();

        //Chair
        if ((Vector3.Distance(transform.position, goal[PlayerPrefs.GetInt("day", 0)*2-1].position) < 1) && (goal[PlayerPrefs.GetInt("day", 0)*2-1].gameObject.layer == LayerMask.GetMask("Chair"))
            && situp == false && (gameObject.GetComponent<Animator>().GetBool("sitAtTable") == false))
        {
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = false;

            transform.position = new Vector3(
                goal[PlayerPrefs.GetInt("day", 0)*2-1].transform.position.x,
                goal[PlayerPrefs.GetInt("day", 0)*2-1].transform.position.y + 0.62f,
                goal[PlayerPrefs.GetInt("day", 0)*2-1].transform.position.z);
            transform.rotation = goal[PlayerPrefs.GetInt("day", 0)*2-1].transform.rotation;

            goal[PlayerPrefs.GetInt("day", 0)*2-1].transform.localPosition = new Vector3(
                goal[PlayerPrefs.GetInt("day", 0)*2-1].transform.localPosition.x,
                goal[PlayerPrefs.GetInt("day", 0)*2-1].transform.localPosition.y,
                goal[PlayerPrefs.GetInt("day", 0)*2-1].transform.localPosition.z - 0.2f);

            gameObject.GetComponent<Animator>().SetBool("sitAtTable", true);
        }

        //Amphitheater chair
        if ((Vector3.Distance(transform.position, goal[PlayerPrefs.GetInt("day", 0)*2-1].position) < 1) && (goal[PlayerPrefs.GetInt("day", 0)*2-1].gameObject.layer == LayerMask.GetMask("Amphi"))
            && situp == false && (gameObject.GetComponent<Animator>().GetBool("sitWithLaptop") == false))
        {
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = false;

            transform.position = new Vector3(
                goal[PlayerPrefs.GetInt("day", 0)*2-1].transform.position.x - 0.25f,
                goal[PlayerPrefs.GetInt("day", 0)*2-1].transform.position.y + 0.65f,
                goal[PlayerPrefs.GetInt("day", 0)*2-1].transform.position.z - 0.185f);

            transform.rotation = Quaternion.Euler(90, 180, goal[PlayerPrefs.GetInt("day", 0)*2-1].transform.rotation.z);

            gameObject.GetComponent<Animator>().SetBool("sitWithLaptop", true);
        }

        //Microwave
        if ((Vector3.Distance(transform.position, goal[PlayerPrefs.GetInt("day", 0)*2-1].position) < 1) && (goal[PlayerPrefs.GetInt("day", 0)*2-1].gameObject.layer == LayerMask.GetMask("Amphi"))
        && situp == false && (gameObject.GetComponent<Animator>().GetBool("sitWithLaptop") == false) && sandwichMricowave == false)
        {
            goal[PlayerPrefs.GetInt("day", 0)*2-1].gameObject.SetActive(false);

            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            gameObject.GetComponent<Rigidbody>().Sleep();

            transform.position = new Vector3(
                goal[PlayerPrefs.GetInt("day", 0)*2-1].transform.position.x,
                goal[PlayerPrefs.GetInt("day", 0)*2-1].transform.position.y,
                goal[PlayerPrefs.GetInt("day", 0)*2-1].transform.position.z);

            transform.Translate(Vector3.back * 0.87f);
            transform.Translate(Vector3.down * 0.315f);

            transform.rotation = Quaternion.Euler(0, 0, goal[PlayerPrefs.GetInt("day", 0) * 2 - 1].transform.rotation.z);

            gameObject.GetComponent<Animator>().SetBool("microwave", true);

            sandwichMricowave = true;
        }

        //Leave Chair
        if (situp == true)
        {
            gameObject.GetComponent<Animator>().SetBool("sitWithLaptop", false);
            gameObject.GetComponent<Animator>().SetBool("sitAtTable", false);
            gameObject.GetComponent<Animator>().SetBool("microwave", false);

            gameObject.GetComponent<Collider>().enabled = true;
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
            gameObject.GetComponent<Rigidbody>().WakeUp();
        }
    }

    void TimeCheck(){
        if (GameTime.intTimer > times[timeNumber]){
            agent.destination = goal[timeNumber].position;
            timeNumber++;
        }
    }
}