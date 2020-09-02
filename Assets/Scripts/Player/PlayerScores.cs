using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class PlayerScores : MonoBehaviour
    {
        #region Public Events
        public UnityAction OnPlayerWin;
        #endregion

        #region Methods
        public void IncrementScore()
        {
            OnPlayerWin?.Invoke();
        }
        #endregion
    }
}
