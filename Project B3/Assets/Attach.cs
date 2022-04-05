using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using Photon.Realtime;

public class Attach : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            GameObject[] rigs = GameObject.FindGameObjectsWithTag("Pp");
            foreach (GameObject rig in rigs)
            {
                if(rig.transform.GetComponent<PhotonView>().IsMine){
                    transform.SetParent(rig.transform);
                    rig.transform.GetChild(0).SetParent(transform.GetChild(0).GetChild(4));
                    rig.transform.GetChild(1).SetParent(transform.GetChild(0).GetChild(5));
                    rig.transform.GetComponent<CharacterCameraConstraint>().CameraRig = transform.GetComponent<OVRCameraRig>();
                    rig.transform.GetComponent<SimpleCapsuleWithStickMovement>().CameraRig = transform.GetComponent<OVRCameraRig>();
                }
            }
    }
}
