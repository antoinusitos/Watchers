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

            if(life <= 0)
            {
                Destroy(gameObject);
            }
        }

        public void AddMaxLife(float amount)
        {
            maxLife += amount;
            lifeValueDirty = true;
        }

        public void RefillFullLife()
        {
            life = maxLife;
            lifeValueDirty = true;
        }

        public void Kill()
        {
            RemoveLife(maxLife);
        }
    }
}