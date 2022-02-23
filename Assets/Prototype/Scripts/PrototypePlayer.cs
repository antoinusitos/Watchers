using UnityEngine;

namespace Prototype
{
    public enum PlayerState
    {
        IDLE,
        ATTACKING,
        MOVING,
    }


    public class PrototypePlayer : MonoBehaviour
    {
        public PlayerState playerState = PlayerState.IDLE;
    }
}