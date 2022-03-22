using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Rain : MonoBehaviour
{
    public Transform[] englishRooms;
    public Transform[] languageLabs;
    public Transform softSkills;
    public Transform[] projectRooms;
    public Transform[] Lunch;
    public Transform Auditorium;
    public Transform[] Toilettes;
    public GameObject[] toInit;
    int johnny = 0;
    int steph = 0;
    int alexandre = 0;
    int janka = 0;
    int nick = 0;
    int lindzy = 0;
    int eric =0;
    int lana =0;
    int sam =0;
    int basics =0;
    int maxNumber =0;
    public Transform recept;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Invocation", 5F);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Invocation(){
        for (int i = 0; i < johnny; i++){
                GameObject obj = Instantiate(toInit[0], new Vector3(Random.Range(recept.position.x-12, recept.position.x+12), recept.position.y,Random.Range(recept.position.z-12, recept.position.z+12)), Quaternion.identity) as GameObject;
                UnityEngine.AI.NavMeshAgent nobj = obj.GetComponent<UnityEngine.AI.NavMeshAgent>();
                nobj.speed = 5;
                nobj.destination = Auditorium.position;
                obj.transform.SetParent(gameObject.transform);
        }
        for (int i = 0; i < steph; i++){
                GameObject obj = Instantiate(toInit[1], new Vector3(Random.Range(recept.position.x-12, recept.position.x+12), recept.position.y,Random.Range(recept.position.z-12, recept.position.z+12)), Quaternion.identity) as GameObject;
                UnityEngine.AI.NavMeshAgent nobj = obj.GetComponent<UnityEngine.AI.NavMeshAgent>();
                nobj.speed = 5;
                nobj.destination = Auditorium.position;
                nobj.transform.SetParent(gameObject.transform);
        }
        for (int i = 0; i < alexandre; i++){
                GameObject obj = Instantiate(toInit[2], new Vector3(Random.Range(recept.position.x-12, recept.position.x+12), recept.position.y,Random.Range(recept.position.z-12, recept.position.z+12)), Quaternion.identity) as GameObject;
                UnityEngine.AI.NavMeshAgent nobj = obj.GetComponent<UnityEngine.AI.NavMeshAgent>();
                nobj.speed = 5;
                nobj.destination = Auditorium.position;
                obj.transform.SetParent(gameObject.transform);
        }
    }
}