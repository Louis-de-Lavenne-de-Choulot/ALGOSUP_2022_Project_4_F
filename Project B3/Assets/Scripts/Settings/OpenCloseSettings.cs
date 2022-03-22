using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OVR;

namespace Settings
{
    public class OpenCloseSettings : MonoBehaviour
    {
        public GameObject rightHand;
        public int distance;

        public GameObject menu;
        public Button button;

        void Start()
        {
            button.onClick.AddListener(delegate{CloseSettingsMenu();});
        }

        void Update()
        {
            OVRInput.Update();
            if(OVRInput.Get(OVRInput.RawButton.A))
            {
                OpenSettingsMenu();
            }
        }

        void OpenSettingsMenu()
        {
            Transform rightHandTransform = rightHand.transform;

            Vector3 direction = rightHandTransform.forward;
            menu.transform.rotation = Quaternion.LookRotation(direction);

            Vector3 newPos = rightHandTransform.position + (direction * distance);
            menu.transform.position = newPos;
            menu.SetActive(true);

        }

        void CloseSettingsMenu()
        {
            menu.SetActive(false);
        }
    }
}