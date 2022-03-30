using UnityEngine;
using UnityEngine.SceneManagement;
public class Shortcuts : MonoBehaviour
{
    private float threshold = 3f;
    private float xtime = 3f;
    private bool lockx = false;
    private float ytime = 3f;
    private bool locky = false;
    [SerializeField]
    OVRManager manager;
    [SerializeField]
    Transform Spawn;
    [SerializeField]
    Rigidbody body;

    void Update()
    {
        OVRInput.Update();
        if(OVRInput.Get(OVRInput.Button.Three))
        {
            xtime -= Time.deltaTime;
        }
        else
        {
            if(xtime > 0f) Pause();
            xtime = threshold;
            lockx = false;
        }
        if(OVRInput.Get(OVRInput.Button.Four))
        {
            ytime -= Time.deltaTime;
        }
        else
        {
            ytime = threshold;
            locky = false;
        }
        if(xtime < 0.2f && ytime < 0.2f)
        {
            xtime = threshold;
            ytime = threshold;
            lockx = true;
            locky = true;
            MainMenu();
        }
        if(!lockx && xtime < 0f)
        {
            lockx = true;
            Respawn();
        }
        if(!locky && ytime < 0f)
        {
            locky = true;
            ExitScenario();
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