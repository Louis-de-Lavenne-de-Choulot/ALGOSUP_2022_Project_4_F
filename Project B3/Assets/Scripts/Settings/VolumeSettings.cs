using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class VolumeSettings : MonoBehaviour
{
    public TMP_Text textComponent;
    public void SetSliderValue(float sliderValue)
    {
        textComponent.text = Mathf.Round(sliderValue * 100).ToString();
        PlayerPrefs.SetFloat("volume", sliderValue);
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
    }
}