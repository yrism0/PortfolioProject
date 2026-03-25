using UnityEngine;
using UnityEngine.InputSystem;

namespace TopDown.Movement
{
    [RequireComponent (typeof(PlayerInput))]
    public class PlayerMovement : Mover
    {
        private void OnMove(InputValue value)
        {
            if (!UIManager.Instance.isPaused && !PlayerHealth.instance.isPlayerDead && !levelchange.LevelFinished)
            {
                Vector3 playerInput = new Vector3(value.Get<Vector2>().x, value.Get<Vector2>().y, 0);
                currentInput = playerInput;

            }            
            
        }
    }
}
