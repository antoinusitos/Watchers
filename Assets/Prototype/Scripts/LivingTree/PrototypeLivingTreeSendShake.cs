using UnityEngine;

namespace Prototype
{
    public class PrototypeLivingTreeSendShake : MonoBehaviour
    {
        private PrototypeLivingTree prototypeLivingTree = null;

        private AudioSource audioSource = null;

        public ParticleSystem leftParticleSystem = null;
        public ParticleSystem rightParticleSystem = null;

        private void Awake()
        {
            prototypeLivingTree = GetComponentInParent<PrototypeLivingTree>();
            audioSource = GetComponent<AudioSource>();
        }

        public void Shake(int left)
        {
            prototypeLivingTree.Shake();
            audioSource.Play();

            if(left == 1)
            {
                leftParticleSystem.Play();
            }
            else
            {
                rightParticleSystem.Play();
            }
        }
    }
}