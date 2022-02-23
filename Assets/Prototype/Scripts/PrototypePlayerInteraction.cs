using UnityEngine;

namespace Prototype
{
    public class PrototypePlayerInteraction : MonoBehaviour
    {
        private PrototypeInteractable interactable = null;

        private PrototypeInventory inventory = null;

        private void Awake()
        {
            inventory = GetComponent<PrototypeInventory>();
        }

        public void SetInteractable(PrototypeInteractable interact)
        {
            interactable?.interactionFeedback?.SetActive(false);

            interactable = interact;

            interactable?.interactionFeedback?.SetActive(true);
        }

        private void Update()
        {
            if(interactable && Input.GetKeyDown(KeyCode.F))
            {
                PrototypePickup pickup = (PrototypePickup)interactable;
                if (pickup)
                {
                    inventory.Add(pickup.ID);
                    Destroy(pickup.gameObject);
                }
            }
        }
    }
}