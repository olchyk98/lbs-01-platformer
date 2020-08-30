using System;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    /// <summary>
    /// PlayerInput class is responsible for handling player keyboard events and informing child-components
    /// about fk-actions.
    /// </summary>
    /// <future>
    /// * Can be re-implemented using Unity Input System.
    /// * Can be re-implemented using .GetButtonDown Event Structure.
    /// </future>
    public class PlayerInput : MonoBehaviour
    {
        #region Fields
        public UnityAction<float> OnHorizontalMove;
        public UnityAction OnJump;
        #endregion

        #region RP Methods
        private void Update()
        {
            // Get horizontal movement
            float horizontalValue = Input.GetAxis("Horizontal");
            
            // Inform all subscribers if movement input received
            // Using Abs method to reduce float loss during zero comparison
            if(Math.Abs(horizontalValue) > 0) OnHorizontalMove?.Invoke(horizontalValue);

            // Check if space button is pressed
            if (Input.GetKeyDown(KeyCode.Space)) OnJump?.Invoke();
        }
        #endregion
    }
}
