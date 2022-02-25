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

        private void Awake()
        {
            instance = this;
            lifeSlider.maxValue = playerStats.GetMaxLife();
            lifeSlider.minValue = 0;
            lifeSlider.value = lifeSlider.maxValue;
            lifeSliderTransform = lifeSlider.GetComponent<RectTransform>();
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

        public void PickupObject(int ID)
        {
            PrototypeItem item = dataBase.GetItemWithID(ID);
            if (item == null)
            {
                Debug.LogError("Item is null for ID :" + ID);
                return;
            }

            pickupText.text = item.name;
            if(pickupCoroutine != null)
            {
                StopCoroutine(pickupCoroutine);
                pickupPanel.SetActive(false);
            }
            pickupCoroutine = StartCoroutine("PickUp");
        }

        private IEnumerator PickUp()
        {
            yield return new WaitForSeconds(0.1f);
            pickupPanel.SetActive(true);
            yield return new WaitForSeconds(dislayPickup);
            pickupPanel.SetActive(false);
        }
    }
}