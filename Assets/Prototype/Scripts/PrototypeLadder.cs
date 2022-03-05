using UnityEngine;

namespace Prototype
{
    public class PrototypeLadder : PrototypeInteractable
    {
        public PrototypeLadderEnd prototypeLadderEnd = null;

        public Transform startPoint = null;
        public Transform endPoint = null;

        public Transform finishPoint = null;

        private bool isUsing = false;

        private Transform player = null;
        private PrototypePlayer playerProto = null;
        private Rigidbody rigidbodyPlayer = null;

        public GameObject floorToActivate = null;

        public override void Execute()
        {
            base.Execute();
            prototypeLadderEnd.gameObject.SetActive(true);

            playerProto = FindObjectOfType<PrototypePlayer>();
            player = playerProto.transform;
            playerProto.playerState = PlayerState.LADDER;
            player.position = startPoint.position;
            rigidbodyPlayer = player.GetComponent<Rigidbody>();
            rigidbodyPlayer.useGravity = false;
            rigidbodyPlayer.isKinematic = true;
            playerProto.animator.SetBool("Ladder", true);

            isUsing = true;
        }

        private void Update()
        {
            if (!isUsing)
                return;

            float dist = Vector3.Distance(player.position, endPoint.position);
            if(dist <= 0.1f)
            {
                isUsing = false;
                player.position = finishPoint.position;
                rigidbodyPlayer.useGravity = true;
                rigidbodyPlayer.isKinematic = false;
                playerProto.playerState = PlayerState.IDLE;
                playerProto.animator.SetBool("Ladder", false);
            }
        }
    }
}