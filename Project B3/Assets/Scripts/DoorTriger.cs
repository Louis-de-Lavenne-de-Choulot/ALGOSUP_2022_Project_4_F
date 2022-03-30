using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

public class DoorTriger : MonoBehaviour
{
    protected enum DoorEnum
    {
        Full_Access = 0,
        CNAM = 1,
        Student = 2,
        English_teacher = 3,
        Soft_skill_teacher = 4,
        Computer_science_teacher = 5
    };

    protected enum GenederEnum
    {
        Man_WC = 0,
        Woman_WC = 1
    };

    [SerializeField]
    private DoorEnum door_access = new DoorEnum();
    [SerializeField]
    private GenederEnum WC = new GenederEnum();
    [SerializeField]
    private bool drone_access = true;

    public int PrjRoom
    {
        get { return Project_room; }
        set { Project_room = Mathf.Clamp(value, 1, 255); }
    }
    [SerializeField]
    private int Project_room = 5;

    private string bathroom;

    // Start is called before the first frame update
    void Start()
    {
        if ((int)WC == 0)
        {
            bathroom = "M";
        }
        else
        {
            bathroom = "F";
        }
    }

    [SerializeField]
    private bool is_AI = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "door" && is_AI)
        {
            Animator scanerR = other.transform.parent.parent.GetChild(1).gameObject.GetComponent(typeof(Animator)) as Animator;
            Animator scanerL = other.transform.parent.parent.GetChild(2).gameObject.GetComponent(typeof(Animator)) as Animator;
            Animator door = other.transform.parent.parent.gameObject.GetComponent(typeof(Animator)) as Animator;

            scanerR.SetBool("isScan", true);
            scanerL.SetBool("isScan", true);

            door.SetBool("hasScanned", true);

            if (scanerR.transform.tag == "Main gate" || scanerR.transform.tag == "Comon room")
            {
                scanerR.SetBool("isScan", true);
                scanerL.SetBool("isScan", true);
                door.SetBool("hasScanned", true);
            }

            switch ((int)door_access)
            {
                case 0:
                    scanerR.SetBool("isScan", true);
                    scanerL.SetBool("isScan", true);
                    door.SetBool("hasScanned", true);
                    break;

                case 1:
                    if (scanerR.transform.tag == "CNAM")
                    {
                        scanerR.SetBool("isScan", true);
                        scanerL.SetBool("isScan", true);
                        door.SetBool("hasScanned", true);
                    }
                    break;

                //-------------------------------!!!!!!!!!!!!!!!!!!-------------
                //only alow personae to enter class in wich they are supposed to be

                case 2:
                    if (scanerR.transform.tag == "CmptSci" || scanerR.transform.tag == "Amptheater" || scanerR.transform.tag == "student rest"
                        || scanerR.transform.tag == $"WC_{bathroom}" || scanerR.transform.tag == "SoftSkill" || scanerR.transform.tag == "English" || scanerR.transform.tag == "library")
                    {
                        scanerR.SetBool("isScan", true);
                        scanerL.SetBool("isScan", true);
                        door.SetBool("hasScanned", true);
                        //implement more advanced logic latter
                    }
                    break;
                case 3:
                    if (scanerR.transform.tag == $"WC_{bathroom}" || scanerR.transform.tag == "English" ||
                        scanerR.transform.tag == "Staff rest" || scanerR.transform.tag == "library")
                    {
                        scanerR.SetBool("isScan", true);
                        scanerL.SetBool("isScan", true);
                        door.SetBool("hasScanned", true);
                    }
                    break;
                case 4:
                    if (scanerR.transform.tag == $"WC_{bathroom}" || scanerR.transform.tag == "SoftSkill" || scanerR.transform.tag == "Amptheater" ||
                        scanerR.transform.tag == "Staff rest" || scanerR.transform.tag == "library")
                    {
                        scanerR.SetBool("isScan", true);
                        scanerL.SetBool("isScan", true);
                        door.SetBool("hasScanned", true);
                        // **/!\** verify if any soft skill is held in Amptheater
                    }
                    break;
                case 5:
                    if (scanerR.transform.tag == $"WC_{bathroom}" || scanerR.transform.tag == "Amptheater" || scanerR.transform.tag == "CmptSci" ||
                        scanerR.transform.tag == "Staff rest" || scanerR.transform.tag == "library")
                    {
                        scanerR.SetBool("isScan", true);
                        scanerL.SetBool("isScan", true);
                        door.SetBool("hasScanned", true);
                    }
                    break;
            }

            if (drone_access && scanerR.transform.tag == "Drone")
            {
                scanerR.SetBool("isScan", true);
                scanerL.SetBool("isScan", true);
                door.SetBool("hasScanned", true);
            }
            else if (drone_access! && scanerR.transform.tag == "Drone")
            {
                scanerR.SetBool("isScan", true);
                scanerL.SetBool("isScan", true);
                door.SetBool("hasScanned", false);
            }

            if (scanerR.GetInteger("RoomID") == 0 && scanerR.transform.CompareTag("Project"))
            {
                scanerL.SetInteger("RoomID", Project_room);
                scanerR.SetInteger("RoomID", Project_room);
                scanerR.SetBool("isScan", true);
                scanerL.SetBool("isScan", true);
            }

            if (scanerR.GetBool("reScan") == false && scanerR.transform.CompareTag("Project"))
            {
                if (scanerR.GetInteger("count") == 0)
                {
                    scanerR.SetInteger("count", 1);
                    scanerL.SetInteger("count", 1);
                }
                else
                {
                    scanerR.SetBool("isScan", true);
                    scanerL.SetBool("isScan", true);
                    door.SetBool("hasScanned", false);
                    scanerL.SetInteger("RoomID", 0);
                    scanerR.SetInteger("RoomID", 0);
                    scanerL.SetInteger("count", 0);
                    scanerR.SetInteger("RoomID", 0);
                }
            }

            if (Project_room == scanerR.GetInteger("RoomID") && scanerR.transform.CompareTag("Project"))
            {
                scanerR.SetBool("isScan", true);
                scanerL.SetBool("isScan", true);

                door.SetBool("hasScanned", true);
            }
            else if (Project_room != scanerR.GetInteger("RoomID") && scanerR.transform.CompareTag("Project"))
            {
                scanerR.SetBool("isScan", true);
                scanerL.SetBool("isScan", true);
                door.SetBool("hasScanned", false);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "door")
        {
            Animator door = other.transform.parent.parent.gameObject.GetComponent(typeof(Animator)) as Animator;
            door.SetBool("doorOpen", true);
        }
    }

    private void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "door" && other.transform.parent.parent.gameObject.GetComponent<Animator>().GetFloat("time") > 2f)
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

            other.transform.parent.parent.gameObject.GetComponent<Animator>().SetFloat("time", 0f);
        }
    }
}
    