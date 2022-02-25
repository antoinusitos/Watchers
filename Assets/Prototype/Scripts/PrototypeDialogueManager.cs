using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Prototype
{
    public class PrototypeDialogueManager : MonoBehaviour
    {
        public static PrototypeDialogueManager instance = null;

        public PrototypeDialogueDataBase prototypeDialogueDataBase = null;

        public Text dialogText = null;

        public GameObject dialogPanel = null;

        private bool skip = false;

        private PrototypePlayerInput playerInput = null;

        private Coroutine dialogCoroutine;

        private bool isInDialog = false;

        private bool stopDialogue = false;

        private void Awake()
        {
            instance = this;

            playerInput = FindObjectOfType<PrototypePlayerInput>();
        }

        private void Start()
        {
            playerInput.playerInputs.Land.Interact.performed += _ => Skip();
        }

        private void Skip()
        {
            if (!isInDialog)
                return;

            skip = true;
        }

        public void LaunchDialogue(int ID)
        {
            if (isInDialog)
                return;

            if (dialogCoroutine != null)
                StopCoroutine(dialogCoroutine);

            dialogCoroutine = StartCoroutine(CoroutineLaunchDialogue(ID));
        }

        public IEnumerator CoroutineLaunchDialogue(int ID)
        {
            Dialogue dialogue = prototypeDialogueDataBase.GetDialogueWithID(ID);
            float timer = 0;
            stopDialogue = false;
            if (dialogue != null)
            {
                isInDialog = true;
                dialogPanel.SetActive(true);
                for (int i = 0; i < dialogue.texts.Count; i++)
                {
                    if(stopDialogue)
                    {
                        stopDialogue = false;
                        yield break;
                    }

                    skip = false;
                    dialogText.text = dialogue.texts[i].text;
                    while (timer < dialogue.texts[i].time)
                    {
                        timer += Time.deltaTime;

                        if (stopDialogue)
                        {
                            break;
                        }

                        if (skip)
                        {
                            skip = false;
                            timer = dialogue.texts[i].time;
                            break;
                        }

                        yield return null;
                    }
                    timer = 0;

                    if (stopDialogue)
                    {
                        stopDialogue = false;
                        break;
                    }
                }
                dialogText.text = "";
                dialogPanel.SetActive(false);
                isInDialog = false;
            }
        }

        public void StopDialogue()
        {
            if (!isInDialog)
                return;

            stopDialogue = true;
        }
    }
}