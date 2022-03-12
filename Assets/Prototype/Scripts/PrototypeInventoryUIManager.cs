using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Prototype
{
    public class PrototypeInventoryUIManager : PrototypeUICategory
    {
        public static PrototypeInventoryUIManager instance = null;

        public Transform itemsPanel = null;

        public PrototypeUIItem itemsPrefab = null;

        private PrototypePlayerInput playerInput = null;

        private ItemType currentItemType = ItemType.WEAPON;

        public Text categoryText = null;

        public Image[] categoryImages = null;

        private Color transparentColor = Color.white;

        public Text itemNameText = null;
        public Text itemDescText = null;

        private List<PrototypeUIItem> prototypeUIItems = new List<PrototypeUIItem>();
        private List<PrototypeItem> currentItems = new List<PrototypeItem>();

        private bool hasMoved = false;

        private int currentItemIndex = 0;

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
        }

        private void Update()
        {
            if (!isOpen)
                return;

            if (prototypeUIItems.Count <= 0)
                return;

            Vector2 move = playerInput.playerInputs.Land.Move.ReadValue<Vector2>();

            if (hasMoved)
            {
                if (move.x == 0 && move.y == 0)
                    hasMoved = false;

                return;
            }

            if(move.x > 0)
            {
                prototypeUIItems[currentItemIndex].Select(false);
                currentItemIndex++;
                if (currentItemIndex >= currentItems.Count)
                    currentItemIndex = 0;
                hasMoved = true;
                SelectItem();
            }
            else if (move.x < 0)
            {
                prototypeUIItems[currentItemIndex].Select(false);
                currentItemIndex--;
                if (currentItemIndex < 0)
                    currentItemIndex = currentItems.Count - 1;
                hasMoved = true;
                SelectItem();
            }
        }

        public override void Close()
        {
            base.Close();

            categoryImages[(int)currentItemType].color = transparentColor;

            currentItemType = ItemType.WEAPON;

            categoryImages[(int)currentItemType].color = Color.white;
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

        public override void Refresh()
        {
            base.Refresh();

            ShowItemsOfType(ItemType.WEAPON);
        }

        private void ShowItemsOfType(ItemType itemType)
        {
            currentItemIndex = 0;

            categoryText.text = itemType.ToString();

            prototypeUIItems.Clear();

            for (int i = 0; i < itemsPanel.childCount; i++)
            {
                Destroy(itemsPanel.GetChild(i).gameObject);
            }

            List<PrototypeItem> tempItemList = playerInventory.GetItems();
            currentItems = new List<PrototypeItem>();

            for (int i = 0; i < tempItemList.Count; i++)
            {
                if (tempItemList[i].itemType != itemType)
                    continue;

                currentItems.Add(tempItemList[i]);
                PrototypeUIItem go = Instantiate(itemsPrefab, itemsPanel);
                go.itemImage.sprite = tempItemList[i].sprite;
                go.quantityText.text = tempItemList[i].quantity.ToString();
                prototypeUIItems.Add(go);
            }

            if (currentItems.Count > 0)
                SelectItem();
        }

        private void SelectItem()
        {
            prototypeUIItems[currentItemIndex].Select(true);
            itemNameText.text = PrototypeTraductionManager.instance.GetText(currentItems[currentItemIndex].nameTradID);
            itemDescText.text = PrototypeTraductionManager.instance.GetText(currentItems[currentItemIndex].descTradID);
        }
    }
}