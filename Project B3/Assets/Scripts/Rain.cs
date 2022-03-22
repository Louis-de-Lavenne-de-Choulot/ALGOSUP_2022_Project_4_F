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
    int day;
    int johnny; 
    int steph;
    int alexandre;
    int janka;
    int nick;
    int lindzy; 
    int eric;
    int lana;
    int sam;
    int maxNumber;
    int basics;
    public Transform recept;
    // Start is called before the first frame update
    void Start()
    {
        day = PlayerPrefs.GetInt("day", 0);
        johnny = PlayerPrefs.GetInt("Johnny", 0);
        steph = PlayerPrefs.GetInt("Steph", 0);
        alexandre = PlayerPrefs.GetInt("Alexandre", 0);
        janka = PlayerPrefs.GetInt("Janka", 0);
        nick = PlayerPrefs.GetInt("Nick", 0);
        lindzy = PlayerPrefs.GetInt("Lindzy", 0);
        eric = PlayerPrefs.GetInt("Eric", 0);
        lana = PlayerPrefs.GetInt("Lana", 0);
        sam = PlayerPrefs.GetInt("Sam", 0);
        maxNumber = PlayerPrefs.GetInt("Basic", 0);
        basics = maxNumber - (day + johnny + steph + alexandre + janka + nick + lindzy + eric + lana + sam);
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
    }
}