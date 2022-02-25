using System.Collections.Generic;
using UnityEngine;

namespace Prototype
{
    public class PrototypeInventory : MonoBehaviour
    {
        public List<PrototypeItem> inventory = new List<PrototypeItem>();

        public int gold = 100;

        public void Add(int id)
        {
            inventory.Add(new PrototypeItem() { ID = id });
        }

        public List<PrototypeItem> GetItems()
        {
            return inventory;
        }
    }
}