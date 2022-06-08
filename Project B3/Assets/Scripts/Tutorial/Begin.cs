using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace Tuto
{
    public class Begin : MonoBehaviour
    {
        public Canvas canvas;
        public Button play;
        public Canvas next;


        public void Start()
        {
            play.onClick.AddListener(delegate{Next();});
        }

        public void Next()
        {
            canvas.enabled = false;
            next.enabled = true;
        }


    }
}