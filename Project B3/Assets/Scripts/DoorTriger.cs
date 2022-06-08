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
        if (other.gameObject.layer == LayerMask.NameToLayer("DoorR"))
        {
            Animator door = other.transform.parent.gameObject.GetComponent(typeof(Animator)) as Animator;
            if (door.GetBool("doorOpenR") == false && door.GetBool("doorOpenL") == false)
            {
                door.SetBool("doorOpenR", true);
            }
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("DoorL"))
        {
            Animator door = other.transform.parent.gameObject.GetComponent(typeof(Animator)) as Animator;
            if (door.GetBool("doorOpenR") == false && door.GetBool("doorOpenL") == false)
            {
                door.SetBool("doorOpenL", true);
            }
        }


        if ((other.gameObject.layer == LayerMask.NameToLayer("DoorR") || other.gameObject.layer == LayerMask.NameToLayer("DoorL")) && is_AI)
        {
            Animator scaner = other.transform.parent.GetChild(2).GetChild(1).gameObject.GetComponent(typeof(Animator)) as Animator;
            Animator door = other.transform.parent.gameObject.GetComponent(typeof(Animator)) as Animator;

            scaner.SetBool("isScan", true);

            door.SetBool("hasScanned", true);

            if (scaner.transform.parent.tag == "Main gate" || scaner.transform.parent.tag == "Comon room")
            {
                scaner.SetBool("isScan", true);
                door.SetBool("hasScanned", true);
            }

            switch ((int)door_access)
            {
                case 0:
                    scaner.SetBool("isScan", true);
                    door.SetBool("hasScanned", true);
                    break;

                case 1:
                    if (scaner.transform.parent.tag == "CNAM")
                    {
                        scaner.SetBool("isScan", true);
                        door.SetBool("hasScanned", true);
                    }
                    break;

                //-------------------------------!!!!!!!!!!!!!!!!!!-------------
                //only alow personae to enter class in wich they are supposed to be

                case 2:
                    if (scaner.transform.parent.tag == "CmptSci" || scaner.transform.parent.tag == "Amptheater" || scaner.transform.parent.tag == "student rest"
                        || scaner.transform.parent.tag == $"WC_{bathroom}" || scaner.transform.parent.tag == "SoftSkill" || scaner.transform.parent.tag == "English" || scaner.transform.parent.tag == "library")
                    {
                        scaner.SetBool("isScan", true);
                        door.SetBool("hasScanned", true);
                        //implement more advanced logic latter
                    }
                    break;
                case 3:
                    if (scaner.transform.parent.tag == $"WC_{bathroom}" || scaner.transform.parent.tag == "English" ||
                        scaner.transform.parent.tag == "Staff rest" || scaner.transform.parent.tag == "library")
                    {
                        scaner.SetBool("isScan", true);
                        door.SetBool("hasScanned", true);
                    }
                    break;
                case 4:
                    if (scaner.transform.parent.tag == $"WC_{bathroom}" || scaner.transform.parent.tag == "SoftSkill" || scaner.transform.parent.tag == "Amptheater" ||
                        scaner.transform.parent.tag == "Staff rest" || scaner.transform.parent.tag == "library")
                    {
                        scaner.SetBool("isScan", true);
                        door.SetBool("hasScanned", true);
                        // **/!\** verify if any soft skill is held in Amptheater
                    }
                    break;
                case 5:
                    if (scaner.transform.parent.tag == $"WC_{bathroom}" || scaner.transform.parent.tag == "Amptheater" || scaner.transform.parent.tag == "CmptSci" ||
                        scaner.transform.parent.tag == "Staff rest" || scaner.transform.parent.tag == "library")
                    {
                        scaner.SetBool("isScan", true);
                        door.SetBool("hasScanned", true);
                    }
                    break;
            }

            if (drone_access && scaner.transform.parent.tag == "Drone")
            {
                scaner.SetBool("isScan", true);
                door.SetBool("hasScanned", true);
            }
            else if (drone_access! && scaner.transform.parent.tag == "Drone")
            {
                scaner.SetBool("isScan", true);
                door.SetBool("hasScanned", false);
            }

            if (scaner.GetInteger("RoomID") == 0 && scaner.transform.CompareTag("Project"))
            {
                scaner.SetInteger("RoomID", Project_room);
                scaner.SetBool("isScan", true);
            }

            if (scaner.GetBool("reScan") == false && scaner.transform.CompareTag("Project"))
            {
                if (scaner.GetInteger("count") == 0)
                {
                    scaner.SetInteger("count", 1);
                }
                else
                {
                    scaner.SetBool("isScan", true);
                    door.SetBool("hasScanned", false);
                    scaner.SetInteger("RoomID", 0);
                    scaner.SetInteger("RoomID", 0);
                }
            }

            if (Project_room == scaner.GetInteger("RoomID") && scaner.transform.CompareTag("Project"))
            {
                scaner.SetBool("isScan", true);

                door.SetBool("hasScanned", true);
            }
            else if (Project_room != scaner.GetInteger("RoomID") && scaner.transform.CompareTag("Project"))
            {
                scaner.SetBool("isScan", true);
                door.SetBool("hasScanned", false);
            }
        }
    }

    private void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("DoorR") || other.gameObject.layer == LayerMask.NameToLayer("DoorL"))
        {
            Animator door = other.transform.parent.gameObject.GetComponent(typeof(Animator)) as Animator;
            Animator scaner = other.transform.parent.GetChild(2).GetChild(1).gameObject.GetComponent(typeof(Animator)) as Animator;

            scaner.SetBool("isScan", false);
            scaner.SetBool("isScan fail", false);
            scaner.SetBool("reScan", false);
            scaner.SetInteger("count", 0);
            scaner.SetBool("isGreen", false);

            door.SetBool("hasScanned", false);
            door.SetBool("doorOpenR", false);
            door.SetBool("doorOpenL", false);

            other.transform.parent.gameObject.GetComponent<Animator>().SetFloat("time", 0f);
        }
    }
}
    