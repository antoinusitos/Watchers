using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Prototype
{
    public enum UICategory
    {
        INVENTORY,
        CRAFT,
        PLAYERSTATS
    }

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

        public GameObject locationPanel = null;
        public Text locationText = null;
        private Coroutine showTextCoroutine = null;
        private const float locationShowTime = 2.0f;

        private UICategory currentUICategory = UICategory.INVENTORY;
        public PrototypeUICategory[] UIPages = null;

        private PrototypePlayer player = null;

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

            playerInput.playerInputs.Land.NextPage.performed += _ => NextPage();
            playerInput.playerInputs.Land.PreviousPage.performed += _ => PreviousPage();

            player = playerInput.GetComponent<PrototypePlayer>();

            for(int i = 0; i < UIPages.Length; i++)
            {
                UIPages[i].player = player;
            }
        }

        private void Switch()
        {
            if (player.playerState == PlayerState.INVENTORY)
            {
                UIPages[(int)currentUICategory].Close();
                player.playerState = PlayerState.IDLE;
            }
            else
            {
                player.playerState = PlayerState.INVENTORY;
                currentUICategory = UICategory.INVENTORY;
                UIPages[(int)currentUICategory].Open();
            }
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
            player.playerState = PlayerState.IDLE;
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

        private void NextPage()
        {
            if (currentUICategory == UICategory.PLAYERSTATS)
                return;

            UIPages[(int)currentUICategory].Close();

            currentUICategory++;

            UIPages[(int)currentUICategory].Open();
        }

        private void PreviousPage()
        {
            if (currentUICategory == UICategory.INVENTORY)
                return;

            UIPages[(int)currentUICategory].Close();

            currentUICategory--;

            UIPages[(int)currentUICategory].Open();
        }

        public void PickupObject(int ID, bool alreadySeen)
        {
            PrototypeItem item = dataBase.GetItemWithID(ID);
            if (item == null)
            {
                Debug.LogError("Item is null for ID :" + ID);
                return;
            }

            if (alreadySeen)
            {
                pickupText.text = PrototypeTraductionManager.instance.GetText(item.nameTradID);

                if (pickupCoroutine != null)
                {
                    StopCoroutine(pickupCoroutine);
                    pickupPanel.SetActive(false);
                }
                pickupCoroutine = StartCoroutine("PickUp");
            }
            else
            {
                pickupTextHigh.text = PrototypeTraductionManager.instance.GetText(item.nameTradID);
                if (pickupHighCoroutine != null)
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
            player.playerState = PlayerState.UI;
            waitingToCloseHight = true;
        }

        public void ShowLocation(string location)
        {
            if (showTextCoroutine != null)
                StopCoroutine(showTextCoroutine);

            showTextCoroutine = StartCoroutine(ShowLocationAnimation(location));
        }

        private IEnumerator ShowLocationAnimation(string location)
        {
            locationPanel.SetActive(true);
            locationText.text = location;
            yield return new WaitForSeconds(locationShowTime);
            locationPanel.SetActive(false);
        }
    }
}