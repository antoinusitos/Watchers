using UnityEngine;

namespace Prototype
{
    public class PrototypeCamera : MonoBehaviour
    {
        public PrototypePlayerMovement prototypePlayerMovement = null;

        public Vector3 offset = Vector3.zero;

        public float speed = 2.0f;

        public float predictionOnPlayerMovementForce = 3.0f;

        private Transform player = null;

        private Transform localTransform = null;

        private void Start()
        {
            localTransform = transform;
            player = prototypePlayerMovement.transform;
        }

        private void Update()
        {
            if(player != null)
            {
                localTransform.position = Vector3.Lerp(localTransform.position, player.position + offset + prototypePlayerMovement.GetDirection() * predictionOnPlayerMovementForce, speed * Time.deltaTime);
            }
        }
    }
}