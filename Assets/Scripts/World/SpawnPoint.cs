using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

namespace World {
    public class SpawnPoint : MonoBehaviour {
        [SerializeField, Range(1,10)] private float difficultyMultiplayer = 1;
        [SerializeField, Range(1,25)] float spawnRange = 5;
        //private int numOfEnemies = 0;
        private List<Enemy> enemies;
        [SerializeField, Range(20,600)] int spawnCooldown = 60;
        [SerializeField, Range(5, 50)] private int maxEnemyCount = 10;
        [SerializeField, Range(1, 25)] int spawnBurstCount = 5;
        private int currentCooldown = 0;
        private void Start() {
            enemies = new List<Enemy>();
            StartCoroutine(Process());
            SpawnBurst();
        }

        public void SpawnEnemy(GameObject enemy) {
            Instantiate(enemy, new Vector3(transform.position.x + Random.Range(-spawnRange, spawnRange), transform.position.y, transform.position.z + Random.Range(-spawnRange, spawnRange)), new Quaternion(0,0,0,0));
            var comp = enemy.GetComponent<Enemy>();
            comp.spawn = this;
            comp.id = comp.id;
            enemies.Add(comp);
        }

        IEnumerator Process() {
            WaitForSeconds waitForSeconds = new WaitForSeconds(1);
            while (true) {
                currentCooldown++;
                if (currentCooldown >= spawnCooldown) {
                    SpawnBurst();
                    currentCooldown = 0;
                }
                yield return waitForSeconds;
            }
        }

        void SpawnBurst() {
            if (enemies.Count >= maxEnemyCount) {
                StopCoroutine(Process());
                return;   
            }
            for (int i = 0; i < spawnBurstCount; i++) {
                SpawnEnemy(GameManager.manager.GetRandomEnemy());
            }

            
        }
        
        public void EnemyDied(Enemy enemy) {
            enemies.Remove(enemy);
            Debug.Log("enemy died " + enemies.Count);
            if (enemies.Count < maxEnemyCount) {
                StartCoroutine(Process());
            }
        }
    }
}