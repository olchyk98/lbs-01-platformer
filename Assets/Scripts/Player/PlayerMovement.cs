using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerInput))] // Used for keyboard inputs
    [RequireComponent(typeof(Rigidbody))] // Used for physics
    public class PlayerMovement : MonoBehaviour
    {
        #region Fields
        
        #region Inspector Exposed Fields
        [SerializeField] [Tooltip("Jump Height")] [Range(.1f, 1f)]
        private float myJumpHeight;

        [SerializeField] [Tooltip("Movement Speed")] [Range(.1f, 1f)]
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
        #endregion

        #region Methods
        public void MoveHorizontal(float aHorizontalValue)
        {
            // myRigidbody.MovePosition(GetComponent<Transform>().position + Vector3.right * (aHorizontalValue * myMovementSpeed));
            myRigidbody.AddForce(Vector2.right * (aHorizontalValue * myMovementSpeed));
        }
        
        /// <summary>
        /// Makes player jump using its Rigidbody component.
        /// </summary>
        public void Jump()
        {
            myRigidbody.AddForce(Vector2.up * myJumpHeight, ForceMode2D.Impulse);
        }
        #endregion
    }
}
