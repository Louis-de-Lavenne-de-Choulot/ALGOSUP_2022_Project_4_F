using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

public class DoorTriger : MonoBehaviour
{

    private float time = 0f;

    [SerializeField]
    private bool is_AI = true;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.tag == "door" && is_AI)
        {
            Animator scanerR = other.transform.parent.parent.GetChild(1).gameObject.GetComponent(typeof(Animator)) as Animator;
            Animator scanerL = other.transform.parent.parent.GetChild(2).gameObject.GetComponent(typeof(Animator)) as Animator;
            Animator door = other.transform.parent.parent.gameObject.GetComponent(typeof(Animator)) as Animator;

            scanerR.SetBool("isScan", true);
            scanerL.SetBool("isScan", true);

            door.SetBool("hasScanned", true);
        }
    }

    private void Update()
    {
        time += Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "door")
        {
            Animator door = other.transform.parent.parent.gameObject.GetComponent(typeof(Animator)) as Animator;
            Debug.Log(door + " triger");
            door.SetBool("doorOpen", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "door" && time > 5f)
        {
            Animator door = other.transform.parent.parent.gameObject.GetComponent(typeof(Animator)) as Animator;
            Animator scanerR = other.transform.parent.parent.GetChild(1).gameObject.GetComponent(typeof(Animator)) as Animator;
            Animator scanerL = other.transform.parent.parent.GetChild(2).gameObject.GetComponent(typeof(Animator)) as Animator;

            scanerR.SetBool("isScan", false);
            scanerR.SetBool("isScan fail", false);
            scanerR.SetBool("reScan", false);
            scanerR.SetInteger("count", 0);
            scanerR.SetBool("isGreen", false);

            scanerL.SetBool("isScan", false);
            scanerL.SetBool("isScan fail", false);
            scanerL.SetBool("reScan", false);
            scanerL.SetInteger("count", 0);
            scanerL.SetBool("isGreen", false);

            door.SetBool("hasScanned", false);
            door.SetBool("doorOpen", false);

            time = 0f;
        }
    }
}
    