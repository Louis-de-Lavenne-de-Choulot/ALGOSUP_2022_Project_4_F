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
    }

    private void Baba(){
        // foreach (Transform go in goal){
        foreach (Transform child in goal)
        {
            Debug.Log(child);
            GameObject obj = Instantiate(toInit, new Vector3(Random.Range(recept.   position.x-20, recept.position.x+20), recept.position.y,Random.Range    (recept.position.z-20, recept.position.z+20)),Quaternion.identity) as GameObject;
            UnityEngine.AI.NavMeshAgent nobj = obj.GetComponent<UnityEngine.AI.NavMeshAgent>();
            nobj.speed = 5;
            nobj.destination = child.position;
        }
    }
}
