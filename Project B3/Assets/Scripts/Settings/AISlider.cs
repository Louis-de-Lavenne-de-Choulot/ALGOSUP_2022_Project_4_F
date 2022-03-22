using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace AdvancedAI
{
    public class AISlider : MonoBehaviour
    {
        public Slider slider;
        public Button increase;
        public Button decrease;
        public string target;
        public TMP_Text textComponent;
        public int current;
        public void Start()
        {
            current = PlayerPrefs.GetInt(target);
            slider.SetValueWithoutNotify(current);
            slider.onValueChanged.AddListener(delegate {updateSliderAndText(AIManager.trychange(target,current,(int)slider.value));});
            increase.onClick.AddListener(delegate {updateSliderAndText(AIManager.trychange(target,current,current + 1));});
            decrease.onClick.AddListener(delegate {updateSliderAndText(AIManager.trychange(target,current,current - 1));});
        }

        void updateSliderAndText(int newvalue)
        {
            textComponent.text = newvalue.ToString();
            slider.SetValueWithoutNotify(newvalue);
            current = newvalue;
        }
    }
}
