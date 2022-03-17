using System.Collections;
using System.Collections.Generic;
using Unity;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
namespace Settings
{
    public class HeightSetting : MonoBehaviour
    {
        public bool isplus;

        public TMP_Text cHeight;

        Button button;

        float height;

        // Start is called before the first frame update
        void Start()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(ModifyHeight);
        }

        void ModifyHeight()
        {
            height += isplus ? 0.01f : -0.01f;
            cHeight.text = height.ToString() + " m";
        }


    }
}
