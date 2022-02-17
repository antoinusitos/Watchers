using UnityEngine;

namespace Prototype
{
    public class PrototypeCamera : MonoBehaviour
    {
        public Transform player = null;

        public Vector3 offset = Vector3.zero;

        public float speed = 2.0f;

        private Transform localTransform = null;

        private void Start()
        {
            localTransform = transform;
        }

        private void Update()
        {
            if(player != null)
            {
                localTransform.position = Vector3.Lerp(localTransform.position, player.position + offset, speed * Time.deltaTime);
            }
        }
    }
}