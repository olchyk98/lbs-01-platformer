using System;
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
            
            // Calculate next camera's position
            float nextX = Mathf.Lerp(cameraPosition.x, targetTransform.position.x, .1f);
            
            // Create new position vector
            cameraPosition.x = nextX;

            // Set new camera position
            myTransform.position = cameraPosition;
        }
        #endregion
    }
}
