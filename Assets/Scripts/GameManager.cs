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
    [SerializeField] private BebControll beb;
    //public Beb Beb => BEb; 
    public pohyb Player => player;
    public List<SpawnPoint> spawns;
    [SerializeField] private Canvas normalGUI;
    [SerializeField] private Canvas shop;
    [SerializeField] private Canvas deathScreen;
    [SerializeField] public GUI normalGUIScript;
    

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

    public void OpenShop() {
        shop.enabled = true;
        Time.timeScale = 0;
    }

    public GameObject GetRandomEnemy() {
        return enemyList[Random.Range(0,enemyList.Count)];
    }

    
}
