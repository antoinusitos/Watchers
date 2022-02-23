using UnityEngine;

namespace Prototype
{
    public class PrototypePlayerMovement : MonoBehaviour
    {
        public float speed = 4.0f;

        public float lookAtspeed = 10.0f;

        public Animator animator = null;

        public PlayerInputs playerInputs = null;

        private Vector3 direction = Vector3.zero;

        private Transform playerModel = null;

        private Vector3 modelDirection = Vector3.forward;

        private Rigidbody rigidbody = null;

        private float dashForce = 1.0f;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();

            playerInputs.PlayerInput.Move.performed += _ => Move();
        }

        private void Start()
        {
            playerModel = transform.GetChild(0);
            modelDirection = transform.position + Vector3.forward;
        }

        private void Update()
        {
            direction = Vector3.zero;

            if(playerInputs.)

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

            rigidbody.MovePosition(rigidbody.position + direction * Time.deltaTime * speed * dashForce);

            modelDirection = Vector3.Lerp(modelDirection, transform.position + direction, Time.deltaTime * lookAtspeed);

            playerModel.LookAt(modelDirection);
        }

        public Vector3 GetDirection()
        {
            return direction;
        }

        public void SetDash(float value)
        {
            dashForce = value;
        }
    }
}