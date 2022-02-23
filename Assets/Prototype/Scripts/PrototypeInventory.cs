using System.Collections.Generic;
using UnityEngine;

namespace Prototype
{
    public class PrototypeInventory : MonoBehaviour
    {
        public List<PrototypeItem> inventory = new List<PrototypeItem>();

        public void Add(int id)
        {
            inventory.Add(new PrototypeItem() { ID = id });
        }
    }
}