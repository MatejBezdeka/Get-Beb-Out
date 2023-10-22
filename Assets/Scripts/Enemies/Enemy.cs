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
    public NavMeshAgent agent { get; set; }
    protected StateController state;
    [SerializeField] Animator animator;
    protected virtual void Start() {
        //agent.angularSpeed = 999;
        //agent.acceleration = 999;
        //agent.autoBraking = true;
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
            switch (state.stateNow)
            {
                case StateController.currentState.idle:
                    animator.SetBool("isIdle", true);
                    break;
                case StateController.currentState.attack:
                    animator.SetTrigger("hit");
                    break;
                case StateController.currentState.pursue:
                    animator.SetBool("isRunning", true);
                    break;
            }
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
        animator.SetTrigger("die");
        Destroy(gameObject);
    }
    
    public abstract void Attack();

}
