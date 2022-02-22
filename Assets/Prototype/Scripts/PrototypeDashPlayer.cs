using UnityEngine;

namespace Prototype
{
    public class PrototypeDashPlayer : MonoBehaviour
    {
        public float dashForce = 2.0f;

        private PrototypePlayerMovement playerMovement = null;

        public float dashDuration = 0.5f;

        private float currentDashDuration = 0;

        private bool isDashing = false;


        private void Awake()
        {
            playerMovement = GetComponent<PrototypePlayerMovement>();
        }

        private void Update()
        {
            if (!isDashing && Input.GetKeyDown(KeyCode.Space))
            {
                playerMovement.SetDash(dashForce);
                isDashing = true;
            }

            if(isDashing)
            {
                currentDashDuration += Time.deltaTime;
                if(currentDashDuration >= dashDuration)
                {
                    currentDashDuration = 0;
                    playerMovement.SetDash(1);
                    isDashing = false;
                }
            }
        }
    }
}