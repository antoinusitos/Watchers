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

        private Vector3 startingOffset = Vector3.zero;

        private void Awake()
        { 
            localTransform = transform;
            startingOffset = offset;
        }

        private void Start()
        {
            player = prototypePlayerMovement.transform;
            localTransform.position = player.position + offset + prototypePlayerMovement.GetDirection() * predictionOnPlayerMovementForce;
        }

        private void Update()
        {
            if(player != null)
            {
                localTransform.position = Vector3.Lerp(localTransform.position, player.position + offset + prototypePlayerMovement.GetDirection() * predictionOnPlayerMovementForce, speed * Time.deltaTime);
            }
        }

        public void ResetCameraOffset()
        {
            offset = startingOffset;
        }
    }
}