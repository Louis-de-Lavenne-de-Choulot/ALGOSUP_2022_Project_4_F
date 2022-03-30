using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.WitAi;

public class Nevermind : MonoBehaviour
{
    [SerializeField] private Wit wit;

    private void OnValidate()
    {
        if (!wit) wit = GetComponent<Wit>();
    }

    public void NeverMind()
    {
        wit.Deactivate();
    }
}
