using System.Collections;
using System.Collections.Generic;
using Unity;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
namespace Settings
{
    public class HeightSettings : MonoBehaviour
    {
        public TMP_Text cHeight;
        public Button plus;
        public Button minus;
        public CharacterCameraConstraint ccamera;
        float height;



        // Start is called before the first frame update
        void Start()
        {
            height = PlayerPrefs.GetFloat("Height",1.8f);
            cHeight.text = height.ToString()+ " m";
            plus.onClick.AddListener(delegate { ModifyHeight(true); });
            minus.onClick.AddListener(delegate { ModifyHeight(false); });

        }

        void ModifyHeight(bool isplus)
        {
            height += isplus ? 0.01f : -0.01f;
            cHeight.text = height.ToString() + " m";
            ccamera.HeightOffset = height - 1;
            PlayerPrefs.SetFloat("Height", height);
        }


    }
}
