using UnityEngine;
using UnityEngine.EventSystems;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using Photon.Realtime;

using System.Collections;

namespace Photon.Pun.Demo.PunBasics
{
    public class PlayerManager : MonoBehaviourPunCallbacks
    {
        [Tooltip("The local player instance. Use this to know if the local player is represented in the Scene")]
        public static GameObject LocalPlayerInstance;
        /// MonoBehaviour method called on GameObject by Unity during initialization phase.
        /// </summary>

        [Tooltip("The Player's UI GameObject Prefab")]
        [SerializeField]

        void Awake(){
            if (photonView.IsMine)
            {
                PlayerManager.LocalPlayerInstance = this.gameObject;
            }
            // #Critical
            // we flag as don't destroy on load so that instance survives level synchronization, thus giving a seamless experience when levels load.
            DontDestroyOnLoad(this.gameObject);
        }

        void Start()
        {
            if(GetComponent<PhotonView>().IsMine){
                GameObject rig = GameObject.FindGameObjectsWithTag("Pp")[0];
                rig.transform.SetParent(transform);
                transform.GetChild(0).SetParent(rig.transform.GetChild(0).GetChild(4));
                transform.GetChild(1).SetParent(rig.transform.GetChild(0).GetChild(5));
                // this.GetComponent<CharacterCameraConstraint>().CameraRig = rig;
                // this.GetComponent<SimpleCapsuleWithStickMovement>().CameraRig = rig;
            }
            // if (_cameraWork != null)
            // {
            //     if (photonView.IsMine)
            //     {
            //         // _cameraWork.OnStartFollowing();
            //     }
            // }
            // else
            // {
            //     Debug.LogError("<Color=Red><a>Missing</a></Color> CameraWork Component on playerPrefab.", this);
            // }
        }
    }
}
