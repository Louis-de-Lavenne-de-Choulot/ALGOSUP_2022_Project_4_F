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
        public GameObject[] canvas;
        public Button[] play;
        int iter = 0;


        public void Start()
        {
            for (int i = 0; i < play.Length; i++)
            {
                canvas[i+1].SetActive(false);
                play[i].onClick.AddListener(delegate { Next(); });
            }
        }

        public void Next()
        {
            canvas[iter].SetActive(false);
            canvas[iter+1].SetActive(true);
            iter++;
        }


    }
}