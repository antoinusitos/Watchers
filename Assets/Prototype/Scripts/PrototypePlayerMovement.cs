using UnityEngine;

namespace Prototype
{
    public class PrototypePlayerMovement : MonoBehaviour
    {
        public float speed = 4.0f;
        public float ladderSpeed = 20.0f;

        public float lookAtspeed = 10.0f;

        public Animator animator = null;

        private PrototypePlayerInput playerInput = null;

        private Vector3 direction = Vector3.zero;

        private Transform playerModel = null;

        private Vector3 modelDirection = Vector3.forward;

        private Rigidbody rigidbody = null;

        private float dashForce = 1.0f;

        private PrototypePlayer prototypePlayer = null;

        public bool canMove = true;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
            playerInput = GetComponent<PrototypePlayerInput>();
            prototypePlayer = GetComponent<PrototypePlayer>();
        }

        private void Start()
        {
            playerModel = transform.GetChild(0);
            modelDirection = transform.position + Vector3.forward;
        }
        private void Update()
        {
            if (prototypePlayer.playerState == PlayerState.ATTACKING)
                return;

            if (prototypePlayer.playerState == PlayerState.UI)
                return;

            if (prototypePlayer.playerState == PlayerState.INVENTORY)
                return;

            if (!canMove)
                return;

            Vector2 move = playerInput.playerInputs.Land.Move.ReadValue<Vector2>();

            direction.x = move.x;
            direction.z = move.y;

            if(prototypePlayer.playerState == PlayerState.LADDER)
            {
                rigidbody.MovePosition(rigidbody.position + Vector3.up * direction.z * Time.deltaTime * ladderSpeed);
                return;
            }

            animator.SetFloat("PlayerSpeed", direction.magnitude);

            rigidbody.MovePosition(rigidbody.position + direction * Time.deltaTime * speed * dashForce);

            if (move != Vector2.zero)
            {
                modelDirection = Vector3.Lerp(modelDirection, rigidbody.position + direction, Time.deltaTime * lookAtspeed);

                playerModel.LookAt(modelDirection);
            }
        }

        public void ForceMove(Vector2 move)
        {
            direction.x = move.x;
            direction.z = move.y;

            animator.SetFloat("PlayerSpeed", direction.magnitude);

            rigidbody.MovePosition(rigidbody.position + direction * Time.deltaTime * speed * dashForce);
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