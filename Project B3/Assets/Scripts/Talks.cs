using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Talks : MonoBehaviour
{
    private AudioClip[] clips;
    float cooldown;
    float period;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name[0] == 'F'){
            clips = Resources.LoadAll<AudioClip>("Audio/VoiceActors/F");
        }else{
            clips = Resources.LoadAll<AudioClip>("Audio/VoiceActors/M");
        }
        period = Random.Range(0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > period)
        {
            cooldown = Random.Range(10f, 30f);
            int ran = Random.Range(0, clips.Length);
            GetComponent<AudioSource>().clip = clips[ran];
            GetComponent<AudioSource>().Play();
            period = Time.time + cooldown;
        }
    }
}
