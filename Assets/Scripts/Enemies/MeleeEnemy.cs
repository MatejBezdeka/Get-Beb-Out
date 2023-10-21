using UnityEngine;

namespace Enemies.States {
    public class MeleeEnemy : Enemy {
        [SerializeField] private ParticleSystem attackEffect;
        protected override void Start() {
            base.Start();
            
            attackEffect.transform.localPosition = new Vector3(0,0,0);
        }
        public override void Attack() {
            Debug.Log("aaaaaargh");
            attackEffect.Play(true);
            //player.attack(stats.Damage);
        }
    }
}