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
        public Canvas canvas;
        public Button skip;

        public void Start()
        {
            skip.onClick.AddListener(delegate{Launch();});
        }

        public void Launch()
        {
            SceneManager.LoadScene(1,LoadSceneMode.Single);
        }


    }
}