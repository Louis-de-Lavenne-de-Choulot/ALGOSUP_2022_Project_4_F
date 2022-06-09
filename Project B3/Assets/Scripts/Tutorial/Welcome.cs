using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace Tuto {
    public class Welcome: MonoBehaviour {
        public Button[] skip;
        public GameObject cam;
        public GameObject maincam;

        public void Start() {
            for (int i = 0; i < skip.Length; i++) {
                skip[i].onClick.AddListener(delegate {
                    Launch();
                });
            }
        }

        public void Launch() {
            maincam.SetActive(false);
            cam.SetActive(true);
            // maincam.clearFlags = CameraClearFlags.SolidColor;
            // maincam.backgroundColor = Color.black;
            // maincam.cullingMask = 0;
            StartCoroutine(loading());
        }
        IEnumerator loading() {
            //returning 0 will make it wait 1 frame
            yield
            return 0;
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }


    }
}