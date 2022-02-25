using UnityEngine;

namespace Prototype
{
    public class PrototypeInteractable : MonoBehaviour
    {
        public GameObject interactionFeedback = null;

        public bool normalInteraction = true;

        public virtual void Execute()
        {

        }
    }
}