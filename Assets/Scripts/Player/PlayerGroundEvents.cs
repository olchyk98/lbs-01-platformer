using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class PlayerGroundEvents : MonoBehaviour
    {
        #region Fields

        public bool IsTouchingGround { get; private set; } = true;

        #endregion

        #region Trigger Events

        // Not necessary, if it's okay to skip the first frame in the collision sequence
        private void OnTriggerEnter2D(Collider2D other)
        {
            UpdateIsTouching(true);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            UpdateIsTouching(true);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            UpdateIsTouching(false);
        }

        #endregion
        #region Methods

        private void UpdateIsTouching(bool nextState)
        {
            // Don't do anything if nextState is the same as the current state
            if (nextState == IsTouchingGround) return;
        
            // Update state
            IsTouchingGround = nextState;
        }
        #endregion
    }
}
