using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private Camera cam;

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

    private string gender;

    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
        if ((int) WC == 0)
        {
            gender = "M";
        }
        else
        {
            gender = "F";
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        LayerMask scanerMask = LayerMask.GetMask("Scaner");
        LayerMask pickUpMask = LayerMask.GetMask("Pick Up");

        if (Physics.Raycast(ray, out hit, 10, scanerMask) && Input.GetMouseButtonDown(0) == true)
        {
            Animator scaner = hit.transform.parent.gameObject.GetComponent(typeof(Animator)) as Animator;
            Animator door = hit.transform.parent.parent.GetChild(0).gameObject.GetComponent(typeof(Animator)) as Animator;

            scaner.SetBool("isScan", false);
            scaner.SetBool("isScan fail", true);
            door.SetBool("hasScanned", false);

            if (hit.transform.tag == "Main gate" || hit.transform.tag == "Comon room")
            {
                scaner.SetBool("isScan", true);
                scaner.SetBool("isScan fail", false);
                door.SetBool("hasScanned", true);
            }

            switch ((int) door_access)
            {
                case 0:
                    scaner.SetBool("isScan", true);
                    scaner.SetBool("isScan fail", false);
                    door.SetBool("hasScanned", true);
                    break;

                case 1:
                    if (hit.transform.tag == "CNAM")
                    {
                        scaner.SetBool("isScan", true);
                        scaner.SetBool("isScan fail", false);
                        door.SetBool("hasScanned", true);
                    }
                    break;

                //-------------------------------!!!!!!!!!!!!!!!!!!-------------
                //only alow personae to enter class in wich they are supposed to be

                case 2:
                    if (hit.transform.tag == "CmptSci" || hit.transform.tag == "Amphitheater" || hit.transform.tag == "student rest"
                        || hit.transform.tag == $"WC_{gender}" || hit.transform.tag == "SoftSkill" || hit.transform.tag == "English" || hit.transform.tag == "library")
                    {
                        scaner.SetBool("isScan", true);
                        scaner.SetBool("isScan fail", false);
                        door.SetBool("hasScanned", true);
                        //implement more advanced logic latter
                    }
                    break;
                case 3:
                    if (hit.transform.tag == $"WC_{gender}" || hit.transform.tag == "English" ||
                        hit.transform.tag == "Staff rest" || hit.transform.tag == "library")
                    {
                        scaner.SetBool("isScan", true);
                        scaner.SetBool("isScan fail", false);
                        door.SetBool("hasScanned", true);
                    }
                    break;
                case 4:
                    if (hit.transform.tag == $"WC_{gender}" || hit.transform.tag == "SoftSkill" || hit.transform.tag == "Amphitheater" ||
                        hit.transform.tag == "Staff rest" || hit.transform.tag == "library")
                    {
                        scaner.SetBool("isScan", true);
                        scaner.SetBool("isScan fail", false);
                        door.SetBool("hasScanned", true);
                        // **/!\** verify if any soft skill is held in Amphitheater
                    }
                    break;
                case 5:
                    if (hit.transform.tag == $"WC_{gender}" || hit.transform.tag == "Amphitheater" || hit.transform.tag == "CmptSci" ||
                        hit.transform.tag == "Staff rest" || hit.transform.tag == "library")
                    {
                        scaner.SetBool("isScan", true);
                        scaner.SetBool("isScan fail", false);
                        door.SetBool("hasScanned", true);
                    }
                    break;
            }

            if (drone_access && hit.transform.tag == "Drone")
            {
                scaner.SetBool("isScan", true);
                scaner.SetBool("isScan fail", false);
                door.SetBool("hasScanned", true);
            }
            else if (drone_access! && hit.transform.tag == "Drone")
            {
                scaner.SetBool("isScan", false);
                scaner.SetBool("isScan fail", true);
                door.SetBool("hasScanned", false);
            }

            if (scaner.GetInteger("RoomID") == 0 && hit.transform.tag == "Project")
            {
                Animator scanR = hit.transform.parent.parent.GetChild(2).gameObject.GetComponent(typeof(Animator)) as Animator;
                Animator scanL = hit.transform.parent.parent.GetChild(3).gameObject.GetComponent(typeof(Animator)) as Animator;
                scanL.SetInteger("RoomID", Project_room);
                scanR.SetInteger("RoomID", Project_room);
            }

            Debug.Log(scaner.GetInteger("RoomID"));
            Debug.Log(Project_room);

            if (Project_room == scaner.GetInteger("RoomID") && hit.transform.tag == "Project")
            {
                scaner.SetBool("isScan", true);
                scaner.SetBool("isScan fail", false);
                door.SetBool("hasScanned", true);
            }
            else if(Project_room != scaner.GetInteger("RoomID") && hit.transform.tag == "Project")
            {
                scaner.SetBool("isScan", false);
                scaner.SetBool("isScan fail", true);
                door.SetBool("hasScanned", false);
            }
        }
    }
}
