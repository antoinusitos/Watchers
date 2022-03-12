using UnityEngine;

namespace Prototype
{
    public enum PlayerState
    {
        IDLE,
        ATTACKING,
        MOVING,
        ROLLING,
        LADDER,
        UI,
        INVENTORY
    }


    public class PrototypePlayer : MonoBehaviour
    {
        public PlayerState playerState = PlayerState.IDLE;

        public bool isInCombat = false;

        public Animator animator = null;

        private int attackLevel = 1;

        private int agilityLevel = 1;

        private int defenseLevel = 1;

        private int vigorLevel = 1;

        private int intelligenceLevel = 1;

        private float totalTimePlayed = 0;

        private float baseAttackDamage = 20;
        private float attackBonusPerLevel = 0.5f;

        private float baseAgility = 0.5f;
        private float agilityBonusPerLevel = 0.01f;

        private void Update()
        {
            totalTimePlayed += Time.deltaTime;
        }

        public int GetAttackLevel() { return attackLevel; }
        public int GetAgilityLevel() { return agilityLevel; }
        public int GetDefenseLevel() { return defenseLevel; }
        public int GetVigorLevel() { return vigorLevel; }
        public int GetIntelligenceLevel() { return intelligenceLevel; }

        public float GetTotalTimePlayed() { return totalTimePlayed; }

        public float GetBaseAttackDamage() { return baseAttackDamage; }
        public float GetAttackBonusPerLevel() { return attackBonusPerLevel; }
        public float GetBaseAgility() { return baseAgility; }
        public float GetAgilityBonusPerLevel() { return agilityBonusPerLevel; }

        public void AddAttackLevel() { attackLevel++; }
        public void AddAgilityLevel() { agilityLevel++; }
        public void AddDefenseLevel() { defenseLevel++; }
        public void AddVigorLevel() { vigorLevel++; }
        public void AddIntelligenceLevel() { intelligenceLevel++; }

        public void SetAttackLevel(int value) { attackLevel = value; }
        public void SetAgilityLevel(int value) { agilityLevel = value; }
        public void SetDefenseLevel(int value) { defenseLevel = value; }
        public void SetVigorLevel(int value) { vigorLevel = value; }
        public void SetIntelligenceLevel(int value) { intelligenceLevel = value; }

        public void SetTotalTimePlayed(float value) { totalTimePlayed = value; }
    }
}