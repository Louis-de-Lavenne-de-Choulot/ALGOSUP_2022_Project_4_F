using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    public GameObject toInit;
    public Transform recept;
    // Start is called before the first frame update
    void Start()
    {
        //float myRand = Random.Range();
        InvokeRepeating("Baba", 2F, 0.6F);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Baba(){
        Instantiate(toInit, recept.position, Quaternion.identity);
    }
}
