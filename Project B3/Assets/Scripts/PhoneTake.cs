using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneTake : MonoBehaviour
{
    public Transform handL;
    public Transform handR;
    public Transform phone;
    public Transform wallet;

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger, OVRInput.Controller.Touch))
        {
            phone.position = handR.position;
            phone.rotation = handR.rotation;
            phone.Rotate(0,180,-90);

        }
        else if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.Touch))
        {;
            phone.position = handL.position;
            phone.rotation = handL.rotation;
            phone.Rotate(0,180,90);
        }
        else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.Touch) || OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger) || OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger, OVRInput.Controller.Touch))
        {
            phone.SetParent(wallet);
            phone.position = wallet.position;
        }
    }
}
