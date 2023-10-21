using System;
using System.Collections;
using System.Collections.Generic;
using skripts.Enemies;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(Rigidbody))]

public class Projectile : MonoBehaviour {
    protected int damage;
    private float speed = 5;
    private float maxLifeTime = 5;
    private float currentTime = 0;
    protected GameObject self;

    public static void MakeProjectile(int damage, float spread, float speed, Vector3 destinationPos, GameObject prefab, GameObject muzzle, bool lobed) {
        GameObject projectile = Instantiate(prefab, muzzle.transform.position, muzzle.transform.rotation);
        Projectile projectileComp = projectile.AddComponent<Projectile>();
        projectileComp.self = projectile;
        
        projectileComp.damage = damage;
        projectileComp.speed = speed;
        destinationPos.y += 0.5f;
        projectile.transform.LookAt(destinationPos);
        //rozptyl
        var rigid = projectile.GetComponent<Rigidbody>();
        Vector3 direction = projectile.transform.forward * 9.81f;
        direction.y = 0.8f;
        //direction += projectile.transform.up;
        direction.x += Random.Range(-spread, spread);
        direction.y += Random.Range(-spread, spread);
        
        rigid.AddForce(direction * (speed * rigid.mass), ForceMode.Impulse);
    }
    
    protected void Start() {
    }

    protected virtual void Update() {
        Move();
        currentTime += Time.deltaTime;
        if (currentTime >= maxLifeTime) {
            Destroy();
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.transform.CompareTag("Player")) {
            //TODO damage Player
        }
    }

    protected virtual void Move() {
        
    }

    void Destroy() {
        //Debug.Log("destroyed");
        Destroy(self);
    }
}
