using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Rain : MonoBehaviour
{
    public Transform trash;
    public Transform[] englishRooms;
    List<Transform> eR = new List<Transform>();
    int[] eR2 = new int[5]{0,0,0,0,0};
    public Transform[] languageLabs;
    List<Transform> lL = new List<Transform>();
    int[] lL2 = new int[5]{0,0,0,0,0};
    public Transform softSkills;
    List<Transform> sS = new List<Transform>();
    int[] sS2 = new int[5]{0,0,0,0,0};
    public Transform[] projectRooms;
    List<Transform> pR = new List<Transform>();
    int[] pR2 = new int[5]{0,0,0,0,0};
    public Transform[] Lunch;
    List<Transform> l = new List<Transform>();
    public Transform Auditorium;
    List<Transform> a = new List<Transform>();
    int[] a2 = new int[5]{0,0,0,0,0};
    public Transform[] Toilettes;
    List<Transform> t = new List<Transform>();
    public GameObject[] toInit;
    Personae[] personaeNames;
    int[] personaeNumber;
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
        maxNumber = 160;//PlayerPrefs.GetInt("MaxAi", 0);
        johnny = 57;// PlayerPrefs.GetInt("Johnny", 0);
        steph = 44; //PlayerPrefs.GetInt("Steph", 0);
        alexandre = 22; //PlayerPrefs.GetInt("Alexandre", 0);
        janka = 40; //PlayerPrefs.GetInt("Janka", 0);
        nick = PlayerPrefs.GetInt("Nick", 0);
        lindzy = PlayerPrefs.GetInt("Lindzy", 0);
        denis = PlayerPrefs.GetInt("Denis", 0);
        lana = PlayerPrefs.GetInt("Lana", 0);
        sam = PlayerPrefs.GetInt("Sam", 0);
        basics = PlayerPrefs.GetInt("Basic", 0);
        personaeNumber = new int[10]{johnny, steph, alexandre, janka, nick, lindzy, denis, lana, sam, basics};
        foreach(Transform englishRoom in englishRooms){
            foreach(Transform findTrsfrm in englishRoom){
                if (findTrsfrm.name == "Chair"){
                    eR.Add(findTrsfrm);
                }
            }
        }
        foreach(Transform findTrsfrm in languageLabs){
            if (findTrsfrm.name == "Chair"){
                lL.Add(findTrsfrm);
            }
        }
        foreach(Transform findTrsfrm in softSkills){
            if (findTrsfrm.name == "Chair"){
                sS.Add(findTrsfrm);
            }
        }
        foreach(Transform projectRoom in projectRooms){
            foreach(Transform findTrsfrm in projectRoom){
                if (findTrsfrm.name == "Chair"){
                    pR.Add(findTrsfrm);
                }
            }
        }
        foreach(Transform findTrsfrm in Auditorium){
                if (findTrsfrm.name == "Chair"){
                    a.Add(findTrsfrm);
                }
        }
        foreach(Transform findTrsfrm in Lunch){
                if (findTrsfrm.name == "Chair"){
                    l.Add(findTrsfrm);
                }
        }
        personaeNames = new Personae[9]{johnnyTT, stephTT, alexandreTT, jankaTT, nickTT, lindzyTT, denisTT, lanaTT, samTT};
        Invocation();
    }

    void Update(){
    }

    private void Invocation(){
        for (int persona = 0;  persona < 9; persona++){
            Personae p = personaeNames[persona];
            for (int i = 0; i < personaeNumber[persona]; i++){
                GameObject obj = Instantiate(toInit[persona], new Vector3(Random.Range(recept.position.x-12, recept.position.x+12), recept.position.y,Random.Range(recept.position.z-12, recept.position.z+12)), Quaternion.identity) as GameObject;
                NPC script = obj.GetComponent<NPC>();
                script.goal = new Vector3[11];
                for (int day = 1; day < 6; day++){
                    switch(day){
                        case 5:
                            if (p._morning5 == p._afternoon5){
                                script.goal[day*2-1] = StartingDay(p._morning5, day);
                                script.goal[day*2] =  script.goal[day*2-1];
                            }else{
                                script.goal[day*2-1] = StartingDay(p._morning5, day);
                                script.goal[day*2] =  StartingDay(p._afternoon5, day);
                            }
                            break;
                        case 4:
                            if (p._morning4 == p._afternoon4){
                                script.goal[day*2-1] = StartingDay(p._morning4, day);
                                script.goal[day*2] =  script.goal[day*2-1];
                            }else{
                                script.goal[day*2-1] = StartingDay(p._morning4, day);
                                script.goal[day*2] =  StartingDay(p._afternoon4, day);
                            }
                            break;
                        case 3:
                            if (p._morning3 == p._afternoon3){
                                script.goal[day*2-1] = StartingDay(p._morning3, day);
                                script.goal[day*2] =  script.goal[day*2-1];
                            }else{
                                script.goal[day*2-1] = StartingDay(p._morning3, day);
                                script.goal[day*2] =  StartingDay(p._afternoon3, day);
                            }
                            break;
                        case 2:
                            if (p._morning2 == p._afternoon2){
                                script.goal[day*2-1] = StartingDay(p._morning2, day);
                                script.goal[day*2] =  script.goal[day*2-1];
                            }else{
                                script.goal[day*2-1] = StartingDay(p._morning2, day);
                                script.goal[day*2] =  StartingDay(p._afternoon2, day);
                            }
                            break;
                        default :
                            if (p._morning1 == p._afternoon1){
                                script.goal[day*2-1] = StartingDay(p._morning1, day);
                                script.goal[day*2] =  script.goal[day*2-1];
                            }else{
                                script.goal[day*2-1] = StartingDay(p._morning1, day);
                                script.goal[day*2] =  StartingDay(p._afternoon1, day);
                            }
                            break;
                    }
                }
                obj.transform.SetParent(gameObject.transform);
            }
        }
    }

    private Vector3 StartingDay(char moment, int numb){
        numb--;
        if (moment == 'E' && eR.Count > eR2[numb]){
            Vector3 temp = eR[eR2[numb]].position;
            eR2[numb]++;
            return temp;
        }
        else if(moment == 'P' && pR.Count > pR2[numb]){
            Vector3 temp = pR[pR2[numb]].position;
            pR2[numb]++;
            return temp;
        }
        else if(moment == 'S' && sS.Count > sS2[numb]){
            Vector3 temp = sS[sS2[numb]].position;
            sS2[numb]++;
            return temp;
        }
        else if(moment == 'C' && a.Count > a2[numb]){
            Vector3 temp = a[a2[numb]].position;
            a2[numb]++;
            return temp;                         
        }
        Debug.Log("trash");
        return trash.position;
    }
}