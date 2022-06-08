using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace Tuto {
    public class Language: MonoBehaviour {
        public GameObject[] en;
        public GameObject[] fr;
        public Button engbtn;

        // Start is called before the first frame update
        void Start() {
            engbtn.onClick.AddListener(delegate {
                LanguageUpdate();
            });
        }

        // Update is called once per frame
        void LanguageUpdate() {
            for (int i = 0; i < en.Length; i++) {
                en[i].gameObject.SetActive(true);
                fr[i].gameObject.SetActive(false);
            }
        }
    }
}