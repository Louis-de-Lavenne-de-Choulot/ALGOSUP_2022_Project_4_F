using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Keyboard : MonoBehaviour
{
    int npc = 0;
    private void OnTriggerEnter(Collider other)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        //if gameobject is player play audio
        if (other.gameObject.tag == "NPC")
        {
            npc++;
            audioSource.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (other.gameObject.tag == "NPC")
        {
            npc--;
        }
        if (npc == 0){
            audioSource.Stop();
        }
    }
}
