using UnityEngine;

namespace Prototype
{
    public class PrototypeEnemyAttack : MonoBehaviour
    {
        public int damage = 5;
        public float attackRate = 2.0f;
        public float attackTotalTime = 2.6f;
        public float lookAtSpeed = 2.0f;
        public float preparationTime = 1.2f;

        public PrototypeCollectEntities prototypeCollectEntities = null;

        public Animator animator = null;

        private PrototypeUIEnemies prototypeUIEnemies = null;

        private float currentAttackTime = 0;
        private float currentPreparingTime = 0;
        private float currentRate = 0;
        private bool canAttack = true;
        private bool attacking = false;

        public PrototypeCollectPlayer prototypeCollectPlayer = null;

        private Transform selfTransform = null;

        private Vector3 positionTarget = Vector3.zero;

        private void Awake()
        {
            selfTransform = transform;
            prototypeUIEnemies = GetComponent<PrototypeUIEnemies>();
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

            if(prototypeCollectPlayer.playerStats && !attacking)
            {
                Vector3 pos = prototypeCollectPlayer.playerStats.transform.position;
                pos.y = selfTransform.position.y;
                positionTarget = Vector3.MoveTowards(positionTarget, pos, Time.deltaTime * lookAtSpeed);
                transform.LookAt(positionTarget);
            }

            if(prototypeCollectPlayer.playerStats && canAttack && !attacking)
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