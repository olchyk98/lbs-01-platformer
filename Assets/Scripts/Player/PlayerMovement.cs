using System;
using UnityEngine;

/*
 * Camera Movement [x]
 * Ground collision detection (using a child object and unity actions) -> Prevent from jumping in the air [x]
 * Obstacles
 * UI
 * Points
 * Points calculation -> Win
 * Obstacles calculation -> Lose
 */

namespace Player
{
    [RequireComponent(typeof(PlayerInput))] // Used for keyboard inputs
    [RequireComponent(typeof(Rigidbody2D))] // Used for physics
    public class PlayerMovement : MonoBehaviour
    {
        #region Fields
        
        #region Inspector Exposed Fields
        [SerializeField] [Tooltip("Jump Height")] [Range(3f, 20f)]
        private float myJumpHeight = 12f;

        [SerializeField] [Tooltip("Movement Speed")] [Range(5f, 20f)]
        private float myMovementSpeed = 12f;

        [SerializeField] [Tooltip("Ground Collider")]
        private PlayerGroundEvents myGroundCollider;
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

        #endregion

        #region Methods
        /// <summary>
        /// Changes player's horizontal position (velocity)
        /// </summary>
        /// <param name="aHorizontalValue">
        /// Float that represents direction and drag.
        /// The value should be between -1 and 1.
        /// </param>
        private void MoveHorizontal(float aHorizontalValue)
        {
            // Change velocity X and preserve velocity Y
            myRigidbody.velocity = (myRigidbody.velocity * Vector2.up) + Vector2.right * (aHorizontalValue * myMovementSpeed);
        }
        
        /// <summary>
        /// Makes player jump using its Rigidbody component.
        /// </summary>
        private void Jump()
        {
            // Don't process if player does not touching the ground
            if(!myGroundCollider.IsTouchingGround) return;
            
            // Add jump force
            myRigidbody.AddForce(Vector3.up * myJumpHeight, ForceMode2D.Impulse);
        }
        #endregion
    }
}
