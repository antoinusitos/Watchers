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

        private const string goldString = ": ";

        private PrototypePlayerInput playerInput = null;

        private ItemType currentItemType = ItemType.WEAPON;

        public Text categoryText = null;

        private PrototypePlayer player = null;

        public Image[] categoryImages = null;

        private Color transparentColor = Color.white;

        private void Awake()
        {
            instance = this;
            transparentColor.a = 0;
        }

        private void Start()
        {
            playerInput = FindObjectOfType<PrototypePlayerInput>();
            playerInput.playerInputs.Land.MenuRight.performed += _ => MoveRight();
            playerInput.playerInputs.Land.MenuLeft.performed += _ => MoveLeft();
            player = playerInput.GetComponent<PrototypePlayer>();
        }
        private void MoveRight()
        {
            if (!isOpen)
                return;

            categoryImages[(int)currentItemType].color = transparentColor;

            currentItemType++;

            if (currentItemType >= ItemType.SIZE)
                currentItemType = 0;

            categoryImages[(int)currentItemType].color = Color.white;

            ShowItemsOfType(currentItemType);
        }

        private void MoveLeft()
        {
            if (!isOpen)
                return;

            categoryImages[(int)currentItemType].color = transparentColor;

            currentItemType--;
            if (currentItemType < 0)
                currentItemType = ItemType.SIZE-1;

            categoryImages[(int)currentItemType].color = Color.white;

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
            player.playerState = PlayerState.UI;
            Refresh();
        }

        public void Close()
        {
            inventoryWindow.SetActive(false);
            player.playerState = PlayerState.IDLE;
        }

        public void Refresh()
        {
            goldText.text = goldString + playerInventory.gold;

            ShowItemsOfType(ItemType.WEAPON);
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