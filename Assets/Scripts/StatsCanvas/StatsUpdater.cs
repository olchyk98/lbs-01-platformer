using System;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace StatsCanvas
{
    public class StatsUpdater : MonoBehaviour
    {
        #region Fields

        [Header("Text Objects")]
        [SerializeField] private Text myHealthText;

        [SerializeField] private Text myGlobalText;

        [Header("Event Hosts")]

        [SerializeField] private PlayerHealth myPlayerHealth;
        [SerializeField] private PlayerScores myPlayerScore;

        #endregion
        
        #region RP Methods

        private void Start()
        {
            // Subscribe to player health updates
            myPlayerHealth.OnHealthUpdates += (health) =>
            {
                myHealthText.text = $"Health: {health}";
            };
            
            // Subscribe to player on win event
            myPlayerScore.OnPlayerWin += () =>
            {
                myGlobalText.text = "You Won!";
            };
            
            // Subscribe to player on die event
            myPlayerHealth.OnDie += () =>
            {
                myGlobalText.text = "You Lose!";
            };

        }

        #endregion
    }
}
