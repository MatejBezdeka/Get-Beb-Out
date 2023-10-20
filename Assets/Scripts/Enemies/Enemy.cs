using System;
using System.Collections;
using System.Collections.Generic;
using Enemies.States;
using skripts.Enemies;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Enemy : MonoBehaviour {
    enum states {
        attack, idle, pursue, reload, retreat
    }
    enum stateStages {
        start, normal, exit
    }
    private static GameObject player;
    
    [SerializeField] protected EnemyStats stats;
    private Vector3 startingPos;
    public NavMeshAgent agent { get; private set; }
    private StateController stateController;
    
    //player
    protected void Start() {
        agent = GetComponent<NavMeshAgent>();
        stateController = new StateController(this);
        StartCoroutine(Process());
    }
    
    IEnumerator Process() {
        WaitForSeconds waitTime = new WaitForSeconds(0.50f);
        while (true) {
            stateController.Process();
            yield return waitTime;
        }
    }
    public void Hit(int damage) {
        
    }
    public void Die() {
        StopCoroutine(Process());
        Destroy(this);
    }
    
    public virtual bool Idle() {
        if (transform.CalculateDistance(player.transform) < stats.SeeRange) {
            return true;
        }
        return false;
    }
    public abstract void Attack();
    public abstract void Reload();
    public abstract void Pursue();
    public abstract void Retreat();

}
