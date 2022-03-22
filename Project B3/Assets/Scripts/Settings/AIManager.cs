using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace AdvancedAI
{
    public class AIManager : MonoBehaviour
    {
        public Slider slider;
        public TMP_Text text;
        public List<AISlider> amounts;
        static int maxAI;
        static int current;
        static string[] AIList = new string[] {"Basic","Johnny","Steph","Janka","Alexandre","Nick","Lindzy","Denis","Lana","Sam"};

        public void Awake()
        {
            if(true || !PlayerPrefs.HasKey("populated"))
            {
                populateprefs();
            }
            else
            {
                getprefs();
            }
        }

        public void Start()
        {

        }

        public void Update()
        {
            maxAI = (int)slider.value;
            text.text = maxAI.ToString();
            int acc =  0;
            int remaining = maxAI;
            foreach(AISlider iSlider in amounts)
            {
                if(acc + iSlider.slider.value > maxAI)
                {
                    trimall(iSlider);
                }
                acc += (int)iSlider.slider.value;
                iSlider.textComponent.text = iSlider.slider.value.ToString();
            }
        }

        public void trimall(AISlider excluded)
        {
            while(true)
            {
                bool allzero = true;
                foreach(AISlider aISlider in amounts)
                {
                    if (aISlider == excluded)
                    {
                        continue;
                    }
                    if (current == maxAI)
                    {
                        return;
                    }
                    if (aISlider.tryincrement(false))
                    {
                        current--;
                    }
                    allzero &= aISlider.slider.value == 0;
                }
                if (allzero)
                {
                    excluded.slider.value = maxAI;
                    current = maxAI;
                }
            }
        }

        public void getprefs()
        {
            int acc=0;
            foreach(AISlider iSlider in amounts)
            {
                int value = PlayerPrefs.GetInt(iSlider.target);
                iSlider.textComponent.text = value.ToString();
                iSlider.slider.value = value;
                acc+= value;
            }
            maxAI = PlayerPrefs.GetInt("maxAI");
            current = acc;
            slider.value = maxAI;
        }

        public void populateprefs()
        {
            foreach(AISlider iSlider in amounts)
            {
                PlayerPrefs.SetInt(iSlider.target,0);
            }
        }
    }
}

