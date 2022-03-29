using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Rain : MonoBehaviour
{
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
        maxNumber = PlayerPrefs.GetInt("MaxAi", 0);
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
                if (findTrsfrm.name == "chair"){
                    eR.Add(findTrsfrm);
                }
            }
        }
        foreach(Transform languageLab in languageLabs){
            foreach(Transform findTrsfrm in languageLab){
                if (findTrsfrm.name == "chair"){
                    lL.Add(findTrsfrm);
                }
            }
        }
        foreach(Transform softSkill in softSkills){
            foreach(Transform findTrsfrm in softSkill){
                if (findTrsfrm.name == "chair"){
                    sS.Add(findTrsfrm);
                }
            }
        }
        foreach(Transform projectRoom in projectRooms){
            foreach(Transform findTrsfrm in projectRoom){
                if (findTrsfrm.name == "chair"){
                    pR.Add(findTrsfrm);
                }
            }
        }
        foreach(Transform findTrsfrm in Auditorium){
                if (findTrsfrm.name == "chair"){
                    a.Add(findTrsfrm);
                }
        }
        foreach(Transform findTrsfrm in Lunch){
                if (findTrsfrm.name == "chair"){
                    l.Add(findTrsfrm);
                }
        }
        personaeNames = new Personae[9]{johnnyTT, stephTT, alexandreTT, jankaTT, nickTT, lindzyTT, denisTT, lanaTT, samTT};
        Invocation();
    }

    void Update(){
    }

    private void Invocation(){
        for (int persona = 0;  persona <  10; persona++){
            Personae p = personaeNames[persona];
            for (int i = 0; i < personaeNumber[persona]; i++){
                GameObject obj = Instantiate(toInit[persona], new Vector3(Random.Range(recept.position.x-12, recept.position.x+12), recept.position.y,Random.Range(recept.position.z-12, recept.position.z+12)), Quaternion.identity) as GameObject;
                NPC script = obj.GetComponent<NPC>();
                for (int day = 1; day < 6; day++){
                    switch(day){
                        case 5:
                            script.goal[day*2-1] = StartingDay(p._morning5, day);
                            script.goal[day*2] =  StartingDay(p._afternoon5, day);
                            break;
                        case 4:
                            script.goal[day*2-1] = StartingDay(p._morning4, day);
                            script.goal[day*2] =  StartingDay(p._afternoon4, day);
                            break;
                        case 3:
                            script.goal[day*2-1] = StartingDay(p._morning3, day);
                            script.goal[day*2] =  StartingDay(p._afternoon3, day);
                            break;
                        case 2:
                            script.goal[day*2-1] = StartingDay(p._morning2, day);
                            script.goal[day*2] =  StartingDay(p._afternoon2, day);
                            break;
                        default :
                            script.goal[day*2-1] = StartingDay(p._morning1, day);
                            script.goal[day*2] =  StartingDay(p._afternoon1, day);
                            break;
                    }
                }
                obj.transform.SetParent(gameObject.transform);
            }
        }
    }

    private Vector3 StartingDay(char moment, int numb){
        if (moment == 'E' && eR != null){
            eR2[numb]++;
            return eR[eR2[numb]].position;
        }
        else if(moment == 'P' && pR != null){
            pR2[numb]++;
            return pR[pR2[numb]].position;
        }
        else if(moment == 'S' && sS != null){
            sS2[numb]++;
            return sS[sS2[numb]].position;
        }
        else if(moment == 'C' && a != null){
            return a[a2[numb]].position;                         
        }
        return new Vector3();
    }
}