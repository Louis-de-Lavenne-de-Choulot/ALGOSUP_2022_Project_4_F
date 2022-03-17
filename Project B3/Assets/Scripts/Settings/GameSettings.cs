using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Settings
{

    public class GameSettings : MonoBehaviour
    {

        public GameObject Player;
        public void Respawn()
        {
            if (SceneManager.GetActiveScene().name == "Main Menu")
            {
                Player.transform.SetPositionAndRotation(Vector3.zero,Quaternion.identity);
            }
            else
            {
                Player.transform.SetPositionAndRotation(Vector3.zero,Quaternion.identity);
            }
        }

        public void ReturnToMenu()
        {
            if(SceneManager.GetActiveScene().name != "Main Menu")
            {
                SceneManager.LoadScene("Main Menu");
            }
        }

        public void StopScenario()
        {
            return;
        }
    }
}
