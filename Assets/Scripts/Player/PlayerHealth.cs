using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    [RequireComponent(typeof(PlayerScores))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerHealth : MonoBehaviour
    {
        #region Fields

        public float Health { get; private set; } = 100f;

        private Rigidbody2D myRigidbody;

        #endregion
        
        #region Public Events
        public UnityAction OnDie;
        public UnityAction<float> OnHealthUpdates;
        #endregion

        #region RP Methods

        private void Start()
        {
            // Subscribe to obstacle touch event
            var scoreEvents = GetComponent<PlayerScores>();

            scoreEvents.OnTouchesObstacle += HandlePlayerTouchesObstacle;
            
            // Cache rigidbdy
            myRigidbody = GetComponent<Rigidbody2D>();
        }
        #endregion
        
        #region Event Handlers

        private void HandlePlayerTouchesObstacle()
        {
            // Apply damage to the player
            ApplyDamage(50f);
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
                // Notify subscribers
                OnDie?.Invoke();
                
                // Hardcoded Clamping
                Health = 0;
            }
            
            // Notify subscribers
            OnHealthUpdates?.Invoke(Health);
        }
        #endregion
    }
}