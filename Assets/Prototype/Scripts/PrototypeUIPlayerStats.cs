using UnityEngine;
using UnityEngine.UI;

namespace Prototype
{
    public class PrototypeUIPlayerStats : PrototypeUICategory
    {
        public Transform playerStatsTextsPrefab = null;

        public Transform playerStatsPanel = null;
        public Transform gameStatsPanel = null;

        public int attackTradID = -1;
        public int agilityTradID = -1;
        public int defenseTradID = -1;
        public int vigorTradID = -1;
        public int intelligenceTradID = -1;

        public int gameTimeTradID = -1;

        public override void Refresh()
        {
            base.Refresh();

            for(int i = 0; i < playerStatsPanel.childCount; i++)
            {
                Destroy(playerStatsPanel.GetChild(i).gameObject);
            }

            for (int i = 0; i < gameStatsPanel.childCount; i++)
            {
                Destroy(gameStatsPanel.GetChild(i).gameObject);
            }

            /////////////////////////
            //Left panel
            /////////////////////////
            Transform text = Instantiate(playerStatsTextsPrefab, playerStatsPanel).transform;
            text.GetChild(0).GetComponent<Text>().text = PrototypeTraductionManager.instance.GetText(attackTradID) + " :";
            text.GetChild(1).GetComponent<Text>().text = player.GetAttackLevel().ToString();

            text = Instantiate(playerStatsTextsPrefab, playerStatsPanel).transform;
            text.GetChild(0).GetComponent<Text>().text = PrototypeTraductionManager.instance.GetText(agilityTradID) + " :";
            text.GetChild(1).GetComponent<Text>().text = player.GetAgilityLevel().ToString();

            text = Instantiate(playerStatsTextsPrefab, playerStatsPanel).transform;
            text.GetChild(0).GetComponent<Text>().text = PrototypeTraductionManager.instance.GetText(defenseTradID) + " :";
            text.GetChild(1).GetComponent<Text>().text = player.GetDefenseLevel().ToString();

            text = Instantiate(playerStatsTextsPrefab, playerStatsPanel).transform;
            text.GetChild(0).GetComponent<Text>().text = PrototypeTraductionManager.instance.GetText(vigorTradID) + " :";
            text.GetChild(1).GetComponent<Text>().text = player.GetVigorLevel().ToString();

            text = Instantiate(playerStatsTextsPrefab, playerStatsPanel).transform;
            text.GetChild(0).GetComponent<Text>().text = PrototypeTraductionManager.instance.GetText(intelligenceTradID) + " :";
            text.GetChild(1).GetComponent<Text>().text = player.GetIntelligenceLevel().ToString();


            /////////////////////////
            //Right Panel
            /////////////////////////
            text = Instantiate(playerStatsTextsPrefab, gameStatsPanel).transform;
            text.GetChild(0).GetComponent<Text>().text = PrototypeTraductionManager.instance.GetText(gameTimeTradID) + " :";
            text.GetChild(1).GetComponent<Text>().text = player.GetTotalTimePlayed().ToString();
        }
    }
}