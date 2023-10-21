using UnityEngine;

namespace Enemies.States {
    public class RangedEnemy : Enemy {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private GameObject muzzle;
    public override void Attack() {
        Projectile.MakeProjectile(stats.Damage, stats.Accuracy, 4, GameManager.manager.Player.transform.position, projectilePrefab, muzzle, true);
    }
    }
}