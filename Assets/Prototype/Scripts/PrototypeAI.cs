using System.Collections.Generic;
using UnityEngine;

namespace Prototype
{
    public class PrototypeAI : PrototypeInteractable
    {
        public int dialogueID = -1;

        public List<DialogEvent> dialogEvent = new List<DialogEvent>();

        private void Awake()
        {
            normalInteraction = false;
        }

        public override void Execute()
        {
            base.Execute();

            PrototypeDialogueManager.instance.LaunchDialogue(dialogueID, this);
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