using UnityEngine;

namespace Prototype
{
    public class PrototypeLivingTreeShake : MonoBehaviour
    {
        private PrototypeCameraShakeManager cameraSkake = null;

        private bool shake = false;

        private void Start()
        {
            cameraSkake = PrototypeCameraShakeManager.instance;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                shake = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                shake = false;
            }
        }

        public void Shake()
        {
            if (!shake)
                return;

            cameraSkake.Shake();
        }
    }
}