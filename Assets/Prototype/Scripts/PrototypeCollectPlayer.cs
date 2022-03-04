using UnityEngine;

namespace Prototype
{
    public class PrototypeCollectPlayer : MonoBehaviour
    {
        public PrototypeEntityStats playerStats = null;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
                return;

            PrototypeEntityStats stats = other.GetComponent<PrototypeEntityStats>();
            if (stats != null)
            {
                playerStats = stats;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player"))
                return;

            PrototypeEntityStats stats = other.GetComponent<PrototypeEntityStats>();
            if (stats != null)
            {
                playerStats = null;
            }
        }
    }
}