using UnityEngine;

namespace Prototype
{
    public class PrototypeLocationTrigger : MonoBehaviour
    {
        public int locationID = -1;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
                return;

            PrototypeUIManager.instance.ShowLocation(PrototypeTraductionManager.instance.GetText(locationID));
        }
    }
}