using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

public class DoorTriger : MonoBehaviour
{

    private float time = 0f;

    private void OnTriggerEnter(Collider other)
    {

    }

    private void Update()
    {
        time += Time.deltaTime;
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "door")
        {
            Animator animator = other.transform.parent.gameObject.GetComponent(typeof(Animator)) as Animator;
            animator.SetBool("doorOpen", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "door" && time > 5f)
        {
            Animator door = other.transform.parent.gameObject.GetComponent(typeof(Animator)) as Animator;
            Animator scanerR = other.transform.parent.parent.GetChild(2).gameObject.GetComponent(typeof(Animator)) as Animator;
            Animator scanerL = other.transform.parent.parent.GetChild(3).gameObject.GetComponent(typeof(Animator)) as Animator;

            scanerR.SetBool("isScan", false);
            scanerR.SetBool("isScan fail", false);
            scanerR.SetBool("reScan", false);
            scanerR.SetInteger("count", 0);
            scanerL.SetBool("isScan", false);
            scanerL.SetBool("isScan fail", false);
            scanerL.SetBool("reScan", false);
            scanerL.SetInteger("count", 0);
            door.SetBool("hasScanned", false);
            door.SetBool("doorOpen", false);

            time = 0f;
        }
    }
}
    