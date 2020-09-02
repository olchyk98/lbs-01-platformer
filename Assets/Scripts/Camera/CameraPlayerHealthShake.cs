using System.Collections;
using Player;
using UnityEngine;

namespace Camera
{
    // REFACTOR: -> CameraShake -> Access via camera object and use public method .Shake
    public class CameraPlayerHealthShake : MonoBehaviour
    {
        #region Fields

        [SerializeField] private PlayerHealth myTargetHealth;
        [SerializeField] [Range(.01f, .8f)] private float myDuration;
        [SerializeField] [Range(.01f, .8f)] private float myMagnitude;

        private Transform myTransform;

        #endregion
        
        #region RP Methods

        private void Start()
        {
            // Cache transform
            myTransform = GetComponent<Transform>();
            
            // Subscribe to player's health change
            myTargetHealth.OnHealthUpdates = health =>
            {
                StartCoroutine(Shake());
            };
        }
        #endregion
        
        #region Methods

        private IEnumerator Shake()
        {
            // Save start position
            Vector3 startPosition = myTransform.localPosition;
            
            // Declare variable for elapsed millis
            float elapsed = 0f;
            
            // Shake the camera
            while (elapsed < myDuration)
            {
                float x = Random.Range(-1f, 1f) * myMagnitude;
                float y = Random.Range(-1f, 1f) * myMagnitude;
                
                // TODO: Test
                myTransform.localPosition = new Vector3(x, y, startPosition.z);

                elapsed += Time.deltaTime;
                
                yield return null;
            }
            
            // Restore camera position
            myTransform.localPosition = startPosition;
        }
        #endregion
    }
}