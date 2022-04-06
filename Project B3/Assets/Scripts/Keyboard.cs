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
            Debug.Log("YES");
            other.GetComponent<Talks>().clips = other.GetComponent<Talks>().clipPf;
            audioSource.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (other.gameObject.tag == "NPC")
        {
            npc--;
            Debug.Log("End");
            other.GetComponent<Talks>().clips = other.GetComponent<Talks>().clipf;
        }
        if (npc == 0){
            audioSource.Stop();
        }
    }
}
