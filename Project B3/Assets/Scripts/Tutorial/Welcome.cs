using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace Tuto
{
    public class Welcome : MonoBehaviour
    {
        public Button skip;
        public Camera cam;
        public Camera maincam;

        public void Start()
        {
            skip.onClick.AddListener(delegate{Launch();});
        }

        public void Launch()
        {
            for (int i = 0; i < Camera.allCameras.Length; i++)
            {
                Camera.allCameras[i].enabled = false;
            }
            cam.enabled = true;
            SceneManager.LoadScene(1,LoadSceneMode.Single);
        }


    }
}