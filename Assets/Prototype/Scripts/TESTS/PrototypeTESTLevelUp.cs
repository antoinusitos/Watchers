using UnityEngine;

namespace Prototype
{
    public class PrototypeTESTLevelUp : MonoBehaviour
    {
        public bool levelUpAttack = true;
        public bool levelUpAgility = false;

        private void OnTriggerEnter(Collider other)
        {
            PrototypePlayer prototypePlayer = other.GetComponent<PrototypePlayer>();
            if(prototypePlayer != null)
            {
                if(levelUpAttack)
                    prototypePlayer.AddAttackLevel();
                else if(levelUpAgility)
                    prototypePlayer.AddAgilityLevel();
                Debug.Log("Level Up");
            }
        }
    }
}