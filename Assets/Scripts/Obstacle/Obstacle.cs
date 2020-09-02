using Contracts;
using Player;
using UnityEngine;

namespace Obstacle
{
    public class Obstacle : MonoBehaviour, IIntractable
    {
        public void InteractWith(GameObject target)
        {
            // Get target's health
            PlayerHealth targetHealth = target.GetComponent<PlayerHealth>();
            
            // Check if component extracted
            if (targetHealth == null) return;
            
            // Apply damage to the target
            targetHealth.ApplyDamage(20f);
        }
    }
}