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
        public GameObject rig;
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
            // CameraWork _cameraWork = this.gameObject.GetComponent<CameraWork>();
            GameObject[] Cams = GameObject.FindGameObjectsWithTag("Pp");
                for (int i  = 0; i < Cams.Length; i++){
                    // Cams[i].gameObject.SetActive(false);
                    if (Cams[i].transform.GetComponent<PhotonView>().IsMine){
                        rig.transform.SetParent(Cams[i].transform);
                        Cams[i].transform.GetChild(0).SetParent(rig.transform.GetChild(0).GetChild(4));
                        Cams[i].transform.GetChild(1).SetParent(rig.transform.GetChild(0).GetChild(5));
                    }
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
