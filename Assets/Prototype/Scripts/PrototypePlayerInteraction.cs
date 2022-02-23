using UnityEngine;

namespace Prototype
{
    public class PrototypePlayerInteraction : MonoBehaviour
    {
        private PrototypeInteractable interactable = null;

        private PrototypeInventory inventory = null;

        private PrototypePlayerInput playerInput = null;

        private void Awake()
        {
            inventory = GetComponent<PrototypeInventory>();
            playerInput = GetComponent<PrototypePlayerInput>();
            playerInput.playerInputs.Land.Interact.performed += _ => Interact();
        }

        public void SetInteractable(PrototypeInteractable interact)
        {
            interactable?.interactionFeedback?.SetActive(false);

            interactable = interact;

            interactable?.interactionFeedback?.SetActive(true);
        }

        private void Interact()
        {
            if (!interactable)
                return;

            PrototypePickup pickup = (PrototypePickup)interactable;
            if (pickup)
            {
                inventory.Add(pickup.ID);
                Destroy(pickup.gameObject);
            }
        }
    }
}