using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Settings
{

    public class GameSettings : MonoBehaviour
    {
        public void Respawn()
        {
            if (SceneManager.GetActiveScene().name != "Main Menu")
            {
                return;
            }
            return;
        }

        public void ReturnToMenu()
        {
            return;
        }

        public void StopScenario()
        {
            return;
        }
    }
}
