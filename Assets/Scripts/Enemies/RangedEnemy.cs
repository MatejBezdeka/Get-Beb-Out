using UnityEngine;

namespace Enemies.States {
    public class RangedEnemy : Enemy {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private GameObject muzzle;
        [SerializeField] float projectileSpeed = 2;
    public override void Attack() {
        Projectile.MakeProjectile(stats.Damage, stats.Accuracy, projectileSpeed, GameManager.manager.Player.transform.position, projectilePrefab, muzzle, true);
    }
    }
}