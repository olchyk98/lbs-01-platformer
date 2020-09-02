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

            // Interact with the object if can
            otherIntractable?.InteractWith(gameObject);
        }
        #endregion
    }
}