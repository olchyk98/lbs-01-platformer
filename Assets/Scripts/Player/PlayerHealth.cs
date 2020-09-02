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

        #endregion
        
        #region Public Events
        public UnityAction OnDie;
        public UnityAction<float> OnHealthUpdates;
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