using UnityEngine;

namespace Prototype
{
    public class PrototypeEnemyAttack : MonoBehaviour
    {
        public int damage = 5;
        public float attackRate = 2.0f;
        public float attackFeedbackTime = 0.5f;

        private float currentAttackFeedbackTime = 0;
        private float currentRate = 0;
        private bool canAttack = true;

        private PrototypeEntityStats playerStats = null;

        private void OnTriggerEnter(Collider other)
        {
            PrototypeEntityStats stats = other.GetComponent<PrototypeEntityStats>();
            if(stats != null)
            {
                playerStats = stats;
            }
        }

        private void Update()
        {
            if(!canAttack)
            {
                currentRate += Time.deltaTime;
                if(currentRate >= attackRate)
                {
                    canAttack = true;
                    currentRate = 0;
                }
            }

            if(playerStats && canAttack)
            {
                canAttack = false;
                playerStats.RemoveLife(damage);
            }
        }
    }
}