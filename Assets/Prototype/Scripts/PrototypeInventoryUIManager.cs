using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Prototype
{
    public class PrototypeInventoryUIManager : MonoBehaviour
    {
        public static PrototypeInventoryUIManager instance = null;

        private bool isOpen = false;

        public GameObject inventoryWindow = null;

        public PrototypeInventory playerInventory = null;

        public Text goldText = null;

        public Transform itemsPanel = null;

        public GameObject itemsPrefab = null;

        private void Awake()
        {
            instance = this;
        }

        public void Switch()
        {
            if(isOpen)
            {
                Close();
            }
            else
            {
                Open();
            }
            isOpen = !isOpen;
        }

        public void Open()
        {
            inventoryWindow.SetActive(true);
            Refresh();
        }

        public void Close()
        {
            inventoryWindow.SetActive(false);
        }

        private void Refresh()
        {
            goldText.text = "Gold : " + playerInventory.gold;

            for(int i = 0; i < itemsPanel.childCount; i++)
            {
                Destroy(itemsPanel.GetChild(i).gameObject);
            }

            List<PrototypeItem> items = playerInventory.GetItems();

            for (int i = 0; i < items.Count; i++)
            {
                Instantiate(itemsPrefab, itemsPanel);
            }
        }
    }
}