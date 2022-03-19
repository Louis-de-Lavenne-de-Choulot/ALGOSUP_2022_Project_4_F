using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace Settings
{
    public class StartingMenu : MonoBehaviour
    {
        private enum Day
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
        }

        public Button next;
        public Button prev;
        public Button start;
        public TMP_Text text;

        private int current;

        public void Start()
        {
            next.onClick.AddListener(delegate{changeDay(1);});
            prev.onClick.AddListener(delegate{changeDay(-1);});
            start.onClick.AddListener(delegate{Launch();});
        }
        public void changeDay(int change)
        {
            current = (current + change) % 5;
            text.text = ((Day) current).ToString();
        }

        public void Launch()
        {
            PlayerPrefs.SetInt("day", 1 + current);
            SceneManager.LoadScene(1,LoadSceneMode.Single);
        }

    }
}