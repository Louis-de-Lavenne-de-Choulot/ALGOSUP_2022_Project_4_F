using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update
    float cooldown = 60F;
    float period;
    public Transform[] breaks = new Transform[15];
    public Transform goal;
    public Transform[] goals = new Transform[10];
    Transform agentPos;
    Vector3 agentLastPos;
    UnityEngine.AI.NavMeshAgent agent;
    Vector2 velocity = Vector2.zero;
    protected Animator anim;
    private int timeNumber;
    [HideInInspector]
    public bool situp = false;
    int timeTable = 1;
    [HideInInspector]
    public bool inScenario = false;

    private Transform Target;
    private Transform lastTarget;

    [HideInInspector]
    public bool eating;
    public char lunch;

    void Start () {
        anim = gameObject.GetComponent<Animator>();
        agentPos = gameObject.GetComponent<Transform>();
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        int pPref = PlayerPrefs.GetInt("day", 0) * 2;
        Target = goals[pPref];
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

        //Leave Chair
        if (situp == true)
        {
            if(lastTarget){
                if(lastTarget.gameObject.layer == LayerMask.NameToLayer("Chair") )
                {
                    lastTarget.Translate(Vector3.forward * 0.1f);
                }
                if (lastTarget.gameObject.layer == LayerMask.NameToLayer("Microwave"))
                {
                    lastTarget.gameObject.SetActive(true);
                }
            }

            gameObject.GetComponent<Animator>().SetBool("sitWithLaptop", false);
            gameObject.GetComponent<Animator>().SetBool("sitAtTable", false);
            gameObject.GetComponent<Animator>().SetBool("microwave", false);
            gameObject.GetComponent<Animator>().SetBool("Teach", false);
            gameObject.GetComponent<Animator>().SetBool("Fridge", false);
            gameObject.GetComponent<Animator>().SetBool("Eat", false);
            gameObject.GetComponent<Animator>().SetBool("Toillet", false);


            gameObject.GetComponent<Collider>().enabled = true;
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
            gameObject.GetComponent<Rigidbody>().WakeUp();
            situp = false;
        }

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
                Target.transform.position.x,
                Target.transform.position.y,
                Target.transform.position.z);

            transform.rotation = Quaternion.Euler(0, 180, 0);

            gameObject.GetComponent<Animator>().SetBool("sitWithLaptop", true);
        }

        //soft skill
        if ((Vector3.Distance(transform.position, Target.position) < 1) && situp == false
        && gameObject.GetComponent<Animator>().GetBool("sitWithLaptop") == false
        && Target.gameObject.layer == LayerMask.NameToLayer("Soft Skill"))
        {
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = false;

            lastTarget = Target;

            transform.position = new Vector3(
                Target.transform.position.x,
                Target.transform.position.y + 0.637f,
                Target.transform.position.z);

            transform.rotation = Target.rotation;

            gameObject.GetComponent<Animator>().SetBool("sitWithLaptop", true);
        }

        //Eat
        if ((Vector3.Distance(transform.position, Target.position) < 1) && situp == false
            && gameObject.GetComponent<Animator>().GetBool("Eat") == false
            && Target.gameObject.layer == LayerMask.NameToLayer("Eat"))
        {
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = false;

            lastTarget = Target;

            transform.position = new Vector3(
                Target.transform.position.x,
                Target.transform.position.y + 0.6f,
                Target.transform.position.z);

            transform.rotation = Target.rotation;
            transform.Rotate(Vector3.up * -90);

            if (eating)
            {
                gameObject.GetComponent<Animator>().SetBool("Eat", true);
            }
            else
            {
                gameObject.GetComponent<Animator>().SetBool("Toillet", true);
            }
        }

        if ((Vector3.Distance(transform.position, Target.position) < 1) && situp == false
        && gameObject.GetComponent<Animator>().GetBool("Eat") == false
        && Target.gameObject.layer == LayerMask.NameToLayer("Eat backward"))
        {
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = false;

            lastTarget = Target;

            transform.position = new Vector3(
                Target.transform.position.x,
                Target.transform.position.y + 0.6f,
                Target.transform.position.z);

            transform.rotation = Target.rotation;
            transform.Rotate(Vector3.up * 90);

            if (eating)
            {
                gameObject.GetComponent<Animator>().SetBool("Eat", true);
            }
            else
            {
                gameObject.GetComponent<Animator>().SetBool("Toillet", true);
            }
        }

        //Toillet
        if ((Vector3.Distance(transform.position, Target.position) < 1) && situp == false
            && gameObject.GetComponent<Animator>().GetBool("Toillet") == false
            && Target.gameObject.layer == LayerMask.NameToLayer("Toilet"))
        {
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = false;

            lastTarget = Target;

            transform.position = new Vector3(
                Target.transform.position.x,
                Target.transform.position.y,
                Target.transform.position.z);

            transform.rotation = Target.rotation;

            gameObject.GetComponent<Animator>().SetBool("Toillet", true);
        }

        //Teach
        if ((Vector3.Distance(transform.position, Target.position) < 1) && situp == false
        && gameObject.GetComponent<Animator>().GetBool("Teach") == false
        && Target.gameObject.layer == LayerMask.NameToLayer("Teach"))
        {
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = false;

            lastTarget = Target;

            transform.position = Target.position;


            transform.rotation = Target.rotation;

            gameObject.GetComponent<Animator>().SetBool("Teach", true);
        }

        //Fridge
        if ((Vector3.Distance(transform.position, Target.position) < 2.5) && situp == false
        && gameObject.GetComponent<Animator>().GetBool("Fridge") == false
        && Target.gameObject.layer == LayerMask.NameToLayer("Fridge"))
        {
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = false;

            lastTarget = Target;

            transform.position = Target.position;
            transform.rotation = Target.rotation;

            transform.Rotate(Vector3.up * -90);

            transform.Translate(Vector3.back * 1.1f);

            gameObject.GetComponent<Animator>().SetBool("Fridge", true);
        }

        //Microwave
        if ((Vector3.Distance(transform.position, Target.position) < 2) && situp == false
        && gameObject.GetComponent<Animator>().GetBool("microwave") == false
        && Target.gameObject.layer == LayerMask.NameToLayer("Microwave"))
        {
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = false;

            lastTarget = Target;

            transform.position = Target.position;

            transform.rotation = Target.rotation;
            transform.Rotate(Vector3.up * 180);
            transform.Translate(Vector3.back * 0.884f);
            transform.Translate(Vector3.down * 0.312f);

            Target.gameObject.SetActive(false);
            gameObject.GetComponent<Animator>().SetBool("microwave", true);
        }
    }

   public void TimeChange(int newtime = 0){
        timeNumber = newtime;
        gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
        situp = true;
        Target = goals[timeNumber];
        agent.destination = Target.position;
    }

    public void ChangeGoal(Transform newgoal = null)
    {
        if(!newgoal) Target = goals[timeNumber];
        else Target = newgoal;
        gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
        goal = newgoal;
        agent.destination = Target.position;
        situp = true;
    }
}