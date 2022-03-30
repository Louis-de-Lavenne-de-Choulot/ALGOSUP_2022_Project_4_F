using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectionLift : MonoBehaviour
{
    public Animator liftAnim;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colide");
        if (other.gameObject.tag == "Player")
            Debug.Log("PlayerColide");
        liftAnim.SetTrigger("IsPushed");
    }
}
