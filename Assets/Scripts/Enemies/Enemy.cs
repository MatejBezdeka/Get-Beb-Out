using System;
using System.Collections;
using System.Collections.Generic;
using Enemies.States;
using skripts.Enemies;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Enemy : MonoBehaviour {
    [SerializeField] public EnemyStats stats;
    public event Action<GameObject> died;
    public Vector3 startingPos { get; protected set; }
    public NavMeshAgent agent { get; private set; }
    protected StateController state;
    protected virtual void Start() {
        startingPos = transform.position;
        stats.Start();
        agent = GetComponent<NavMeshAgent>();
        state = new IdleState(this);
        StartCoroutine(Process());
    }
    
    IEnumerator Process() {
        WaitForSeconds waitTime = new WaitForSeconds(0.10f);
        while (true) {
            state = state.Process();
            yield return waitTime;
        }
    }
    public void Hit(int damage) {
        if (stats.GetHit(damage)) {
            Die();
        }
    }
    void Die() {
        died?.Invoke(gameObject);
        StopCoroutine(Process());
        Destroy(this);
    }
    
    public abstract void Attack();

}
