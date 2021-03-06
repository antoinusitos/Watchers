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

        private PrototypeAI currentAI = null;

        private bool preventSkip = true;

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

            if (preventSkip)
            {
                preventSkip = false;
                return;
            }

            skip = true;
        }

        public void LaunchDialogue(int ID, PrototypeAI prototypeAI)
        {
            if (isInDialog)
                return;

            if (dialogCoroutine != null)
                StopCoroutine(dialogCoroutine);

            currentAI = prototypeAI;

            dialogCoroutine = StartCoroutine(CoroutineLaunchDialogue(ID));
        }

        private void HandleEvent(int textID)
        {
            for (int e = 0; e < currentAI.dialogEvent.Count; e++)
            {
                if (currentAI.dialogEvent[e].ID == textID)
                {
                    currentAI.dialogEvent[e].events.Invoke();
                    break;
                }
            }
        }

        public IEnumerator CoroutineLaunchDialogue(int ID)
        {
            preventSkip = true;

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

                    if (dialogue.texts[i].isEvent)
                    {
                        HandleEvent(dialogue.texts[i].textID);
                        yield return new WaitForSeconds(0.11f);
                        if (PrototypeUIManager.instance.GetWaitingToCloseHight())
                        {
                            while(!PrototypeUIManager.instance.GetJustCloseHight())
                            {
                                yield return null;
                            }
                            preventSkip = true;
                            PrototypeUIManager.instance.ResetJustCloseHight();
                        }
                        else
                        {
                            yield return new WaitForSeconds(dialogue.texts[i].time);
                        }
                        continue;
                    }

                    skip = false;
                    dialogText.text = PrototypeTraductionManager.instance.GetText(dialogue.texts[i].textID);
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
                    dialogText.text = "";
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