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
        private List<GameObject> enemies = new List<GameObject>();
        [SerializeField, Range(20,600)] int spawnCooldown = 60;
        [SerializeField, Range(5, 50)] private int maxEnemyCount = 10;
        [SerializeField, Range(1, 25)] int spawnBurstCount = 5;
        private int currentCooldown = 0;
        private void Start() {
            StartCoroutine(Process());
            SpawnBurst();
        }

        public void SpawnEnemy(GameObject enemy) {
            enemies.Add(enemy);
            Instantiate(enemy, new Vector3(transform.position.x + Random.Range(-spawnRange, spawnRange), transform.position.y, transform.position.z + Random.Range(-spawnRange, spawnRange)), new Quaternion(0,0,0,0));
            enemy.GetComponent<Enemy>().died += EnemyDied;
        }

        IEnumerator Process() {
            WaitForSeconds waitForSeconds = new WaitForSeconds(1);
            currentCooldown++;
            if (currentCooldown >= spawnCooldown) {
                SpawnBurst();
                currentCooldown = 0;
            }
            yield return waitForSeconds;
        }

        void SpawnBurst() {
            for (int i = 0; i < spawnBurstCount; i++) {
                SpawnEnemy(GameManager.manager.GetRandomEnemy());
            }

            if (enemies.Count >= maxEnemyCount) {
                StopCoroutine(Process());
            }
        }
        void EnemyDied(GameObject enemy) {
            enemies.Remove(enemy);
            if (enemies.Count < maxEnemyCount) {
                StartCoroutine(Process());
            }
        }
    }
}