using UnityEngine;

namespace Prototype
{
    public class PrototypePlayerMovement : MonoBehaviour
    {
        public float speed = 4.0f;

        public float lookAtspeed = 10.0f;

        public Animator animator = null;

        private Vector3 direction = Vector3.zero;

        private Transform playerModel = null;

        private Vector3 modelDirection = Vector3.forward;

        private void Start()
        {
            playerModel = transform.GetChild(0);
            modelDirection = transform.position + Vector3.forward;
        }

        private void Update()
        {
            direction = Vector3.zero;

            if(Input.GetKey(KeyCode.Z))
            {
                direction += Vector3.forward;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                direction -= Vector3.forward;
            }

            if (Input.GetKey(KeyCode.D))
            {
                direction += Vector3.right;
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                direction -= Vector3.right;
            }

            direction.Normalize();

            if (direction != Vector3.zero)
                animator.SetBool("Moving", true);
            else
                animator.SetBool("Moving", false);

            transform.position += direction * Time.deltaTime * speed;

            modelDirection = Vector3.Lerp(modelDirection, transform.position + direction, Time.deltaTime * lookAtspeed);

            playerModel.LookAt(modelDirection);
        }

        public Vector3 GetDirection()
        {
            return direction;
        }
    }
}