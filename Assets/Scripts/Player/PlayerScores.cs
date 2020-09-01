using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class PlayerScores : MonoBehaviour
    {
        #region Fields
        [SerializeField] private LayerMask obstaclesLayer;
        [SerializeField] private LayerMask coinsLayer;

        private Collider2D myCollider;

        public int Score { get; private set; }

        #endregion
        
        #region Public Events
        public UnityAction<int> OnPlayerScores;
        public UnityAction OnPlayerTouchesObstacle;
        #endregion
        
        #region RP Methods

        private void Start()
        {
            myCollider = GetComponent<Collider2D>();
        }
        #endregion

        #region Collider Events
        private void OnCollisionEnter2D(Collision2D other)
        {
            // Check if touching any special objects
            if (myCollider.IsTouchingLayers(obstaclesLayer))
            {
                IncrementScore();
            }

            if (myCollider.IsTouchingLayers(coinsLayer))
            {
                OnPlayerTouchesObstacle?.Invoke();
            }
        }
        #endregion
        
        #region Methods
        private void IncrementScore()
        {
            // Increment score
            Score++;
            
            // Notify all subscribers
            OnPlayerScores?.Invoke(Score);
        }
        #endregion
    }
}
