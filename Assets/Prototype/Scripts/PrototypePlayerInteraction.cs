using UnityEngine;

namespace Prototype
{
    public class PrototypePlayerInteraction : MonoBehaviour
    {
        private PrototypeInteractable interactable = null;

        private PrototypeInventory inventory = null;

        private PrototypePlayerInput playerInput = null;

        private PrototypePlayer player = null;

        private void Awake()
        {
            inventory = GetComponent<PrototypeInventory>();
        }

        private void Start()
        {
            playerInput = GetComponent<PrototypePlayerInput>();
            player = playerInput.GetComponent<PrototypePlayer>();
            playerInput.playerInputs.Land.Interact.performed += _ => Interact();
        }

        public void SetInteractable(PrototypeInteractable interact)
        {
            if(interactable && interactable.interactionFeedback)
                interactable.interactionFeedback.SetActive(false);

            interactable = interact;

            if (interactable && interactable.interactionFeedback)
                interactable.interactionFeedback.SetActive(true);
        }

        public void RemoveInteractable(PrototypeInteractable interact)
        {
            if (interactable != interact)
                return;

            if (interactable == null)
                return;

            if (interactable.interactionFeedback == null)
                return;

            interactable.interactionFeedback.SetActive(false);

            interactable = null;
        }

        private void Interact()
        {
            if (!interactable)
                return;

            if (player.playerState == PlayerState.UI)
                return;

            if (interactable.GetType() == typeof(PrototypePickup))
            {
                PrototypePickup pickup = (PrototypePickup)interactable;
                inventory.Add(pickup.ID);
                bool alreadySeen = false;
                if(inventory.objectsCollected.Contains(pickup.ID))
                {
                    alreadySeen = true;
                }
                else
                {
                    inventory.objectsCollected.Add(pickup.ID);
                }
                PrototypeUIManager.instance.PickupObject(pickup.ID, alreadySeen);
                Destroy(pickup.gameObject);
            }
            else if (interactable.GetType() == typeof(PrototypeAI))
            {
                PrototypeAI ai = (PrototypeAI)interactable;
                ai.Execute();
            }
            else
            {
                interactable.Execute();
            }
        }
    }
}