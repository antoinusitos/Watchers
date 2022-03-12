using System.Collections;
using UnityEngine;

namespace Prototype
{
    public class PrototypeStatue : PrototypeInteractable
    {
        private PrototypePlayerInteraction player = null;
        private PrototypePlayerMovement playerMovement = null;
        private bool isKneeled = false;
        private bool isTransiting = false;

        private void Awake()
        {
            normalInteraction = false;
        }

        public override void Execute()
        {
            if (isTransiting)
                return;

            base.Execute();

            playerMovement = player.GetComponent<PrototypePlayerMovement>();
            playerMovement.canMove = false;

            playerMovement.transform.position = transform.position;
            playerMovement.transform.GetChild(0).rotation = transform.rotation;

            StartCoroutine(Kneel());
        }

        private IEnumerator Kneel()
        {
            isTransiting = true;

            if (!isKneeled)
                playerMovement.animator.SetTrigger("Kneel");
            else
                playerMovement.animator.SetTrigger("StandUp");
            
            isKneeled = !isKneeled;

            yield return new WaitForSeconds(2.8f);

            isTransiting = false;

            if (!isKneeled)
            {
                playerMovement.canMove = true;
            }
            else
            {
                PrototypeSaveManager.instance.Save();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            PrototypePlayerInteraction playerInteraction = other.GetComponent<PrototypePlayerInteraction>();
            if (playerInteraction)
            {
                player = playerInteraction;
                playerInteraction.SetInteractable(this);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            PrototypePlayerInteraction playerInteraction = other.GetComponent<PrototypePlayerInteraction>();
            if (playerInteraction)
            {
                playerInteraction.RemoveInteractable(this);
            }
        }
    }
}