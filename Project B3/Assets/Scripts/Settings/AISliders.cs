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
        private float previous;

        public void Start()
        {
            slider.onValueChanged.AddListener(delegate {tryIncreaseSlider();});
            increase.onClick.AddListener(delegate {updateSliderAndText(AIManager.trychange(target,1));});
            decrease.onClick.AddListener(delegate {updateSliderAndText(AIManager.trychange(target,-1));});
        }

        void tryIncreaseSlider()
        {
            int change = (int) (slider.value - previous);
            updateSliderAndText(AIManager.trychange(target,change *10));
        }
        void updateSliderAndText(int value)
        {
            textComponent.text = value.ToString();
            slider.value = value/10;
        }
    }
}
