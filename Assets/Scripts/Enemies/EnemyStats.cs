using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (menuName = "Enemies/EnemyStats")]
public class EnemyStats : ScriptableObject {
    
    [SerializeField, Range(1, 200)] private int maxHp = 10;
    private int hp;
    [SerializeField, Range(1, 100)] private int damage;
    [SerializeField, Range(0.1f, 10)] private float timeBetweenAttacks;
    [SerializeField, Range(1,10)] private float speed;
    [SerializeField, Range(1,50)] private float attackRange;
    [SerializeField, Range(1,50), Tooltip("How far will the enemy go from the original spawn")] private float engageRange;
    [SerializeField, Range(1,50), Tooltip("Distance to player to start engaging into combat")] private float seeRange;
    [SerializeField] private GameObject projectilePrefab = null;
    [SerializeField] private bool ranged = false;
    [SerializeField] private GameObject muzzle = null;

    public void Start() {
        hp = maxHp;
    }
    #region Getters
    public int MaxHp => maxHp;
    public int Hp => hp;
    public int Damage => damage;
    public float TimeBetweenAttacks => timeBetweenAttacks;
    public float Speed => speed;
    public float AttackRange => attackRange;
    public float EngageRange => engageRange;
    public float SeeRange => seeRange;

    #endregion
}
