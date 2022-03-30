using UnityEngine;
using Facebook.WitAi;

namespace Oculus.Voice.Demo.BuiltInDemo
{
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
}