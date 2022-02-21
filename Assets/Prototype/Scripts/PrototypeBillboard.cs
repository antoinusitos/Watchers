using UnityEngine;

namespace Prototype
{
    public class PrototypeBillboard : MonoBehaviour
    {
        private void Update()
        {
            transform.LookAt(Camera.main.transform);
        }
    }
}