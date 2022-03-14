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

        // Start is called before the first frame update
        void Start()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(ModifyHeight);
        }

        void ModifyHeight()
        {
            float iHeight = float.Parse(cHeight.text);
            iHeight += isplus ? 0.01f : -0.01f;
            cHeight.text = iHeight.ToString();
        }


    }
}
