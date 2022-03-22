using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Rain : MonoBehaviour
{
    public Transform[] englishRooms;
    List<Transform> eR;
    public Transform[] languageLabs;
    List<Transform> lL;
    public Transform softSkills;
    List<Transform> sS;
    public Transform[] projectRooms;
    Transform[] pR;
    public Transform[] Lunch;
    List<Transform> l;
    public Transform Auditorium;
    List<Transform> a;
    public Transform[] Toilettes;
    List<Transform> t;
    public GameObject[] toInit;
    Personae[] personaeNames;
    int[] personaeNumber;
    int day;
    int johnny; 
    int steph;
    int alexandre;
    int janka;
    int nick;
    int lindzy; 
    int denis;
    int lana;
    int sam;
    int maxNumber;
    int basics;
    public Transform recept;
    // Start is called before the first frame update
    void Start()
    {
        maxNumber = PlayerPrefs.GetInt("Basic", 0);
        day = PlayerPrefs.GetInt("day", 0);
        johnny = PlayerPrefs.GetInt("Johnny", 0);
        steph = PlayerPrefs.GetInt("Steph", 0);
        alexandre = PlayerPrefs.GetInt("Alexandre", 0);
        janka = PlayerPrefs.GetInt("Janka", 0);
        nick = PlayerPrefs.GetInt("Nick", 0);
        lindzy = PlayerPrefs.GetInt("Lindzy", 0);
        denis = PlayerPrefs.GetInt("Denis", 0);
        lana = PlayerPrefs.GetInt("Lana", 0);
        sam = PlayerPrefs.GetInt("Sam", 0);
        personaeNumber = new int[10]{johnny, steph, alexandre, janka, nick, lindzy, denis, lana, sam, maxNumber - (day + johnny + steph + alexandre + janka + nick + lindzy + denis + lana + sam)};
        foreach(Transform englishRoom in englishRooms){
            foreach(Transform findTrsfrm in englishRoom){
                if (findTrsfrm.name == "Chair_Conference"){
                    eR.Add(findTrsfrm);
                }
            }
        }

        Personae pComponent = gameObject.GetComponent<Personae>();
        personaeNames = new Personae[9]{pComponent.johnny, pComponent.steph, pComponent.alexandre, pComponent.janka, pComponent.nick, pComponent.lindzy, pComponent.denis, pComponent.lana, pComponent.sam};

        Invoke("Invocation", 5F);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Invocation(){
        for (int persona = 0;  persona <  10; persona++){
            Personae p = personaeNames[persona];
            for (int i = 0; i < personaeNumber[persona]; i++){
                GameObject obj = Instantiate(toInit[0], new Vector3(Random.Range(recept.position.x-12, recept.position.x+12), recept.position.y,Random.Range(recept.position.z-12, recept.position.z+12)), Quaternion.identity) as GameObject;
                UnityEngine.AI.NavMeshAgent nobj = obj.GetComponent<UnityEngine.AI.NavMeshAgent>();
                nobj.speed = 5;
                nobj.destination = Auditorium.position;//eR[persona].position;
                obj.transform.SetParent(gameObject.transform);
            }
        }
    }
}