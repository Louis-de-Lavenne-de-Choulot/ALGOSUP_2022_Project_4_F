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
    int basics;
    int maxNumber;
    public Transform recept;
    public GameObject vv;
    // G = get/order food, O = outside, I = inside, B = bring his meal
    private Personae johnnyTT = new Personae('G', 'E', 'P', 'S', 'S', 'P', 'P', 'C', 'C', 'P', 'P');

    private Personae stephTT = new Personae('I', 'C', 'C', 'E', 'P', 'S', 'S', 'P', 'P', 'P', 'P');

    private Personae alexandreTT = new Personae('O', 'P', 'P', 'P', 'E', 'P', 'P', 'S', 'S', 'C', 'C');

    private Personae jankaTT = new Personae('O', 'S', 'S', 'C', 'C', 'P', 'E', 'P', 'P', 'P', 'P');

    private Personae nickTT = new Personae('B', 'P', 'P', 'P', 'P', 'C', 'C', 'P', 'E', 'S', 'S');

    private Personae lindzyTT = new Personae('G', 'P', 'E', 'C', 'C', 'S', 'S', 'P', 'P', 'P', 'P');

    private Personae lanaTT = new Personae('O', 'S', 'S', 'P', 'P', 'C', 'C', 'E', 'P', 'P', 'P');

    private Personae denisTT = new Personae('I', 'C', 'C', 'S', 'S', 'E', 'P', 'P', 'P', 'P', 'E');

    private Personae samTT = new Personae('I', 'P', 'P', 'P', 'P', 'S', 'S', 'C', 'C', 'P', 'E');

    // Start is called before the first frame update
    void Start()
    {
        maxNumber = PlayerPrefs.GetInt("MaxAi", 0);
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
        basics = PlayerPrefs.GetInt("Basic", 0);
        personaeNumber = new int[10]{johnny, steph, alexandre, janka, nick, lindzy, denis, lana, sam, basics};
        foreach(Transform englishRoom in englishRooms){
            foreach(Transform findTrsfrm in englishRoom){
                if (findTrsfrm.name == "Chair_Conference"){
                    eR.Add(findTrsfrm);
                }
            }
        }
        personaeNames = new Personae[9]{johnnyTT, stephTT, alexandreTT, jankaTT, nickTT, lindzyTT, denisTT, lanaTT, samTT};

        Invoke("Invocation", 5F);
    }

    private void Invocation(){
        for (int persona = 0;  persona <  10; persona++){
            Personae p = personaeNames[persona];
            for (int i = 0; i < personaeNumber[persona]; i++){
                GameObject obj = Instantiate(toInit[0], new Vector3(Random.Range(recept.position.x-12, recept.position.x+12), recept.position.y,Random.Range(recept.position.z-12, recept.position.z+12)), Quaternion.identity) as GameObject;
                UnityEngine.AI.NavMeshAgent nobj = obj.GetComponent<UnityEngine.AI.NavMeshAgent>();
                nobj.destination = eR[persona].position;
                obj.transform.SetParent(gameObject.transform);
            }
        }
    }
}