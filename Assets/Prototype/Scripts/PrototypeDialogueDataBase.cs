using System.Collections.Generic;
using UnityEngine;

namespace Prototype
{
    [CreateAssetMenu(fileName = "PrototypeDialogueDataBase", menuName = "ScriptableObjects/PrototypeDialogueDataBase", order = 2)]
    public class PrototypeDialogueDataBase : ScriptableObject
    {
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
}