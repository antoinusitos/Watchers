using UnityEngine;

namespace Prototype
{
    public class PrototypeEntityStats : MonoBehaviour
    {
        public float life = 100;
        public float maxLife = 100;

        public bool lifeValueDirty = false;

        public float GetLife()
        {
            return life;
        }

        public float GetMaxLife()
        {
            return maxLife;
        }

        public float GetLifeRatio()
        {
            return life / maxLife;
        }

        public void RemoveLife(float amount)
        {
            life -= amount;
            lifeValueDirty = true;
        }

        public void AddMaxLife(float amount)
        {
            maxLife += amount;
            lifeValueDirty = true;
        }
    }
}