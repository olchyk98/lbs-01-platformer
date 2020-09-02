using Contracts;
using Player;
using UnityEngine;

namespace Coin
{
    public class Coin : MonoBehaviour, IIntractable
    {
        public void InteractWith(GameObject target)
        {
            // Get target's score
            // REFACTOR: Summarize -> PlayerScore -> Score
            PlayerScores targetScore = target.GetComponent<PlayerScores>();
            
            // Check if successfully extracted
            if (targetScore == null) return;
            
            // Increment score for the target
            targetScore.IncrementScore();
        }
    }
}