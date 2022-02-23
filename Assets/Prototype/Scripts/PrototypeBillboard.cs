using UnityEngine;

namespace Prototype
{
    public class PrototypeBillboard : MonoBehaviour
    {
        private RectTransform rect = null;


        private void Awake()
        {
            rect = GetComponent<RectTransform>();
            rect.rotation = Quaternion.Euler(-70, -180, 0);
        }
    }
}