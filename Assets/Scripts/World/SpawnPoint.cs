using UnityEngine;

namespace World {
    public class SpawnPoint : MonoBehaviour {
        [SerializeField, Range(1,10)] private float difficultyMultiplayer;

        public void SpawnEnemy(GameObject enemy) {
            Instantiate(enemy, transform);
        }
    }
}