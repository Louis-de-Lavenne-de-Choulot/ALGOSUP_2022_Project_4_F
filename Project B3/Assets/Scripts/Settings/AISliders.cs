using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace AdvancedAI
{
    public class AISliders : MonoBehaviour
    {
        public Slider slider;
        public Button increase;
        public Button decrease;
        public string target;
        public TMP_Text textComponent;
        private int current;
        public void Start()
        {
            slider.onValueChanged.AddListener(delegate {updateSliderAndText(AIManager.trychange(target,(int)slider.value));});
            increase.onClick.AddListener(delegate {updateSliderAndText(AIManager.trychange(target,current + 1));});
            decrease.onClick.AddListener(delegate {updateSliderAndText(AIManager.trychange(target,current - 1));});
            slider.value = PlayerPrefs.GetInt(target);
        }

        void updateSliderAndText(int newvalue)
        {
            textComponent.text = newvalue.ToString();
            slider.value = newvalue;
            current = newvalue;
        }
    }
}
