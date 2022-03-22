using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Settings
{
    public class SettingsTabToggles : MonoBehaviour
    {
        Toggle button;
        public GameObject tab;

        void Start()
        {
            button = GetComponent<Toggle>();
            tab.SetActive(button.isOn);
            button.onValueChanged.AddListener(delegate { UpdateTab(); });
        }

        void UpdateTab()
        {
            tab.SetActive(button.isOn);
        }

    }
}