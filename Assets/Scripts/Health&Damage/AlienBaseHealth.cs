using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class AlienBaseHealth: Health
    {

        [Header("Spawn Enemies on Hit")]
        [Tooltip("The prefab of the enemies to spawn on death")]
        public GameObject enemyPrefab = null;
        [Tooltip("The number of enemies to spawn when this one dies")]
        public int enemiesToSpawn = 0;

        /// <summary>
        /// Description:
        /// Applies damage to the health unless the health is invincible. This is the AlienBaseHealth's version of the method.
        /// Inputs:
        /// int damageAmount
        /// Returns:
        /// void (no return)
        /// </summary>
        /// <param name="damageAmount">The amount of damage to take</param>
        public override void TakeDamage(int health)
        {
            for(int i = 0; i < enemiesToSpawn; i++)
                SpawnEnemy(GetSpawnLocation());

            base.TakeDamage(health);
        }

        /// <summary>
        /// Description:
        /// Spawn and set up an instance of the enemy prefab
        /// Inputs: 
        /// Vector3 spawnLocation
        /// Returns: 
        /// void (no return)
        /// </summary>
        /// <param name="spawnLocation">The location to spawn an enemy at</param>
        private void SpawnEnemy(Vector3 spawnLocation)
        {
            // Make sure the prefab is valid, then spawn enemy
            if (enemyPrefab != null)
            {
                GameObject enemyObj = Instantiate(enemyPrefab, spawnLocation, enemyPrefab.transform.rotation, null);
                Enemy enemy = enemyObj.GetComponent<Enemy>();
                enemy.includeEnemy = false;
            }
        }

        /// <summary>
        /// Description:
        /// Returns a generated spawn location for an enemy
        /// Inputs: 
        /// none
        /// Returns: 
        /// Vector3
        /// </summary>
        /// <returns>Vector3: The spawn location as determined by the function</returns>
        protected virtual Vector3 GetSpawnLocation()
        {
            // Get random coordinates
            float x = Random.Range(0 - 1f, 1f);
            float y = Random.Range(0 - 1f, 1f);
            // Return the coordinates as a vector
            return new Vector3(transform.position.x + x, transform.position.y + y, 0);
        }
    }
}