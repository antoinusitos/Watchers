using UnityEngine;

namespace Prototype
{
    public class PrototypePlayerPickup : MonoBehaviour
    {
        private PrototypePlayerInteraction playerInteraction = null;

        private void Awake()
        {
            playerInteraction = GetComponentInParent<PrototypePlayerInteraction>();
        }

        private void OnTriggerEnter(Collider other)
        {
            PrototypeInteractable interactable = other.GetComponent<PrototypeInteractable>();
            if(interactable && playerInteraction && interactable.normalInteraction)
            {
                playerInteraction.SetInteractable(interactable);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            PrototypeInteractable interactable = other.GetComponent<PrototypeInteractable>();
            if (interactable && playerInteraction && interactable.normalInteraction)
            {
                playerInteraction.RemoveInteractable(interactable);
            }
        }
    }
}