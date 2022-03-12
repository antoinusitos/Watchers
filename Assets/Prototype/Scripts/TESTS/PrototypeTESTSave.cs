using UnityEngine;

namespace Prototype
{
    public class PrototypeTESTSave : MonoBehaviour
    {
        public bool save = true;

        private void OnTriggerEnter(Collider other)
        {
            PrototypePlayer prototypePlayer = other.GetComponent<PrototypePlayer>();
            if (prototypePlayer != null)
            {
                if (save)
                    PrototypeSaveManager.instance.Save();
                else
                    PrototypeSaveManager.instance.Load();
            }
        }
    }
}