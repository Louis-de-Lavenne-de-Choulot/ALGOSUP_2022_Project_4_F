using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using Photon.Realtime;

public class Attach : MonoBehaviour
{
    bool locking;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!locking){
            GameObject[] rigs = GameObject.FindGameObjectsWithTag("Pp");
            foreach (GameObject rig in rigs)
            {
                if(rig.transform.GetComponent<PhotonView>().IsMine){
                    transform.SetParent(rig.transform);
                    Transform handl= rig.transform.GetChild(0);
                    Transform handr= rig.transform.GetChild(1);
                    if (handl.name == "CustomHandLeft" && handr.name == "CustomHandRight"){
                        handl.SetParent(transform.GetChild(0).GetChild(4));
                        handr.SetParent(transform.GetChild(0).GetChild(5));
                        handl.GetComponent<OVRGrabber>().m_parentTransform = handl.parent;
                        handr.GetComponent<OVRGrabber>().m_parentTransform = handr.parent;
                        handl.position = handl.parent.position;
                        handr.position = handr.parent.position;
                        handl.GetComponent<VRcontrolls>().cam = handl.parent.parent.GetChild(1);
                        handr.GetComponent<VRcontrolls>().cam = handr.parent.parent.GetChild(1);
                    }
                    rig.transform.GetComponent<CharacterCameraConstraint>().CameraRig = transform.GetComponent<OVRCameraRig>();
                    rig.transform.GetComponent<SimpleCapsuleWithStickMovement>().CameraRig = transform.GetComponent<OVRCameraRig>();
                    locking = true;
                }
            }
        }
    }
}
