using UnityEngine;

namespace Enemies.States {
    public class RangedEnemy : Enemy {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private GameObject muzzle;
    public override void Attack() {
        Projectile.MakeProjectile(stats.Damage, stats.Accuracy, 4, player.transform.position, projectilePrefab, muzzle, true);
    }
    }
}