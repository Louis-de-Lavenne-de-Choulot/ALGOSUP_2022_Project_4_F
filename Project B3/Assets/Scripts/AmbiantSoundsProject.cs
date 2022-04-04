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
        if (other.gameObject.tag == "Player" || other.gameObject.name == "Player" && other.gameObject.name == "Male 1(Clone)" || other.gameObject.name == "Female 1(Clone)"
            || other.gameObject.name == "Male 2(Clone)" || other.gameObject.name == "Female 2(Clone)" || other.gameObject.name == "Male 3(Clone)" || other.gameObject.name == "Female 3(Clone)"
            || other.gameObject.name =="Male 4(Clone)")
        {
            audioSource.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (other.gameObject.tag == "Player" || other.gameObject.name == "Player" && other.gameObject.name == "Male 1(Clone)" || other.gameObject.name == "Female 1(Clone)"
           || other.gameObject.name == "Male 2(Clone)" || other.gameObject.name == "Female 2(Clone)" || other.gameObject.name == "Male 3(Clone)" || other.gameObject.name == "Female 3(Clone)"
           || other.gameObject.name == "Male 4(Clone)")
        {
            audioSource.Stop();
        }
    }
}
