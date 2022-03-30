using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneTeleport : MonoBehaviour
{
    public Transform playerWallet;
    private void OnTriggerExit(Collider other){
        if (other.name == "PlayerController"){
            transform.parent.LookAt(playerWallet);
            transform.parent.position = playerWallet.position;
        }
    }
}
