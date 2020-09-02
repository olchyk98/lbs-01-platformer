using System;
using Contracts;
using UnityEngine;

namespace Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        #region Collider Events
        private void OnCollisionEnter2D(Collision2D other)
        {
            // Get IIntractable
            IIntractable otherIntractable = other.gameObject.GetComponent<IIntractable>();
            
            // Check if successfully extracted
            if (otherIntractable == null) return;
            
            // Interact with the object
            otherIntractable.InteractWith(gameObject);
        }
        #endregion
    }
}