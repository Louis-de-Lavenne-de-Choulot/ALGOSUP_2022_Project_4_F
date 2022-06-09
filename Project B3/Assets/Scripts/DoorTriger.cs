using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

public class DoorTriger : MonoBehaviour
{
    private bool open = false;
    private float timer = 0f;
    private float timerLimit = 1.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("CaracterDetection") && open == false)
        {
            timerLimit = 1.5f;

            Animator door = transform.parent.gameObject.GetComponent(typeof(Animator)) as Animator;
            Animator scaner = transform.parent.GetChild(1).GetChild(1).gameObject.GetComponent(typeof(Animator)) as Animator;

            open = true;
            scaner.SetBool("isScan", true);
            door.SetBool("hasScanned", true);

            var CrTransform = other.transform.parent;

            Vector3 relativePoint = CrTransform.InverseTransformPoint(transform.position);

            float X = relativePoint.x;


            if(transform.parent.gameObject.layer == LayerMask.NameToLayer("inverted"))
            {
                if (X < 0)
                {
                    door.SetBool("doorOpenR", true);
                }
                else
                {
                    door.SetBool("doorOpenL", true);
                }
            }
            else
            {
                if (X < 0)
                {
                    door.SetBool("doorOpenL", true);
                }
                else
                {
                    door.SetBool("doorOpenR", true);
                }
            }

        }

        if (other.gameObject.layer == LayerMask.NameToLayer("CaracterDetectionPlayer") && open == false)
        {
            Animator door = transform.parent.gameObject.GetComponent(typeof(Animator)) as Animator;
            Animator scaner = transform.parent.GetChild(1).GetChild(1).gameObject.GetComponent(typeof(Animator)) as Animator;

            timerLimit = 3f;

            open = true;

            var CrTransform = other.transform.parent;

            Vector3 relativePoint = CrTransform.InverseTransformPoint(transform.position);

            float X = relativePoint.x;


            if (transform.parent.gameObject.layer == LayerMask.NameToLayer("inverted"))
            {
                if (X < 0)
                {
                    door.SetBool("doorOpenR", true);
                }
                else
                {
                    door.SetBool("doorOpenL", true);
                }
            }
            else
            {
                if (X < 0)
                {
                    door.SetBool("doorOpenL", true);
                }
                else
                {
                    door.SetBool("doorOpenR", true);
                }
            }

        }

        if (other.gameObject.layer == LayerMask.NameToLayer("CaracterDetection") || other.gameObject.layer == LayerMask.NameToLayer("CaracterDetectionPlayer") && open == true)
        {
            timer = 0;
        }

    }

    private void Update()
    {
        if (open)
        {
            timer += Time.deltaTime;
        }

        if(timer > timerLimit)
        {
            Animator door = transform.parent.gameObject.GetComponent(typeof(Animator)) as Animator;
            Animator scaner = transform.parent.GetChild(1).GetChild(1).gameObject.GetComponent(typeof(Animator)) as Animator;
            
            scaner.SetBool("isScan", false);
            scaner.SetBool("isScan fail", false);
            scaner.SetBool("reScan", false);
            scaner.SetInteger("count", 0);
            scaner.SetBool("isGreen", false);
            
            door.SetBool("hasScanned", false);
            door.SetBool("doorOpenR", false);
            door.SetBool("doorOpenL", false);

            open = false;
            timer = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.gameObject.layer == LayerMask.NameToLayer("DoorR") || other.gameObject.layer == LayerMask.NameToLayer("DoorL"))
        //{
        //    Animator door = other.transform.parent.gameObject.GetComponent(typeof(Animator)) as Animator;
        //    Animator scaner = other.transform.parent.GetChild(1).GetChild(1).gameObject.GetComponent(typeof(Animator)) as Animator;
        //
        //    scaner.SetBool("isScan", false);
        //    scaner.SetBool("isScan fail", false);
        //    scaner.SetBool("reScan", false);
        //    scaner.SetInteger("count", 0);
        //    scaner.SetBool("isGreen", false);
        //
        //    door.SetBool("hasScanned", false);
        //    door.SetBool("doorOpenR", false);
        //    door.SetBool("doorOpenL", false);
        //
        //    other.transform.parent.gameObject.GetComponent<Animator>().SetFloat("time", 0f);
        //}
    }
}
    