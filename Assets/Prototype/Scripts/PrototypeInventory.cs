using System.Collections.Generic;
using UnityEngine;

namespace Prototype
{
    public class PrototypeInventory : MonoBehaviour
    {
        public List<PrototypeItem> inventory = new List<PrototypeItem>();

        public PrototypeObjectDataBase objectDataBase = null;

        public int gold = 100;

        public void Add(int id)
        {
            PrototypeItem item = objectDataBase.GetItemWithID(id);
            if(item != null)
                inventory.Add(item);
        }

        public List<PrototypeItem> GetItems()
        {
            return inventory;
        }
    }
}