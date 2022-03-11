using UnityEngine;

namespace Prototype
{
    public enum PlayerState
    {
        IDLE,
        ATTACKING,
        MOVING,
        ROLLING,
        LADDER,
        UI
    }


    public class PrototypePlayer : MonoBehaviour
    {
        public PlayerState playerState = PlayerState.IDLE;

        public bool isInCombat = false;

        public Animator animator = null;
    }
}