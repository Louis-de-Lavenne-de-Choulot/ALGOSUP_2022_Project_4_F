using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    public Transform goal;
    public GameObject toInit;
    public Transform recept;
    // Start is called before the first frame update
    void Start()
    {
        //float myRand = Random.Range();
        Invoke("Baba", 2F);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, new Vector3(0, -1f, 1), Color.green);
    }

    private void Baba(){
        // foreach (Transform go in goal){
        foreach (Transform child in goal)
        {
            GameObject obj = Instantiate(toInit, new Vector3(Random.Range(recept.   position.x-12, recept.position.x+12), recept.position.y,Random.Range    (recept.position.z-12, recept.position.z+12)),Quaternion.identity) as GameObject;
            UnityEngine.AI.NavMeshAgent nobj = obj.GetComponent<UnityEngine.AI.NavMeshAgent>();
            nobj.speed = 5;
            nobj.destination = child.position;
        }
    }
}
