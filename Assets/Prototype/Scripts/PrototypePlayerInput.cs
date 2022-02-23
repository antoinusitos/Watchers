using UnityEngine;

namespace Prototype
{
    public class PrototypePlayerInput : MonoBehaviour
    {
        public PlayerInputs playerInputs = null;

        private void Awake()
        {
            playerInputs = new PlayerInputs();
        }

        private void OnEnable()
        {
            playerInputs.Enable();
        }

        private void OnDisable()
        {
            playerInputs.Disable();
        }
    }
}