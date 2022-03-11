using UnityEngine;

namespace Prototype
{
    [System.Serializable]
    public class PrototypeItem
    {
        public int ID = -1;
        public string name = "";
        public Sprite sprite = null;
        public int quantity = 1;
        public ItemType itemType = ItemType.CLOTH;
    }

    public enum ItemType
    {
        WEAPON,
        CLOTH,
        QUEST,
        CONSUMABLE,
        VALUABLE,

        SIZE
    }
}