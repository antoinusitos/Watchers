using UnityEngine;
using UnityEngine.Events;

namespace Prototype
{
    public class PrototypeEvents : MonoBehaviour
    {
        public UnityEvent events = null;

        private void OnTriggerEnter(Collider other)
        {
            PrototypePlayer prototypePlayer = other.GetComponent<PrototypePlayer>();
            if (prototypePlayer != null)
            {
                events.Invoke();
            }
        }
    }
}