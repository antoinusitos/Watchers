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
        }

        private void Start()
        {
            playerInput = GetComponent<PrototypePlayerInput>();
            playerInput.playerInputs.Land.Interact.performed += _ => Interact();
        }

        public void SetInteractable(PrototypeInteractable interact)
        {
            if(interactable && interactable.interactionFeedback)
                interactable.interactionFeedback.SetActive(false);

            interactable = interact;

            if (interactable && interactable.interactionFeedback)
                interactable?.interactionFeedback?.SetActive(true);
        }

        public void RemoveInteractable(PrototypeInteractable interact)
        {
            if (interactable != interact)
                return;

            interactable?.interactionFeedback?.SetActive(false);

            interactable = null;
        }

        private void Interact()
        {
            if (!interactable)
                return;

            if (interactable.GetType() == typeof(PrototypeItem))
            {
                PrototypePickup pickup = (PrototypePickup)interactable;
                inventory.Add(pickup.ID);
                PrototypeUIManager.instance.PickupObject(pickup.ID);
                Destroy(pickup.gameObject);
            }
            else if (interactable.GetType() == typeof(PrototypeAI))
            {
                PrototypeAI ai = (PrototypeAI)interactable;
                ai.Execute();
            }
        }
    }
}