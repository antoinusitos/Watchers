using UnityEngine;
using UnityEngine.UI;

namespace Prototype
{
    public class PrototypeUICategory : MonoBehaviour
    {
        public GameObject inventoryWindow = null;

        public PrototypePlayer player = null;

        public Text goldText = null;

        private const string goldString = ": ";

        protected PrototypeInventory playerInventory = null;

        protected bool isOpen = false;

        public virtual void Open()
        {
            if(playerInventory == null)
                playerInventory = FindObjectOfType<PrototypeInventory>();

            isOpen = true;

            inventoryWindow.SetActive(true);
            Refresh();
        }

        public virtual void Close()
        {
            isOpen = false;

            inventoryWindow.SetActive(false);
        }

        public virtual void Refresh()
        {
            goldText.text = goldString + playerInventory.gold;
        }
    }
}