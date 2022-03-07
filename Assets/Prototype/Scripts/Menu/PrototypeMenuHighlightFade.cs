using UnityEngine;
using UnityEngine.UI;

namespace Prototype
{
    public class PrototypeMenuHighlightFade : MonoBehaviour
    {
        public float minShining = 0f;
        public float maxShining = 1.0f;
        private bool goingUp = true;

        private Image backgroundImage = null;
        private Color color = Color.black;

        public float shiningSpeed = 1.0f;

        private void Start()
        {
            backgroundImage = GetComponent<Image>();
            color = backgroundImage.color;
        }

        private void Update()
        {
            if (goingUp)
            {
                color.a += Time.deltaTime * shiningSpeed;
                if (color.a >= maxShining)
                {
                    color.a = maxShining;
                    goingUp = false;
                }
            }
            else
            {
                color.a -= Time.deltaTime * shiningSpeed;
                if (color.a <= minShining)
                {
                    color.a = minShining;
                    goingUp = true;
                }
            }
            backgroundImage.color = color;
        }
    }
}