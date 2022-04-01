using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
public class Rain : MonoBehaviour
{
    public Transform trash;
    public Transform softSkills;
    List<Transform> sS = new List<Transform>();
    int[] sS2 = new int[5]{0,0,0,0,0};
    public Transform languageLabs;
    List<Transform> lL = new List<Transform>();
    int[] lL2 = new int[5]{0,0,0,0,0};
    public Transform Lunch;
    List<Transform> l = new List<Transform>();
    public Transform Auditorium;
    List<Transform> a = new List<Transform>();
    int[] a2 = new int[5]{0,0,0,0,0};
    public Transform[] englishRooms;
    List<Transform> eR = new List<Transform>();
    int[] eR2 = new int[5]{0,0,0,0,0};
    public Transform[] projectRooms;
    List<Transform> pR = new List<Transform>();
    int[] pR2 = new int[5]{0,0,0,0,0};
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
    Color[] Skin = new Color[4]{new Color(0.254717f, 0.1748036f, 0.08290314f), new Color(0.727f, 0.6063917f, 0.4154285f), new Color(0.1792453f, 0.07965653f, 0.03297437f), new Color(0.8235294f, 0.6969679f, 0.5583529f)};
    public Transform recept;
    int timeNumber = 0;
    int[] times = new int[8]{85, 100, 160, 280, 340, 355, 415, 440};

    private Personae basicsTT = new Personae('I', 'P', 'P', 'P', 'P', 'S', 'S', 'C', 'C', 'P', 'E');
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
        personaeNumber = new int[10]{basics, johnny, alexandre, sam, nick, denis, lana, steph, janka, lindzy};
        foreach(Transform findTrsfrm in languageLabs){
            if (findTrsfrm.name == "Chair"){
                lL.Add(findTrsfrm);
            }
        }
        foreach(Transform findTrsfrm in Auditorium){
                if (findTrsfrm.name == "Chair"){
                    a.Add(findTrsfrm);
                }
        }
        foreach(Transform findTrsfrm in softSkills){
            if (findTrsfrm.name == "Chair"){
                sS.Add(findTrsfrm);
            }
        }
        foreach(Transform englishRoom in englishRooms){
            foreach(Transform findTrsfrm in englishRoom){
                if (findTrsfrm.name == "Chair"){
                    eR.Add(findTrsfrm);
                }
            }
        }
        foreach(Transform projectRoom in projectRooms){
            foreach(Transform findTrsfrm in projectRoom){
                if (findTrsfrm.name == "Chair"){
                    pR.Add(findTrsfrm);
                }
            }
        }
        personaeNames = new Personae[10]{basicsTT, johnnyTT, alexandreTT, samTT, nickTT, denisTT, lanaTT, stephTT, jankaTT, lindzyTT};
        Invocation();
        InvokeRepeating("TimeCheck", 20f, 5f);
    }

    void Update(){
    }

    private void Invocation(){
        for (int persona = 0;  persona < 10; persona++){
            Personae p = personaeNames[persona];
            for (int i = 0; i < personaeNumber[persona]; i++){
                GameObject obj = Instantiate(toInit[persona], new Vector3(Random.Range(recept.position.x-12, recept.position.x+12), recept.position.y,Random.Range(recept.position.z-12, recept.position.z+12)), Quaternion.identity) as GameObject;
                Debug.Log(obj.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material);
                Color Sk = Skin[Random.Range(0,3)];
                int[] act = new int[]{Random.Range(0,3), Random.Range(4,5), Random.Range(6,7)};
                for (int child = 0; child < 8; child++){
                    obj.transform.GetChild(child).gameObject.SetActive(false);
                    if (child == act[0] || child == act[1] || child == act[2])
                        obj.transform.GetChild(child).gameObject.SetActive(true);
                }
                obj.transform.GetChild(act[0]).GetComponent<SkinnedMeshRenderer>().material.color =  Sk;
                if(persona < 5){
                    obj.transform.GetChild(act[2]).GetComponent<SkinnedMeshRenderer>().material.color =  Sk;
                }else{
                    obj.transform.GetChild(act[2]).GetComponent<SkinnedMeshRenderer>().materials[1].color =  Sk;
                }
                NPC script = obj.GetComponent<NPC>();
                script.goal = new Transform[11];
                System.Type type = p.GetType();
                for(int day = 1; day < 6;day++)
                {
                    char morning = (char)type.GetProperty("_morning" + day).GetValue(p);
                    char afternoon = (char)type.GetProperty("_afternoon" + day).GetValue(p);
                    if(morning == afternoon)
                    {
                        script.goal[day*2-1] = StartingDay(morning,day);
                        script.goal[day*2] = script.goal[day*2-1];
                        continue;
                    }
                    script.goal[day*2-1] = StartingDay(morning,day);
                    script.goal[day*2] = StartingDay(afternoon,day);

                }
                obj.transform.SetParent(gameObject.transform);
            }
        }
    }

    private Transform StartingDay(char moment, int numb){
        numb--;
        if (moment == 'E' && eR.Count > eR2[numb]){
            Transform temp = eR[eR2[numb]];
            eR2[numb]++;
            return temp;
        }
        else if(moment == 'P' && pR.Count > pR2[numb]){
            Transform temp = pR[pR2[numb]];
            pR2[numb]++;
            return temp;
        }
        else if(moment == 'S' && sS.Count > sS2[numb]){
            Transform temp = sS[sS2[numb]];
            sS2[numb]++;
            return temp;
        }
        else if(moment == 'C' && a.Count > a2[numb]){
            Transform temp = a[a2[numb]];
            a2[numb]++;
            return temp;
        }
        Debug.Log("trash");
        return trash;
    }

    void TimeCheck(){
        if (GameTime.intTimer > times[timeNumber]){
            for(int child = 0; child < transform.childCount; child++){
                transform.GetChild(child).GetComponent<NPC>().TimeChange();
            }
            timeNumber++;
            if (timeNumber+1%8 ==0){
                timeNumber = 0;
            }
        }
    }
}