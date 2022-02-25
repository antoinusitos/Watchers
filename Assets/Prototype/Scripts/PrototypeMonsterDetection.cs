using UnityEngine;

namespace Prototype
{
    public class PrototypeMonsterDetection : MonoBehaviour
    {
        public PrototypeAttackTrigger prototypeAttack = null;

        public PrototypePlayer prototypePlayer = null;

        private int monsters = 0;

        private void OnTriggerEnter(Collider other)
        {
            PrototypeEnemyAttack prototypeEnemyAttack = other.GetComponent<PrototypeEnemyAttack>();
            if(prototypeEnemyAttack)
            {
                prototypePlayer.isInCombat = true;
                monsters++;
                prototypeAttack.SetSwordOut(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            PrototypeEnemyAttack prototypeEnemyAttack = other.GetComponent<PrototypeEnemyAttack>();
            if (prototypeEnemyAttack)
            {
                monsters--;
                CheckMonsters();
            }
        }

        public void CheckMonsters()
        {
            if(monsters <= 0)
            {
                prototypePlayer.isInCombat = false;
                prototypeAttack.SetSwordOut(false);
            }
        }
    }
}