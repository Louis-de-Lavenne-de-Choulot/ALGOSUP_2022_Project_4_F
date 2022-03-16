using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;
using TMPro;

public class VRcontrolls : MonoBehaviour
{
    public TMP_Text mesco;
    public Transform player;
    public Transform cam;
    [SerializeField] private float _hudRefreshRate = 1f;
    private float _timer;
    private void Update()
    {
        if (Time.unscaledTime > _timer)
        {
            int fps = (int)(1f / Time.unscaledDeltaTime);
            mesco.text = "FPS: " + fps;
            _timer = Time.unscaledTime + _hudRefreshRate;
        }
    }

}
