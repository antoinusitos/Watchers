using UnityEngine;

namespace Prototype
{
    public class PrototypeAI : PrototypeInteractable
    {
        public int dialogueID = -1;

        private void Awake()
        {
            normalInteraction = false;
        }

        public override void Execute()
        {
            base.Execute();

            Debug.Log("Execute PrototypeAI");
            PrototypeDialogueManager.instance.LaunchDialogue(dialogueID);
        }

        private void OnTriggerEnter(Collider other)
        {
            PrototypePlayerInteraction playerInteraction = other.GetComponent<PrototypePlayerInteraction>();
            if(playerInteraction)
            {
                playerInteraction.SetInteractable(this);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            PrototypePlayerInteraction playerInteraction = other.GetComponent<PrototypePlayerInteraction>();
            if (playerInteraction)
            {
                playerInteraction.RemoveInteractable(this);
                PrototypeDialogueManager.instance.StopDialogue();
            }
        }
    }
}