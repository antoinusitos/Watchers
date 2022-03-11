using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Prototype
{
    [System.Serializable]
    public class UITextTrad
    {
        public int traductionID = -1;
        public Text text = null;
    }

    public class PrototypeUITraductor : MonoBehaviour
    {
        public List<UITextTrad> toTranslateText = new List<UITextTrad>();

        private void OnEnable()
        {
            PrototypeTraductionManager prototypeTraductionManager = PrototypeTraductionManager.instance;
            for(int i = 0; i < toTranslateText.Count; i++)
            {
                toTranslateText[i].text.text = prototypeTraductionManager.GetText(toTranslateText[i].traductionID);
            }
        }
    }
}