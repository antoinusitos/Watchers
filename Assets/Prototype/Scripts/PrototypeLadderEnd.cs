using UnityEngine;

namespace Prototype
{
    public class PrototypeLadderEnd : MonoBehaviour
    {
        public GameObject floorToActivate = null;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
                return;

            floorToActivate.SetActive(!floorToActivate.activeSelf);
        }
    }
}