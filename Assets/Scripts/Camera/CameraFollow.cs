using UnityEngine;

namespace Camera
{
    [RequireComponent(typeof(Transform))]
    public class CameraFollow : MonoBehaviour
    {
        #region Fields
        private Transform myTransform;
        
        public Transform targetTransform;
        #endregion
    
        #region RP Methods
        private void Start()
        {
            myTransform = GetComponent<Transform>();
        }

        private void FixedUpdate()
        {
            MoveToTarget();
        }
        #endregion
        
        #region Methods

        private void MoveToTarget()
        {
            // Access camera's position once
            Vector3 cameraPosition = myTransform.position;
            
            // Access target's position once
            Vector3 targetPosition = targetTransform.position;
            
            // Calculate next camera's position
            float lerpSpeed = .1f;
            float nextX = Mathf.Lerp(cameraPosition.x, targetPosition.x, lerpSpeed);
            float nextY = Mathf.Lerp(cameraPosition.y, targetPosition.y, lerpSpeed);
            
            // Update camera position
            cameraPosition.x = nextX;
            cameraPosition.y = nextY;
            
            // Set new camera position
            myTransform.position = cameraPosition;
        }
        #endregion
    }
}
