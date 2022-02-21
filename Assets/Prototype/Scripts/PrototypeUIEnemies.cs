using UnityEngine;
using UnityEngine.UI;

namespace Prototype
{
    public class PrototypeUIEnemies : MonoBehaviour
    {
        public Slider lifeSlider = null;
        private RectTransform lifeSliderTransform = null;

        private PrototypeEntityStats entityStats = null;

        private void Awake()
        {
            entityStats = GetComponent<PrototypeEntityStats>();
            lifeSlider.maxValue = entityStats.GetMaxLife();
            lifeSlider.minValue = 0;
            lifeSlider.value = lifeSlider.maxValue;
            lifeSliderTransform = lifeSlider.GetComponent<RectTransform>();
        }

        private void Update()
        {
            if (entityStats && entityStats.lifeValueDirty)
            {
                lifeSlider.maxValue = entityStats.GetMaxLife();
                lifeSlider.value = entityStats.GetLife();
                entityStats.lifeValueDirty = false;
                Vector2 size = Vector2.one * 25;
                size.x = lifeSlider.maxValue;
                lifeSliderTransform.sizeDelta = size;
            }
        }
    }
}