using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class Checkpoint : MonoBehaviour
    {
        /// <summary>
        /// Description:
        /// Standard Unity function called when a Collider2D hits another Collider2D (non-triggers)
        /// Inputs:
        /// Collision2D collision
        /// Returns:
        /// void (no return)
        /// </summary>
        /// <param name="collision">The Collision2D that set of the function call</param>
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.gameObject.name.Contains("Player"))
            {
                Health health = collision.collider.gameObject.GetComponent<Health>();
                health.SetRespawnPoint(this.transform.position);
                Destroy(this.gameObject);
            }
        }
    }
}