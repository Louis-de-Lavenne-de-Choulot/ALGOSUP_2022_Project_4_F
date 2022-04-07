using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Rain : MonoBehaviour
{
    public Transform trash;
    public Transform[] englishRooms;
    List<Transform> eR = new List<Transform>();
    int[] eR2 = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public Transform languageLabs;
    List<Transform> lL = new List<Transform>();
    int[] lL2 = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public Transform softSkills;
    List<Transform> sS = new List<Transform>();
    int[] sS2 = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public Transform[] projectRooms;
    List<Transform> pR = new List<Transform>();
    int[] pR2 = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public Transform[] Lunch;
    List<Transform> l = new List<Transform>();
    public Transform Auditorium;
    List<Transform> a = new List<Transform>();
    int[] a2 = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public Transform[] Toilettes;
    List<Transform> t = new List<Transform>();
    public Transform[] TeachPlaces;
    public GameObject[] toInit;
    public GameObject[] toInitTeach;
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
    Color[] Skin = new Color[4] { new Color(0.254717f, 0.1748036f, 0.08290314f), new Color(0.727f, 0.6063917f, 0.4154285f), new Color(0.1792453f, 0.07965653f, 0.03297437f), new Color(0.8235294f, 0.6969679f, 0.5583529f) };
    int timeNumber = 0;
    int[] times = new int[8] {120, 150, 360, 540, 630, 690, 840, 900}; //? around 35s all AI are in their class. 70s of class then 30s of break, finally 70s for lunch. -1s to be sure the code takes the update.
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

    private char lunvch_kenny = 'I';

    private char lunvch_theresa = 'O';

    private char lunvch_louisa = 'I';

    private char lunvch_chad = 'I';

    private char lunvch_branden = 'O';

    ScenarioBase currentScenario;

    private int _day;
    private List<string> Schedule = new List<string>() { "Break", "Toilet Rush", "Break", "Toilet Rush", "Break", "Break", "Toilet Rush", "Break", "Break", "Break" };
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
        personaeNumber = new int[10] { johnny, steph, alexandre, janka, nick, lindzy, denis, lana, sam, basics };
        foreach (Transform englishRoom in englishRooms)
        {
            foreach (Transform findTrsfrm in englishRoom)
            {
                if (findTrsfrm.name == "Chair")
                {
                    eR.Add(findTrsfrm);
                }
            }
        }
        foreach (Transform findTrsfrm in languageLabs)
        {
            if (findTrsfrm.name == "Chair")
            {
                lL.Add(findTrsfrm);
            }
        }
        foreach (Transform findTrsfrm in softSkills)
        {
            if (findTrsfrm.name == "Chair")
            {
                sS.Add(findTrsfrm);
            }
        }
        foreach (Transform projectRoom in projectRooms)
        {
            foreach (Transform findTrsfrm in projectRoom)
            {
                if (findTrsfrm.name == "Chair")
                {
                    pR.Add(findTrsfrm);
                }
            }
        }
        foreach (Transform findTrsfrm in Auditorium)
        {
            if (findTrsfrm.name == "Chair")
            {
                findTrsfrm.position = findTrsfrm.GetComponent<Renderer>().bounds.center;
                a.Add(findTrsfrm);
            }
        }
        personaeNames = new Personae[9] { johnnyTT, stephTT, alexandreTT, jankaTT, nickTT, lindzyTT, denisTT, lanaTT, samTT };
        _day = PlayerPrefs.GetInt("day", 0);
        StartCoroutine(Teach());
        Invocation();
        InvokeRepeating("TimeCheck", 2f, 1f);
    }

    private IEnumerator Teach()
    {
        for (int i = 0; i < toInitTeach.Length; i++)
        {
            GameObject obj = Instantiate(toInitTeach[i], new Vector3(Random.Range(recept.position.x - 20, recept.position.x + 20), recept.position.y, Random.Range(recept.position.z - 10, recept.position.z + 10)), Quaternion.identity) as GameObject;
            Color Sk = Skin[Random.Range(0, 4)];
            int[] act = new int[] { Random.Range(0, 4), 4, Random.Range(5, 7) };
            for (int child = 0; child < 7; child++)
            {
                obj.transform.GetChild(child).gameObject.SetActive(false);
                if (child == act[0] || child == act[1] || child == act[2])
                    obj.transform.GetChild(child).gameObject.SetActive(true);
            }
            obj.transform.GetChild(act[0]).GetComponent<SkinnedMeshRenderer>().material.color = Sk;
            if (i > 2)
            {
                obj.transform.GetChild(act[2]).GetComponent<SkinnedMeshRenderer>().material.color = Sk;
            }
            else
            {
                obj.transform.GetChild(act[2]).GetComponent<SkinnedMeshRenderer>().materials[1].color = Sk;
            }
            NPC script = obj.GetComponent<NPC>();
            script.goals = new Transform[10] { TeachPlaces[i], TeachPlaces[i], TeachPlaces[i], TeachPlaces[i], TeachPlaces[i], TeachPlaces[i], TeachPlaces[i], TeachPlaces[i], TeachPlaces[i], TeachPlaces[i] };
        }
        yield return null;
    }

    private void Invocation()
    {
        for (int persona = 0; persona < 9; persona++)
        {
            Personae p = personaeNames[persona];
            for (int i = 0; i < personaeNumber[persona]; i++)
            {
                StartCoroutine(InvocationCorou(persona, p));
            }
        }
    }

    private IEnumerator InvocationCorou(int persona, Personae p)
    {
        GameObject obj = Instantiate(toInit[persona], new Vector3(Random.Range(recept.position.x - 22, recept.position.x + 22), recept.position.y, Random.Range(recept.position.z - 14, recept.position.z + 14)), Quaternion.identity) as GameObject;
        Color Sk = Skin[Random.Range(0, 4)];
        int[] act = new int[] { Random.Range(0, 4), 4, Random.Range(5, 7) };
        for (int child = 0; child < 7; child++)
        {
            obj.transform.GetChild(child).gameObject.SetActive(false);
            if (child == act[0] || child == act[1] || child == act[2])
                obj.transform.GetChild(child).gameObject.SetActive(true);
        }
        obj.transform.GetChild(act[0]).GetComponent<SkinnedMeshRenderer>().material.color = Sk;
        if ((persona + 1) % 2 != 0)
        {
            obj.transform.GetChild(act[2]).GetComponent<SkinnedMeshRenderer>().material.color = Sk;
        }
        else
        {
            obj.transform.GetChild(act[2]).GetComponent<SkinnedMeshRenderer>().materials[1].color = Sk;
        }
        NPC script = obj.GetComponent<NPC>();
        script.goals = new Transform[10];
        System.Type type = p.GetType();
        for (int day = 0; day < 5; day++)
        {
            char morning = (char)type.GetProperty("_morning" + day).GetValue(p);
            char afternoon = (char)type.GetProperty("_afternoon" + day).GetValue(p);
            script.goals[day * 2] = StartingDay(morning, day);
            script.goals[day * 2 + 1] = StartingDay(afternoon, day + 5);
        }
        script.lunch = p._lunch;
        obj.transform.SetParent(gameObject.transform);
        yield return null;
    }

    private Transform StartingDay(char moment, int numb)
    {
        if (moment == 'E' && eR.Count > eR2[numb])
        {
            Transform temp = eR[eR2[numb]];
            eR2[numb]++;
            return temp;
        }
        else if (moment == 'P' && pR.Count > pR2[numb])
        {
            Transform temp = pR[pR2[numb]];
            pR2[numb]++;
            return temp;
        }
        else if (moment == 'S' && sS.Count > sS2[numb])
        {
            Transform temp = sS[sS2[numb]];
            sS2[numb]++;
            return temp;
        }
        else if (moment == 'C' && a.Count > a2[numb])
        {
            Transform temp = a[a2[numb]];
            a2[numb]++;
            return temp;
        }
        return trash;
    }

    void TimeCheck()
    {
        Debug.Log(GameTime.intTimer);
        if (GameTime.intTimer > times[timeNumber])
        {
            timeNumber++;
            if (timeNumber == 7)
            {
                if(_day == 4)
                {
                    SceneManager.LoadScene(0,LoadSceneMode.Single);
                }
                _day++;
                PlayerPrefs.SetInt("day", _day);
                timeNumber = 0;
                GameTime.intTimer = 0;
            }
            switch (timeNumber)
            {
                case 1:
                    Debug.Log($"{Schedule[_day*2]}");
                    currentScenario = GameObject.Find($"{Schedule[_day*2]}").GetComponent<ScenarioBase>();
                    currentScenario.StartScenario();
                    break;
                case 3:
                    currentScenario = GameObject.Find("Lunch").GetComponent<ScenarioBase>();
                    currentScenario.StartScenario();
                    break;
                case 5:
                    currentScenario = GameObject.Find($"{Schedule[_day*2+1]}").GetComponent<ScenarioBase>();
                    currentScenario.StartScenario();
                    break;
                case 7:
                    currentScenario = GameObject.Find("Return Home").GetComponent<ScenarioBase>();
                    currentScenario.StartScenario();
                    break;
                default:
                    currentScenario.EndScenario();
                    for (int child = 0; child < transform.childCount; child++)
                    {
                        NPC npc = transform.GetChild(child).GetComponent<NPC>();
                        if (!npc.inScenario) npc.TimeChange(timeNumber > 3 ? 2 * _day : _day * 2 + 1);
                    }
                    break;
            }

            if (timeNumber == 7)
            {
                if(_day == 4)
                {
                    SceneManager.LoadScene(0,LoadSceneMode.Single);
                }
                _day++;
                PlayerPrefs.SetInt("day", _day);
                timeNumber = 0;
                GameTime.intTimer = 0;
            }
        }
    }

}