using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour {
    public static GameManager manager;
    [SerializeField] private List<GameObject> enemyList;
    [SerializeField] private pohyb player;
    public pohyb Player => player;
    public List<SpawnPoint> spawns;
    

    void Awake() {
        manager = this;
    }

    void Start() {
        foreach (GameObject point in GameObject.FindGameObjectsWithTag("SpawnPoint")) {
            spawns.Add(point.GetComponent<SpawnPoint>());
        }

        foreach (var spawnPoint in spawns) {
            spawnPoint.SpawnEnemy(GetRandomEnemy());
        }
    }
    
    

    public GameObject GetRandomEnemy() {
        return enemyList[Random.Range(0,enemyList.Count)];
    }
}
