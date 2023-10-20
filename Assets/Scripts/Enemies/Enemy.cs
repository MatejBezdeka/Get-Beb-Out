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
    public static GameObject player { get; private set; }
    [SerializeField] GameObject p;
    [SerializeField] public EnemyStats stats;
    public Vector3 startingPos { get; protected set; }
    public NavMeshAgent agent { get; private set; }
    protected StateController state;
    protected virtual void Start() {
        startingPos = transform.position;
        player = p;
        agent = GetComponent<NavMeshAgent>();
        state = new IdleState(this);
        StartCoroutine(Process());
    }
    
    IEnumerator Process() {
        WaitForSeconds waitTime = new WaitForSeconds(0.50f);
        while (true) {
            state = state.Process();
            Debug.Log(state);
            yield return waitTime;
        }
    }
    public void Hit(int damage) {
        
    }
    public void Die() {
        StopCoroutine(Process());
        Destroy(this);
    }
    
    public abstract void Attack();
    public abstract void Reload();
    public abstract void Pursue();
    public abstract void Retreat();

}
