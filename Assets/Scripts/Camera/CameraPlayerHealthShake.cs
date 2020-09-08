using System.Collections;
using Player;
using UnityEngine;

namespace Camera
{
    [RequireComponent(typeof(CameraShake))]
    public class CameraPlayerHealthShake : MonoBehaviour
    {
        #region Fields

        [SerializeField] private PlayerHealth myTargetHealth;

        #endregion
        
        #region RP Methods

        private void Start()
        {
            // Cache shake component
            CameraShake cameraShake = GetComponent<CameraShake>();
            
            // Subscribe to player's health change
            myTargetHealth.OnHealthUpdates = health =>
            {
                cameraShake.Shake();
            };
        }
        #endregion
        
        
    }
}