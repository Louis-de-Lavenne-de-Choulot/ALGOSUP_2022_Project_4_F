using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OVR;

public class TurnMode : MonoBehaviour
{
    public Toggle Smooth;
    public Toggle Snap;

    public Toggle None;
    public OVRPlayerController controller;

    void Start()
    {
        Smooth.onValueChanged.AddListener(delegate{toSmooth();});
        Snap.onValueChanged.AddListener(delegate{toSnap();});
        None.onValueChanged.AddListener(delegate{toNone();});
    }

    void toSmooth()
    {
        controller.SnapRotation = false;
        controller.EnableRotation = true;
    }

    void toSnap()
    {
        controller.SnapRotation = true;
        controller.EnableRotation = true;
    }
    void toNone()
    {
        controller.EnableRotation = false;
    }


}
