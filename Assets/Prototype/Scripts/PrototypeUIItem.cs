using UnityEngine;
using UnityEngine.UI;

namespace Prototype
{
    public class PrototypeUIItem : MonoBehaviour
    {
        public Image background = null;

        public Image itemImage = null;

        public Text quantityText = null;

        private Color transparent = new Color(1, 1, 1, 0);

        public void Select(bool state)
        {
            if(state)
            {
                background.color = Color.white;
            }
            else
            {
                background.color = transparent;
            }
        }
    }
}