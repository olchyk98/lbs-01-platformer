using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    [RequireComponent(typeof(PlayerScores))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerHealth : MonoBehaviour
    {
        #region Fields

        public float Health { get; private set; }

        private Rigidbody2D myRigidbody2D;

        #endregion
        
        #region Inspector Exposed Fields

        [SerializeField] [Range(1f, 25f)] private float hitVelocity = 5f;
        #endregion
        
        #region Public Events
        public UnityAction OnPlayerDies;
        #endregion

        #region RP Methods

        private void Start()
        {
            // Subscribe to obstacle touch event
            var scoreEvents = GetComponent<PlayerScores>();

            scoreEvents.OnPlayerTouchesObstacle += HandlePlayerTouchesObstacle;
            
            // Cache rigidbdy
            myRigidbody2D = GetComponent<Rigidbody2D>();
        }
        #endregion
        
        #region Event Handlers

        private void HandlePlayerTouchesObstacle()
        {
            // Apply damage to the player
            ApplyDamage(10f);
            
            // Add hit force to the player's rigidbody
            myRigidbody2D.AddForce(Vector2.up * hitVelocity);
        }
        #endregion
        
        #region Methods

        /// <summary>
        /// Applies damage to the player
        /// and kills him if damage was critical (health - damage less than 0)
        /// </summary>
        /// <param name="amount">
        /// Damage points
        /// </param>
        public void ApplyDamage(float amount)
        {
            // Reduce health
            Health -= amount;
            
            // Check if player is dead
            if (Health <= 0)
            {
                OnPlayerDies?.Invoke();
                Health = 0;
            }
        }
        #endregion
    }
}