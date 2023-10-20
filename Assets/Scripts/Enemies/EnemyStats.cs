using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (menuName = "Enemies/EnemyStats")]
public class EnemyStats : ScriptableObject {
    [SerializeField, Range(1, 200)] private int hp;
    [SerializeField, Range(1, 100)]  private int damage;
    [SerializeField, Range(1,10)] private float speed;
    [SerializeField, Range(1,50)] private float attackRange;
    [SerializeField, Range(1,50)] private float engageRange;

    #region Getters
    
    public int Hp => hp;
    public int Damage => damage;
    public float Speed => speed;
    public float AttackRange => attackRange;
    public float EngageRange => engageRange;

    #endregion
}
