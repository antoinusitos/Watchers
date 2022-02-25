using System.Collections.Generic;
using UnityEngine;

namespace Prototype
{
    [CreateAssetMenu(fileName = "PrototypeObjectDataBase", menuName = "ScriptableObjects/PrototypeObjectDataBase", order = 1)]
    public class PrototypeObjectDataBase : ScriptableObject
    {
        public List<PrototypeItem> items;

        public PrototypeItem GetItemWithID(int ID)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if(items[i].ID == ID)
                {
                    return items[i];
                }
            }
            return null;
        }
    }
}