using System;
using System.Collections;
using System.Collections.Generic;
using skripts.Enemies;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {
    [SerializeField] protected EnemyStats stats;
    private Vector3 startingPos;
    enum state {
        idle, attack, retreat, reload, persuing
    }
    //player
    protected void Start() {
        StartCoroutine(SlowUpdate());
    }
    
    IEnumerator SlowUpdate() {
        WaitForSeconds waitTime = new WaitForSeconds(0.50f);
        while (true) {
            /*if (transform.CalculateDistance(player.transform) < stats.EngageRange) {
                
            }*/
            yield return waitTime;
        }
    }

    protected abstract void Do();

    public void Die() {
        StopCoroutine(SlowUpdate());
        Destroy(this);
    }

    protected abstract void Engage();
    protected abstract void Attack();
}
