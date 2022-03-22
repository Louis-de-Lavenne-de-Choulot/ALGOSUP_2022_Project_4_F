using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using OVR;

namespace Settings
{

    public class GameSettings : MonoBehaviour
    {

        OVRCameraRig cameraRig;
        Rigidbody _rigidbody;

        public void Start()
        {
            cameraRig = GameObject.FindObjectOfType<OVRCameraRig>();
            _rigidbody = cameraRig.GetComponentInParent<Rigidbody>();
        }
        public void Respawn()
        {
            Transform point = GameObject.FindGameObjectWithTag("Respawn").transform;
            _rigidbody.transform.position = point.position;
        }

        public void ReturnToMenu()
        {
            if(SceneManager.GetActiveScene().name != "Main Menu")
            {
                SceneManager.LoadScene(1,LoadSceneMode.Single);
            }
        }

        public void StopScenario()
        {
            return;
        }
    }
}
