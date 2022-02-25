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

        private const string goldString = "Gold :";

        private PrototypePlayerInput playerInput = null;

        private ItemType currentItemType = ItemType.CLOTH;

        public Text categoryText = null;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            playerInput = FindObjectOfType<PrototypePlayerInput>();
            playerInput.playerInputs.Land.MenuRight.performed += _ => MoveRight();
            playerInput.playerInputs.Land.MenuLeft.performed += _ => MoveLeft();
        }
        private void MoveRight()
        {
            if (!isOpen)
                return;

            currentItemType++;

            if (currentItemType >= ItemType.SIZE)
                currentItemType = 0;

            ShowItemsOfType(currentItemType);
        }

        private void MoveLeft()
        {
            if (!isOpen)
                return;

            currentItemType--;
            if (currentItemType < 0)
                currentItemType = ItemType.SIZE-1;

            ShowItemsOfType(currentItemType);
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
            goldText.text = goldString + playerInventory.gold;

            ShowItemsOfType(ItemType.CLOTH);
        }

        private void ShowItemsOfType(ItemType itemType)
        {
            categoryText.text = itemType.ToString();

            for (int i = 0; i < itemsPanel.childCount; i++)
            {
                Destroy(itemsPanel.GetChild(i).gameObject);
            }

            List<PrototypeItem> items = playerInventory.GetItems();

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].itemType != itemType)
                    continue;

                Transform go = Instantiate(itemsPrefab, itemsPanel).transform;
                go.GetChild(0).GetComponent<Image>().sprite = items[i].sprite;
                go.GetComponentInChildren<Text>().text = items[i].quantity.ToString();
            }
        }
    }
}