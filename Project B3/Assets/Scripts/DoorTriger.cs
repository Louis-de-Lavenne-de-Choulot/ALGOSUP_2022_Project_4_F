using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

public class DoorTriger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {

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
        if (other.tag == "door")
        {
            Animator door = other.transform.parent.gameObject.GetComponent(typeof(Animator)) as Animator;
            Animator scanerR = other.transform.parent.parent.GetChild(2).gameObject.GetComponent(typeof(Animator)) as Animator;
            Animator scanerL = other.transform.parent.parent.GetChild(3).gameObject.GetComponent(typeof(Animator)) as Animator;

            scanerR.SetBool("isScan", false);
            scanerR.SetBool("isScan fail", false);
            scanerL.SetBool("isScan", false);
            scanerL.SetBool("isScan fail", false);
            door.SetBool("hasScanned", false);
            door.SetBool("doorOpen", false);
        }
    }
}
    