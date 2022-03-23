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
        public static int maxAI;
        static int currentAI;
        public static string[] AIList = new string[] {"Basic","Johnny","Steph","Janka","Alexandre","Nick","Lindzy","Denis","Lana","Sam"};

        void Awake()
        {
            if(!PlayerPrefs.HasKey("populated") || true)
            {
                populatePrefs();
                currentAI = 0;
            }
            else
            {
                currentAI = gettotalprefs();
            }
        }
        void Start()
        {
            text.text = maxAI.ToString();
            slider.onValueChanged.AddListener(delegate {updateMax();});
        }

        void updateMax()
        {
            if (slider.value < currentAI)
            {
                slider.SetValueWithoutNotify(currentAI);
            }
            else
            {
                maxAI = (int)slider.value;
                text.text = maxAI.ToString();
            }
            PlayerPrefs.SetInt("MaxAI",maxAI);

        }

        static void populatePrefs()
        {
            foreach(string personae in AIList)
            {
                PlayerPrefs.SetInt(personae,0);
            }
            PlayerPrefs.SetInt("MaxAI",0);
            PlayerPrefs.SetString("populated","true");
        }

        static int gettotalprefs()
        {
            int acc = 0;
            foreach(string personae in AIList)
            {
                acc += PlayerPrefs.GetInt(personae,0);
            }
            maxAI = PlayerPrefs.GetInt("MaxAi");
            return acc;
        }

        static public int trychange(string name,int previous, int newval)
        {
            if (currentAI - previous + newval > maxAI)
            {
                int avalaible = maxAI - currentAI;
                PlayerPrefs.SetInt(name,previous + avalaible);
                PlayerPrefs.SetInt("Basic",0);
                currentAI = maxAI;
                return previous + avalaible;
            }
            PlayerPrefs.SetInt(name,newval);
            currentAI = currentAI + newval - previous;
            PlayerPrefs.SetInt("Basic",maxAI-currentAI);
            return newval;
        }
    }
}

