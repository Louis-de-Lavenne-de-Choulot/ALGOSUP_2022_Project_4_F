using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    private bool count = false;
    // Update is called once per frame
    void Update()
    {
        bool hasScaned = gameObject.GetComponent<Animator>().GetBool("hasScanned");
        bool doorOpen = gameObject.GetComponent<Animator>().GetBool("doorOpen");
        float time = gameObject.GetComponent<Animator>().GetFloat("time");

        if (hasScaned && doorOpen)
        {
            count = true;
        }

        if (count == true && time == 0)
        {
            count = false;
        }

        if(count == true)
        {
            gameObject.GetComponent<Animator>().SetFloat("time", time + Time.deltaTime);
        }
    }
}
