using System.Collections;
using UnityEngine;

namespace Prototype
{
    public class PrototypeCinematic : MonoBehaviour
    {
        private PrototypeCamera prototypeCamera = null;
        private PrototypePlayerMovement playerMovement = null;

        public Transform endPoint = null;
        public float speedMultiplier = 0.2f;

        private void Start()
        {
            prototypeCamera = FindObjectOfType<PrototypeCamera>();
            prototypeCamera.offset = new Vector3(0, 15, -9);
            playerMovement = FindObjectOfType<PrototypePlayerMovement>();
            playerMovement.canMove = false;
            StartCoroutine(Cinematic());
        }

        private IEnumerator Cinematic()
        {
            while(Vector3.Distance(playerMovement.transform.position, endPoint.position) > 0.1f)
            {
                Vector3 dir = endPoint.position - playerMovement.transform.position;
                dir.Normalize();
                dir *= speedMultiplier;
                playerMovement.ForceMove(new Vector2(dir.x, dir.z));
                yield return null;
            }

            playerMovement.canMove = true;
            prototypeCamera.ResetCameraOffset();
        }
    }
}