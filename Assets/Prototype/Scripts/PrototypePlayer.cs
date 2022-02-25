using UnityEngine;

namespace Prototype
{
    public enum PlayerState
    {
        IDLE,
        ATTACKING,
        MOVING,
        ROLLING,
    }


    public class PrototypePlayer : MonoBehaviour
    {
        public PlayerState playerState = PlayerState.IDLE;

        public bool isInCombat = false;
    }
}