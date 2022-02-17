using UnityEngine;

namespace Prototype
{
    public class PrototypePlayerMovement : MonoBehaviour
    {
        public float speed = 4.0f;

        private void Start()
        {

        }

        private void Update()
        {
            Vector3 dir = Vector3.zero;

            if(Input.GetKey(KeyCode.Z))
            {
                dir += Vector3.forward;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir -= Vector3.forward;
            }

            if (Input.GetKey(KeyCode.D))
            {
                dir += Vector3.right;
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                dir -= Vector3.right;
            }

            transform.position += dir.normalized * Time.deltaTime * speed;
        }
    }
}