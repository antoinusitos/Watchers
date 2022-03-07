using UnityEngine;
using UnityEngine.SceneManagement;

namespace Prototype
{
    public class PrototypeMenuButtons : MonoBehaviour
    {
        private int currentIndex = 0;

        private PrototypePlayerInput playerInput = null;

        private bool canMove = true;

        public Transform[] positions = null;

        public Transform background = null;

        private void Start()
        {
            playerInput = GetComponent<PrototypePlayerInput>();
            playerInput.playerInputs.Land.Interact.performed += _ => Interact();
        }

        private void Update()
        {
            Vector2 move = playerInput.playerInputs.Land.Move.ReadValue<Vector2>();

            if(!canMove)
            {
                if (move.y == 0)
                    canMove = true;
                return;
            }

            if (move.y < 0)
            {
                currentIndex++;
                canMove = false;
            }
            else if (move.y > 0)
            {
                canMove = false;
                currentIndex--;
            }

            if(currentIndex >= 4)
            {
                currentIndex = 0;
            }
            else if(currentIndex <= -1)
            {
                currentIndex = 3;
            }

            background.position = positions[currentIndex].position;
        }

        private void Interact()
        {
            if(currentIndex == 0)
            {
                //New Game
                SceneManager.LoadScene(1);
            }
            else if(currentIndex == 1)
            {
                //Options
            }
            else if(currentIndex == 2)
            {
                //Credits
            }
            else
            {
                //Quit
                Application.Quit();
            }
        }
    }
}