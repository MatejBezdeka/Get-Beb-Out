using System;
using System.Collections;
using Enemies.States;
using UnityEngine;
using UnityEngine.AI;
using World;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Enemy : MonoBehaviour {
    [SerializeField] public EnemyStats stats;
    private int hp;
    public SpawnPoint spawn;
    public int id;
    public Vector3 startingPos { get; protected set; }
    public NavMeshAgent agent { get; private set; }
    protected StateController state;
    protected virtual void Start() {
        startingPos = transform.position;
        hp = stats.MaxHp;
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
        if ((hp -= damage) <= 0) {
            Die();
        }
    }
    void Die() {
        spawn.EnemyDied(this);
        StopCoroutine(Process());
        Destroy(gameObject);
    }
    
    public abstract void Attack();

}
