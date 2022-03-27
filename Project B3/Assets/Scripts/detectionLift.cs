using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectionLift : MonoBehaviour
{
    public Animator liftAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Player detected");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Player not detected");
        }
    }
}
