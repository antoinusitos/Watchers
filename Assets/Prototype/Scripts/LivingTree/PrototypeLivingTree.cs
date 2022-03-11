using UnityEngine;

namespace Prototype
{
    public class PrototypeLivingTree : MonoBehaviour
    {
        public float speed = 0.1f;

        public PrototypeLivingTreeShake LivingTreeShake = null;

        private Rigidbody selfRigidbody = null;

        private void Awake()
        {
            selfRigidbody = GetComponent<Rigidbody>();
            //InvokeRepeating("Shake", 2, 2);
        }

        private void FixedUpdate()
        {
            selfRigidbody.MovePosition(selfRigidbody.position + Vector3.forward * Time.fixedDeltaTime * speed);
        }

        public void Shake()
        {
            LivingTreeShake.Shake();
        }
    }
}