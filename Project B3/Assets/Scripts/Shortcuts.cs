using UnityEngine;
using UnityEngine.SceneManagement;
public class Shortcuts : MonoBehaviour
{
    private float threshold = 3f;
    private float xtime;
    private bool lockx;
    private float ytime;
    private bool locky;
    [SerializeField]
    Transform Spawn;
    Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        xtime = 3f;
        ytime = 3f;
        lockx = false;
        locky = false;
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Three)) xtime = threshold;
        if (OVRInput.GetDown(OVRInput.Button.Four)) ytime = threshold;
        if (OVRInput.GetUp(OVRInput.Button.Three) && xtime > 0f) Pause();
        if (OVRInput.Get(OVRInput.Button.Three)) xtime -= Time.deltaTime;
        if (OVRInput.Get(OVRInput.Button.Four)) ytime -= Time.deltaTime;
        if (!lockx && xtime < 0f) Respawn();
        if (!locky && ytime < 0f) ExitScenario();
        if (OVRInput.Get(OVRInput.Button.Three) &&
            OVRInput.Get(OVRInput.Button.Four) &&
            xtime < 0.2f && ytime < 0.2f)
        {
            xtime = threshold;
            ytime = threshold;
            lockx = true;
            locky = true;
            MainMenu();
        }
    }
    void MainMenu()
    {
        SceneManager.LoadSceneAsync(0,LoadSceneMode.Single);
    }

    void Pause()
    {
        if (Time.timeScale == 0) Time.timeScale = 1;
        else Time.timeScale = 0;
    }

    void Respawn()
    {
        body.position = Spawn.position;
    }

    void ExitScenario()
    {
        //Hello programmer
    }
}

// x tap PauseTime
// x hold Respawn
// y hold exit scenario
// x + y retour mainmenu