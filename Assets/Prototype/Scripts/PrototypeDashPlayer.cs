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

        private PrototypePlayerInput playerInput = null;


        private void Awake()
        {
            playerMovement = GetComponent<PrototypePlayerMovement>();
        }

        private void Start()
        {
            playerInput = GetComponent<PrototypePlayerInput>();
            playerInput.playerInputs.Land.Dash.performed += _ => Dash();
        }

        private void Dash()
        {
            if (!isDashing)
            {
                playerMovement.SetDash(dashForce);
                isDashing = true;
            }
        }

        private void Update()
        {
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