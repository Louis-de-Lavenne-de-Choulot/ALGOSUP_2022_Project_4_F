using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftSound : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
            other.GetComponent<Talks>().sS = true;
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == "NPC")
            other.GetComponent<Talks>().sS = false;
    }
}
