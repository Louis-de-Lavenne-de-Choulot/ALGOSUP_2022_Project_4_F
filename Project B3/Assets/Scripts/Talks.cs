using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Talks : MonoBehaviour
{
    public AudioClip[] clipf;
    public AudioClip[] clipPf;
    public AudioClip[] clips;
    float cooldown;
    float period;
    public bool sS;

    // Start is called before the first frame update
    void Start()
    {
        sS = false;
        if (gameObject.name[0] == 'F'){
            clipf = Resources.LoadAll<AudioClip>("Audio/VoiceActors/F");
            clips = clipf;
            clipPf = Resources.LoadAll<AudioClip>("Audio/VoiceActors/PF");
        }else{
            clipf = Resources.LoadAll<AudioClip>("Audio/VoiceActors/M");
            clips = clipf;
            clipPf = Resources.LoadAll<AudioClip>("Audio/VoiceActors/PM");
        }
        period = Random.Range(0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > period && sS == false)
        {
            cooldown = Random.Range(10f, 30f);
            int ran = Random.Range(0, clips.Length);
            GetComponent<AudioSource>().clip = clips[ran];
            GetComponent<AudioSource>().Play();
            period = Time.time + cooldown;
        }
    }
}
