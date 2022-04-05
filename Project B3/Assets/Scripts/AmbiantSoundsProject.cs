using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AmbiantSoundsProject : MonoBehaviour
{
    public AudioClip clip;
    public Collider Collider;

    private void OnTriggerEnter(Collider other)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        //if gameobject is player play audio
        if (other.gameObject.tag == "Player")
        {
            audioSource.Play();

            if (audioSource.isPlaying == true)
            {
                Debug.Log("Audio is playing");
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (other.gameObject.tag == "Player")
        {
            audioSource.Stop();
        }
    }
}
