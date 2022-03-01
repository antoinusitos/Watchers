using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Prototype
{
    public class PrototypeUIManager : MonoBehaviour
    {
        public static PrototypeUIManager instance = null;

        public Slider lifeSlider = null;
        private RectTransform lifeSliderTransform = null;

        public PrototypeEntityStats playerStats = null;

        public GameObject pickupPanel = null;
        public Text pickupText = null;
        private Coroutine pickupCoroutine = null;
        private const float dislayPickup = 1.5f;

        public PrototypeObjectDataBase dataBase = null;

        private PrototypePlayerInput playerInput = null;

        public GameObject pickupPanelHigh = null;
        public Text pickupTextHigh = null;
        private Coroutine pickupHighCoroutine = null;
        private bool waitingToCloseHight = false;
        private bool justCloseHight = false;

        private void Awake()
        {
            instance = this;
            lifeSlider.maxValue = playerStats.GetMaxLife();
            lifeSlider.minValue = 0;
            lifeSlider.value = lifeSlider.maxValue;
            lifeSliderTransform = lifeSlider.GetComponent<RectTransform>();
        }

        private void Start()
        {
            playerInput = FindObjectOfType<PrototypePlayerInput>();
            playerInput.playerInputs.Land.Inventory.performed += _ => Switch();
            playerInput.playerInputs.Land.Interact.performed += _ => ClosePickupHigh();
        }

        private void Switch()
        {
            PrototypeInventoryUIManager.instance.Switch();
        }

        private void Update()
        {
            if(playerStats && playerStats.lifeValueDirty)
            {
                lifeSlider.maxValue = playerStats.GetMaxLife();
                lifeSlider.value = playerStats.GetLife();
                playerStats.lifeValueDirty = false;
                Vector2 size = Vector2.one * 40;
                size.x = lifeSlider.maxValue;
                lifeSliderTransform.sizeDelta = size;
            }
        }

        private void ClosePickupHigh()
        {
            if (!waitingToCloseHight)
                return;

            waitingToCloseHight = false;
            justCloseHight = true;
            pickupPanelHigh.SetActive(false);
        }

        public bool GetWaitingToCloseHight()
        {
            return waitingToCloseHight;
        }

        public bool GetJustCloseHight()
        {
            return justCloseHight;
        }

        public void ResetJustCloseHight()
        {
            justCloseHight = false;
        }

        public void PickupObject(int ID)
        {
            PrototypeItem item = dataBase.GetItemWithID(ID);
            if (item == null)
            {
                Debug.LogError("Item is null for ID :" + ID);
                return;
            }

            if (item.itemImportance == ItemImportance.LOW)
            {
                pickupText.text = item.name;

                if (pickupCoroutine != null)
                {
                    StopCoroutine(pickupCoroutine);
                    pickupPanel.SetActive(false);
                }
                pickupCoroutine = StartCoroutine("PickUp");
            }
            else
            {
                pickupTextHigh.text = item.name;
                if(pickupHighCoroutine != null)
                {
                    StopCoroutine(pickupHighCoroutine);
                    pickupPanelHigh.SetActive(false);
                }
                pickupHighCoroutine = StartCoroutine("PickUpHigh");
            }
        }

        private IEnumerator PickUp()
        {
            yield return new WaitForSeconds(0.1f);
            pickupPanel.SetActive(true);
            yield return new WaitForSeconds(dislayPickup);
            pickupPanel.SetActive(false);
        }

        private IEnumerator PickUpHigh()
        {
            yield return new WaitForSeconds(0.1f);
            pickupPanelHigh.SetActive(true);
            waitingToCloseHight = true;
        }
    }
}