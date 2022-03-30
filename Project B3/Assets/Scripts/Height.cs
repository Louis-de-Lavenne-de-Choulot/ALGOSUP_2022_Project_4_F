using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Height : MonoBehaviour
{
    public CharacterCameraConstraint ccamera;
    void Start()
    {
        ccamera.HeightOffset = PlayerPrefs.GetFloat("Height", 1.8f);
    }
}
