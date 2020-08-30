using System;
using UnityEngine;

/*
 * Obstacles
 * UI
 * Points
 * Points calculation -> Win
 * Obstacles calculation -> Lose
 */

namespace Player
{
    [RequireComponent(typeof(PlayerInput))] // Used for keyboard inputs
    [RequireComponent(typeof(Rigidbody))] // Used for physics
    public class PlayerMovement : MonoBehaviour
    {
        #region Fields
        
        #region Inspector Exposed Fields
        [SerializeField] [Tooltip("Jump Height")] [Range(3f, 20f)]
        private float myJumpHeight;

        [SerializeField] [Tooltip("Movement Speed")] [Range(5f, 20f)]
        private float myMovementSpeed;
        #endregion
        
        #region Private Fields
        private Rigidbody2D myRigidbody;
        #endregion
        
        #endregion
        
        #region RP Methods
        private void Start()
        {
            // :Subscribe to the input events:
            // Get the component and temp store it
            PlayerInput inputEvents = GetComponent<PlayerInput>();  
            
            // Subscribe to the horizontal movement event
            inputEvents.OnHorizontalMove += MoveHorizontal;
            
            // Subscribe to the jump event
            inputEvents.OnJump += Jump;
            
            // :Define Cache Fields:
            // Rigidbody
            myRigidbody = GetComponent<Rigidbody2D>();

        }

        private void OnDisable()
        {
            // :Unsubscribe from the input events:
            // Get the component and temp store it
            // May be added as an private field, but used only twice.
            PlayerInput inputEvents = GetComponent<PlayerInput>();
            
            // Unsubscribe from the horizontal movement event
            inputEvents.OnHorizontalMove -= MoveHorizontal;
            
            // Unsubscribe from the jump event
            inputEvents.OnJump -= Jump;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Changes player's horizontal position (velocity)
        /// </summary>
        /// <param name="aHorizontalValue">
        /// Float that represents direction and drag.
        /// The value should be between -1 and 1.
        /// </param>
        public void MoveHorizontal(float aHorizontalValue)
        {
            // Change velocity X and preserve velocity Y
            myRigidbody.velocity = (myRigidbody.velocity * Vector2.up) +
                                   Vector2.right * (aHorizontalValue * myMovementSpeed);
        }
        
        /// <summary>
        /// Makes player jump using its Rigidbody component.
        /// </summary>
        public void Jump()
        {
            myRigidbody.AddForce(Vector3.up * myJumpHeight, ForceMode2D.Impulse);
        }
        #endregion
    }
}
