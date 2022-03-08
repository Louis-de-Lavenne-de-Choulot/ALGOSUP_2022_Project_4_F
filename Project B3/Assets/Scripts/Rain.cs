using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Rain : MonoBehaviour
{
    public Transform[] englishRooms;
    public Transform[] languageLabs;
    public Transform[] softSkills;
    public Transform[] projectRooms;
    public Transform[] Lunch;
    public Transform Auditorium;
    public Transform[] Toilettes;
    public GameObject[] toInit;
    public int Number_of_Johnny;
    public int Number_of_Steph;
    public int Number_of_Alexandre;
    public int Number_of_Janka;
    public int Number_of_Nick;
    public int Number_of_Lindzy;
    public int Number_of_Eric;
    public int Number_of_Lana;
    public int Number_of_Sam;
    public int Number_of_Basics;
    public int maxNumber;
    public Transform recept;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Invocation", 2F);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Invocation(){
        for (int i = 0; i < Number_of_Johnny; i++){
                GameObject obj = Instantiate(toInit[0], new Vector3(Random.Range(recept.position.x-12, recept.position.x+12), recept.position.y,Random.Range(recept.position.z-12, recept.position.z+12)), Quaternion.identity) as GameObject;
                UnityEngine.AI.NavMeshAgent nobj = obj.GetComponent<UnityEngine.AI.NavMeshAgent>();
                nobj.speed = 5;
                nobj.destination = Auditorium.position;
                obj.transform.SetParent(gameObject.transform);
        }
        for (int i = 0; i < Number_of_Steph; i++){
                GameObject obj = Instantiate(toInit[1], new Vector3(Random.Range(recept.position.x-12, recept.position.x+12), recept.position.y,Random.Range(recept.position.z-12, recept.position.z+12)), Quaternion.identity) as GameObject;
                UnityEngine.AI.NavMeshAgent nobj = obj.GetComponent<UnityEngine.AI.NavMeshAgent>();
                nobj.speed = 5;
                nobj.destination = Auditorium.position;
                nobj.transform.SetParent(gameObject.transform);
        }
        for (int i = 0; i < Number_of_Alexandre; i++){
                GameObject obj = Instantiate(toInit[2], new Vector3(Random.Range(recept.position.x-12, recept.position.x+12), recept.position.y,Random.Range(recept.position.z-12, recept.position.z+12)), Quaternion.identity) as GameObject;
                UnityEngine.AI.NavMeshAgent nobj = obj.GetComponent<UnityEngine.AI.NavMeshAgent>();
                nobj.speed = 5;
                nobj.destination = Auditorium.position;
                obj.transform.SetParent(gameObject.transform);
        }
    }
}