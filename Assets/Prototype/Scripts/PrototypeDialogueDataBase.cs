using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Prototype
{
    [CreateAssetMenu(fileName = "PrototypeDialogueDataBase", menuName = "ScriptableObjects/PrototypeDialogueDataBase", order = 2)]
    public class PrototypeDialogueDataBase : ScriptableObject
    {
        [Header("Add EVENTS:X to add events in a dialog")]
        public List<Dialogue> dialogues;

        public Dialogue GetDialogueWithID(int ID)
        {
            for(int i = 0; i < dialogues.Count; i++)
            {
                if (dialogues[i].ID == ID)
                    return dialogues[i];
            }

            return null;
        }
    }

    [System.Serializable]
    public class Dialogue
    {
        public int ID;
        public List<DialogText> texts;
    }

    [System.Serializable]
    public class DialogText
    {
        public string text;
        public float time;
    }

    [System.Serializable]
    public class DialogEvent
    {
        public int ID;
        public UnityEvent events;
    }
}