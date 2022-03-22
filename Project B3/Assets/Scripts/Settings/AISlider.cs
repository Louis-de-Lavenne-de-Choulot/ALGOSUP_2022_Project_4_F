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
        public void Start()
        {
            increase.onClick.AddListener(delegate{tryincrement(true);});
            decrease.onClick.AddListener(delegate{tryincrement(false);});
        }

        public bool tryincrement(bool positive)
        {
            if (positive && slider.value != slider.maxValue)
            {
                slider.value++;
                return true;
            }
            if (!positive && slider.value != slider.minValue)
            {
                slider.value--;
                return true;
            }
                return false;
        }
    }
}
