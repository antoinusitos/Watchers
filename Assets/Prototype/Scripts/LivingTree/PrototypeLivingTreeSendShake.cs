using UnityEngine;

namespace Prototype
{
    public class PrototypeLivingTreeSendShake : MonoBehaviour
    {
        private PrototypeLivingTree prototypeLivingTree = null;

        private AudioSource audioSource = null;

        public ParticleSystem leftParticleSystem = null;
        public ParticleSystem rightParticleSystem = null;

        public Transform leftRotationRef = null;
        public Transform rightRotationRef = null;

        public Transform footStepPrefab = null;

        private Transform[] footSteps = null;
        private int currentIndex = 0;

        private const int footStepNumber = 10;

        private void Awake()
        {
            prototypeLivingTree = GetComponentInParent<PrototypeLivingTree>();
            audioSource = GetComponent<AudioSource>();
            footSteps = new Transform[footStepNumber];
            for(int i = 0; i < footSteps.Length; i++)
            {
                footSteps[i] = Instantiate(footStepPrefab);
                footSteps[i].gameObject.SetActive(false);
            }
        }

        public void Shake(int left)
        {
            prototypeLivingTree.Shake();
            audioSource.Play();

            footSteps[currentIndex].gameObject.SetActive(true);

            if (left == 1)
            {
                leftParticleSystem.Play();
                footSteps[currentIndex].position = leftParticleSystem.transform.position;
                footSteps[currentIndex].rotation = leftRotationRef.transform.rotation;
            }
            else
            {
                rightParticleSystem.Play();
                footSteps[currentIndex].position = rightParticleSystem.transform.position;
                footSteps[currentIndex].rotation = rightRotationRef.transform.rotation;
            }

            currentIndex++;
            if (currentIndex >= footSteps.Length)
            {
                currentIndex = 0;
            }
        }
    }
}