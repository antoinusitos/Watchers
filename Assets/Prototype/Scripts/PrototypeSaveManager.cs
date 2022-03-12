using UnityEngine;

namespace Prototype
{
    public class PrototypeSaveManager : MonoBehaviour
    {
        public static PrototypeSaveManager instance = null;

        private void Awake()
        {
            instance = this;
        }

        public void Save()
        {
            Debug.Log("Saving Game");

            PrototypePlayer prototypePlayer = FindObjectOfType<PrototypePlayer>();
            if(prototypePlayer != null)
            {
                PlayerPrefs.SetInt("AttackLevel", prototypePlayer.GetAttackLevel());
                PlayerPrefs.SetInt("AgilityLevel", prototypePlayer.GetAgilityLevel());
                PlayerPrefs.SetInt("DefenseLevel", prototypePlayer.GetDefenseLevel());
                PlayerPrefs.SetInt("VigorLevel", prototypePlayer.GetVigorLevel());
                PlayerPrefs.SetInt("IntelligenceLevel", prototypePlayer.GetIntelligenceLevel());

                PlayerPrefs.SetFloat("TotalTimePlayed", prototypePlayer.GetTotalTimePlayed());
            }
            PlayerPrefs.Save();
        }

        public void Load()
        {
            Debug.Log("Loading Game");

            PrototypePlayer prototypePlayer = FindObjectOfType<PrototypePlayer>();
            if (prototypePlayer != null)
            {
                prototypePlayer.SetAttackLevel(PlayerPrefs.GetInt("AttackLevel"));
                prototypePlayer.SetAgilityLevel(PlayerPrefs.GetInt("AgilityLevel"));
                prototypePlayer.SetDefenseLevel(PlayerPrefs.GetInt("DefenseLevel"));
                prototypePlayer.SetVigorLevel(PlayerPrefs.GetInt("VigorLevel"));
                prototypePlayer.SetIntelligenceLevel(PlayerPrefs.GetInt("IntelligenceLevel"));

                prototypePlayer.SetTotalTimePlayed(PlayerPrefs.GetFloat("TotalTimePlayed"));
            }
        }
    }
}