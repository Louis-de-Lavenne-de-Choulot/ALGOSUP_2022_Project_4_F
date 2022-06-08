using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace Tuto
{
    public class Help : MonoBehaviour
    {
        public Button play;

        public void Start()
        {
            play.onClick.AddListener(delegate{Play();});
        }

        public void Play()
        {
            SceneManager.LoadScene(1,LoadSceneMode.Single);
        }


    }
}