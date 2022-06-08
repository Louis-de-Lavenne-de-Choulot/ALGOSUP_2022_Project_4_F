using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
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
        if ((int) WC == 0)
        {
            bathroom = "M";
        }
        else
        {
            bathroom = "F";
        }
    }

    private void Update()
    {
        Collider[] collision = Physics.OverlapSphere(transform.position, 0.2f, LayerMask.GetMask("Scaner"));

        if (collision.Length != 0)
        {
            Animator scaner = collision[0].transform.gameObject.GetComponent(typeof(Animator)) as Animator;
            Animator door = collision[0].transform.parent.parent.gameObject.GetComponent(typeof(Animator)) as Animator;

            scaner.SetBool("isGreen", false);
            door.SetBool("hasScanned", false);

            if (collision[0].transform.parent.parent.tag == "Main gate" || collision[0].transform.parent.parent.tag == "Comon room")
            {
                scaner.SetBool("isGreen", true);
                door.SetBool("hasScanned", true);
            }

            switch ((int)door_access)
            {
                case 0:
                    scaner.SetBool("isGreen", true);
                    door.SetBool("hasScanned", true);
                    break;

                case 1:
                    if (collision[0].transform.parent.parent.tag == "CNAM")
                    {
                        scaner.SetBool("isGreen", true);
                        door.SetBool("hasScanned", true);
                    }
                    break;

                //-------------------------------!!!!!!!!!!!!!!!!!!-------------
                //only alow personae to enter class in wich they are supposed to be

                case 2:
                    if (collision[0].transform.parent.parent.tag == "CmptSci" || collision[0].transform.parent.parent.tag == "Amptheater" || collision[0].transform.parent.parent.tag == "student rest"
                        || collision[0].transform.parent.parent.tag == $"WC_{bathroom}" || collision[0].transform.parent.parent.tag == "SoftSkill" || collision[0].transform.parent.parent.tag == "English" || collision[0].transform.parent.parent.tag == "library")
                    {
                        scaner.SetBool("isGreen", true);
                        door.SetBool("hasScanned", true);
                        //implement more advanced logic latter
                    }
                    break;
                case 3:
                    if (collision[0].transform.parent.parent.tag == $"WC_{bathroom}" || collision[0].transform.parent.parent.tag == "English" ||
                        collision[0].transform.parent.parent.tag == "Staff rest" || collision[0].transform.parent.parent.tag == "library")
                    {
                        scaner.SetBool("isGreen", true);
                        door.SetBool("hasScanned", true);
                    }
                    break;
                case 4:
                    if (collision[0].transform.parent.parent.tag == $"WC_{bathroom}" || collision[0].transform.parent.parent.tag == "SoftSkill" || collision[0].transform.parent.parent.tag == "Amptheater" ||
                        collision[0].transform.parent.parent.tag == "Staff rest" || collision[0].transform.parent.parent.tag == "library")
                    {
                        scaner.SetBool("isGreen", true);
                        door.SetBool("hasScanned", true);
                        // **/!\** verify if any soft skill is held in Amptheater
                    }
                    break;
                case 5:
                    if (collision[0].transform.parent.parent.tag == $"WC_{bathroom}" || collision[0].transform.parent.parent.tag == "Amptheater" || collision[0].transform.parent.parent.tag == "CmptSci" ||
                        collision[0].transform.parent.parent.tag == "Staff rest" || collision[0].transform.parent.parent.tag == "library")
                    {
                        scaner.SetBool("isGreen", true);
                        door.SetBool("hasScanned", true);
                    }
                    break;
            }

            if (drone_access && collision[0].transform.parent.parent.tag == "Drone")
            {
                scaner.SetBool("isGreen", true);
                door.SetBool("hasScanned", true);
            }
            else if (drone_access! && collision[0].transform.parent.parent.tag == "Drone")
            {
                scaner.SetBool("isGreen", false);
                door.SetBool("hasScanned", false);
            }

            if (scaner.GetInteger("RoomID") == 0 && collision[0].transform.parent.parent.CompareTag("Project"))
            {
                scaner.SetInteger("RoomID", Project_room);
            }

            if (scaner.GetBool("reScan") == false && collision[0].transform.parent.parent.CompareTag("Project"))
            {
                if (scaner.GetInteger("count") == 0)
                {
                    scaner.SetInteger("count", 1);
                }
                else
                {
                    scaner.SetBool("isGreen", false);
                    door.SetBool("hasScanned", false);;
                    scaner.SetInteger("RoomID", 0);
                    scaner.SetInteger("count", 0);
                }
            }

            if (Project_room == scaner.GetInteger("RoomID") && collision[0].transform.parent.parent.CompareTag("Project"))
            {
                scaner.SetBool("isGreen", true);
                
                door.SetBool("hasScanned", true);
            }
            else if (Project_room != scaner.GetInteger("RoomID") && collision[0].transform.parent.parent.CompareTag("Project"))
            {
                scaner.SetBool("isGreen", false);
                door.SetBool("hasScanned", false);
            }
        }
    }
}
