using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    private static float timer;
    public static int intTimer;

    void Update ()
    {
        timer += Time.deltaTime;
        intTimer = (int)timer;
    }
}