using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Prototype
{
    public class PrototypeTraduction
    {
        public int ID;
        public string englishText = "";
        public string frenchText = "";
    }

    public enum PrototypeLanguage
    {
        ENGLISH,
        FRENCH,
    }

    public class PrototypeTraductionManager : MonoBehaviour
    {
        public static PrototypeTraductionManager instance = null;

        private Dictionary<int, PrototypeTraduction> traductions = new Dictionary<int, PrototypeTraduction>();

        public PrototypeLanguage currentLanguage = PrototypeLanguage.ENGLISH;

        private void Awake()
        {
            instance = this;
            ReadTraductions();
        }

        private void ReadTraductions()
        {
            string path = Application.dataPath + "/Prototype/Data/Watchers_Trad.csv";

            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                Debug.LogError("No file at :" + path);
                return;
            }

            string[] readText = File.ReadAllLines(path);
            foreach (string s in readText)
            {
                string[] split = s.Split(',');
                int id;
                if (int.TryParse(split[0], out id))
                {
                    traductions.Add(id, new PrototypeTraduction()
                    {
                        ID = id,
                        englishText = split[1].Replace("\"", ""),
                        frenchText = split[2].Replace("\"", ""),
                    });
                }
            }
        }

        public string GetText(int id)
        {
            if (!traductions.ContainsKey(id))
                return "";

            switch(currentLanguage)
            {
                case PrototypeLanguage.ENGLISH:
                    return traductions[id].englishText;

                case PrototypeLanguage.FRENCH:
                    return traductions[id].frenchText;

                default:
                    return "";
            }
        }
    }
}
