using UnityEngine;

namespace Prototype
{
    public enum PlayerState
    {
        IDLE,
        ATTACKING,
        MOVING,
        ROLLING,
        LADDER
    }


    public class PrototypePlayer : MonoBehaviour
    {
        public PlayerState playerState = PlayerState.IDLE;

        public bool isInCombat = false;

        public Animator animator = null;
    }
}