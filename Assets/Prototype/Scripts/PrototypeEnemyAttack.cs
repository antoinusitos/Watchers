using UnityEngine;

namespace Prototype
{
    public class PrototypeEnemyAttack : MonoBehaviour
    {
        public int damage = 5;
        public float attackRate = 2.0f;
        public float attackTotalTime = 2.6f;
        public float preparationTime = 1.2f;

        public PrototypeCollectEntities prototypeCollectEntities = null;

        public Animator animator = null;

        private PrototypeUIEnemies prototypeUIEnemies = null;

        private float currentAttackTime = 0;
        private float currentPreparingTime = 0;
        private float currentRate = 0;
        private bool canAttack = true;
        private bool attacking = false;

        private PrototypeEntityStats playerStats = null;

        private void Awake()
        {
            prototypeUIEnemies = GetComponent<PrototypeUIEnemies>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag != "Player")
                return;

            PrototypeEntityStats stats = other.GetComponent<PrototypeEntityStats>();
            if(stats != null)
            {
                playerStats = stats;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag != "Player")
                return;

            PrototypeEntityStats stats = other.GetComponent<PrototypeEntityStats>();
            if (stats != null)
            {
                playerStats = null;
            }
        }

        private void Update()
        {
            if(!canAttack && !attacking)
            {
                currentRate += Time.deltaTime;
                if(currentRate >= attackRate)
                {
                    canAttack = true;
                    currentRate = 0;
                }
            }

            if(playerStats && canAttack && !attacking)
            {
                attacking = true;
                prototypeUIEnemies.ShowAttackFeedback(true);
                animator.SetTrigger("Attack");
            }

            if (attacking)
            {
                currentAttackTime += Time.deltaTime;
                if(currentAttackTime >= attackTotalTime)
                {
                    currentAttackTime = 0;
                    attacking = false;
                    prototypeUIEnemies.ShowAttackFeedback(false);
                }

                if (canAttack)
                {
                    currentPreparingTime += Time.deltaTime;
                    if (currentPreparingTime >= preparationTime)
                    {
                        currentPreparingTime = 0;
                        canAttack = false;

                        PrototypeEntityStats[] entities = prototypeCollectEntities.GetEntities().ToArray();
                        for (int i = 0; i < entities.Length; i++)
                        {
                            entities[i].RemoveLife(damage);
                        }
                    }
                }
            }
        }
    }
}