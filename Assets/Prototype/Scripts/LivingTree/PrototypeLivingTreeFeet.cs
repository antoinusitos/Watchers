using UnityEngine;

namespace Prototype
{
    public class PrototypeLivingTreeFeet : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            PrototypeEntityStats stat = other.GetComponent<PrototypeEntityStats>();
            if(stat)
            {
                stat.Kill();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            PrototypeEntityStats stat = other.GetComponent<PrototypeEntityStats>();
            if (stat)
            {
                stat.Kill();
            }
        }
    }
}