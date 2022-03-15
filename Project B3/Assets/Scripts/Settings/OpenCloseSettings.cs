using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Settings
{
    public class OpenCloseSettings : MonoBehaviour
    {
        public Camera playerCamera;
        public int distance;

        public void OpenSettingsMenu()
        {
            Transform cameratransform = playerCamera.transform;

            Vector3 direction = cameratransform.forward;
            transform.rotation = Quaternion.LookRotation(direction);

            Vector3 newPos = cameratransform.position + (direction * distance);
            transform.position = newPos;
            this.enabled = true;

        }

        public void CloseSettingsMenu()
        {
            this.enabled = false;
        }
    }
}