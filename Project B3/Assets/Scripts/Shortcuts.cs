using UnityEngine;
using UnityEngine.SceneManagement;
public class Shortcuts : MonoBehaviour
{
    private float resetvalue = 999999f;
    private float threshold = 3f;
    private float xtime;
    private float ytime;
    OVRManager manager;
    [SerializeField]
    Transform Spawn;
    [SerializeField]
    Rigidbody body;

    void Update()
    {
        OVRInput.Update();
        if(OVRInput.GetDown(OVRInput.RawButton.X))
        {
            xtime = Time.time;
        }
        if(OVRInput.GetDown(OVRInput.RawButton.Y))
        {
            ytime = Time.time;
        }
        if(Time.time - xtime > threshold - 0.2f && Time.time - ytime > threshold - 0.2f)
        {
            xtime = resetvalue;
            ytime = resetvalue;
            MainMenu();
        }

        if(OVRInput.GetUp(OVRInput.RawButton.X))
        {
            xtime = resetvalue;
            Pause();
        }
        if(OVRInput.GetUp(OVRInput.RawButton.Y))
        {
            ytime = resetvalue;
        }

        if(Time.time - xtime > 3f)
        {
            xtime = resetvalue;
            Respawn();
        }
        if(Time.time - ytime > 3f)
        {
            ytime = resetvalue;
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