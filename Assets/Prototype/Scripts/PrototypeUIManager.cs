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

        private void Awake()
        {
            instance = this;
            lifeSlider.maxValue = playerStats.GetMaxLife();
            lifeSlider.minValue = 0;
            lifeSlider.value = lifeSlider.maxValue;
            lifeSliderTransform = GetComponent<RectTransform>();
        }

        private void Update()
        {
            if(playerStats && playerStats.lifeValueDirty)
            {
                lifeSlider.value = playerStats.GetLife();
                playerStats.lifeValueDirty = false;
                lifeSlider.maxValue = playerStats.GetMaxLife();
                lifeSliderTransform.sizeDelta = new Vector2(lifeSlider.maxValue, lifeSliderTransform.sizeDelta.y);
                Debug.Log("lifeSlider.maxValue:" + lifeSlider.maxValue);
            }

            if(Input.GetKeyDown(KeyCode.K))
            {
                playerStats.AddMaxLife(10);
            }
        }
    }
}