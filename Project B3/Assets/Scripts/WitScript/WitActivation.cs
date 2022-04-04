using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.WitAi;

public class WitActivation : MonoBehaviour
{
    [SerializeField] private Wit wit;

    private void OnValidate()
    {
        if (!wit) wit = GetComponent<Wit>();
    }

    void Update()
    {
        wit.Activate();
    }
}
