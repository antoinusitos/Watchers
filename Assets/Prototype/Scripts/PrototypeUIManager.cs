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
    }
}