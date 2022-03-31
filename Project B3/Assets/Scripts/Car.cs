using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : NPC
{

    public AudioClip _engine;
    public AudioClip _honk;
    AudioSource Engine;
    AudioSource Honk;
    public Collider Honker;
    float cooldown;

    public void Awake()
    {
        Engine.clip = _engine;
        Honk.clip = _honk;
    }
    
    void LateUpdate()
    {
        if (anim.GetBool("IsMoving") && !Engine.isPlaying)
        {
            Engine.Play();
        }
    }
    void onTriggerEnter(Collision collide)
    {
        if (collide.collider.tag != "Player")
        {
            Physics.IgnoreCollision(collide.collider,Honker);
            return;
        }
        if(!Honk.isPlaying)
        {
            if (Time.time - cooldown > 3f )
            {
                cooldown = Time.time;
                Honk.Play();
            }
        }
    }

}