using System.Collections.Generic;
using UnityEngine;

namespace Prototype
{
    public class PrototypeCollectEntities : MonoBehaviour
    {
        private List<PrototypeEntityStats> entitiesFound = new List<PrototypeEntityStats>();

        private void OnTriggerEnter(Collider other)
        {
            PrototypeEntityStats prototypeEntityStats = other.GetComponent<PrototypeEntityStats>();
            if(prototypeEntityStats)
            {
                entitiesFound.Add(prototypeEntityStats);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            PrototypeEntityStats prototypeEntityStats = other.GetComponent<PrototypeEntityStats>();
            if (prototypeEntityStats)
            {
                entitiesFound.Remove(prototypeEntityStats);
            }
        }

        public List<PrototypeEntityStats> GetEntities()
        {
            return entitiesFound;
        }
    }
}