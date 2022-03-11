using System.Collections.Generic;
using UnityEngine;

namespace Prototype
{
    public class PrototypeInventory : MonoBehaviour
    {
        public List<PrototypeItem> inventory = new List<PrototypeItem>();

        public PrototypeObjectDataBase objectDataBase = null;

        public int gold = 100;

        public List<int> objectsCollected = new List<int>();

        public void Add(int id)
        {
            PrototypeItem item = objectDataBase.GetItemWithID(id);
            if(item != null)
            {
                if (inventory.Contains(item))
                {
                    for (int i = 0; i < inventory.Count; i++)
                    {
                        if (inventory[i].ID == item.ID)
                        {
                            inventory[i].quantity++;
                            break;
                        }
                    }
                }
                else
                {
                    inventory.Add(item);
                }
            }
        }

        public List<PrototypeItem> GetItems()
        {
            return inventory;
        }
    }
}