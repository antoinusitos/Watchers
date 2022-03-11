using UnityEngine;

namespace Prototype
{
    public class PrototypeLivingTreeSendShake : MonoBehaviour
    {
        private PrototypeLivingTree prototypeLivingTree = null;

        private AudioSource audioSource = null;

        private void Awake()
        {
            prototypeLivingTree = GetComponentInParent<PrototypeLivingTree>();
            audioSource = GetComponent<AudioSource>();
        }

        public void Shake()
        {
            prototypeLivingTree.Shake();
            audioSource.Play();
        }
    }
}