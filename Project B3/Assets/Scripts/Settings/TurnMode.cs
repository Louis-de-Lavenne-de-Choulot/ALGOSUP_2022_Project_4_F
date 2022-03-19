using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OVR;

namespace Settings
{
    public class TurnMode : MonoBehaviour
    {
        public Toggle Smooth;
        public Toggle Snap;

        public Toggle None;
        public SimpleCapsuleWithStickMovement controller;

        void Start()
        {
            Smooth.onValueChanged.AddListener(delegate { if (Smooth.isOn) toSmooth(); });
            Snap.onValueChanged.AddListener(delegate { if (Snap.isOn) toSnap(); });
            None.onValueChanged.AddListener(delegate { if (None.isOn) toNone(); });
        }

        void toSmooth()
        {
            controller.SnapTurnMode = false;
            controller.EnableRotation = true;
        }

        void toSnap()
        {
            controller.SnapTurnMode = true;
            controller.EnableRotation = true;
        }
        void toNone()
        {
            controller.EnableRotation = false;
        }


    }
}
