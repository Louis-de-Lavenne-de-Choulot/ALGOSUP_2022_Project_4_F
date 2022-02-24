using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    [Header("MOVEMENT")]
    public float moveSpeed = 12;
    public float groundDrag = 3;

    [Header("GROUND CHECK")]
    public float playerHeight;
    public LayerMask ground;
    bool jumpKeyWasPressed;
    bool isground;
    bool buffer;

    // public Animator Anim;

    public Transform orientation;
    float horizontalInput;
    float verticalInput;
    
    Vector3 moveDirection;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update(){
        isground = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.2f + 0.2f, ground);
        Debug.DrawRay(transform.position, new Vector3(0, -1f, 1), Color.green);
        if(Input.GetKeyDown("k")){
            if (Time.timeScale == 0){
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
            }else{
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
            }
        }
        if (isground&&buffer){
            // Anim.SetTrigger("Landing");
            buffer = false;
        }
        else if(isground == false){
            buffer = true;
        }
        if (Input.GetKeyDown("space") && isground)
            jumpKeyWasPressed = true;
        MyInput();
        // if(Physics.Raycast(transform.position,transform.forward,out hit)) { if (hit.collider.gameObject.tag == "Tagged") { Debug.DrawRay(transform.position, transform.forward, Color.green); print("Hit"); } }
    }

    private void FixedUpdate()
    {
        if (jumpKeyWasPressed){
            rb.AddForce(Vector3.up * 7, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
            // Anim.SetTrigger("Jump");
        }   
        MovePlayer();
    }

    void MyInput()
    {
        if(Input.GetKey("d")){
            horizontalInput = 1;
        }
        else if(Input.GetKey("q")){
            horizontalInput = -1;
        }
        else
            horizontalInput = 0;
        
        if(Input.GetKey("z")){
            verticalInput = 1;
        }
        else if(Input.GetKey("s")){
            verticalInput = -1;
        }
        else
            verticalInput = 0;
        // if( verticalInput == 0 && horizontalInput == 0){
        //     Anim.SetBool("Run", false);
        // }
    }

    private void MovePlayer(){
        
        // if (verticalInput != 0 && !Anim.GetCurrentAnimatorStateInfo(0).IsName("Run") || horizontalInput != 0 && !Anim.GetCurrentAnimatorStateInfo(0).IsName("Run")){
            // Anim.SetBool("Run", true);
        // }
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);
        rb.drag = groundDrag;
    }
}
