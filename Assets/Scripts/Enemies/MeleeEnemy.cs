using UnityEngine;

namespace Enemies.States {
    public class MeleeEnemy : Enemy {
        protected override void Start() {
            base.Start();
        }
        public override void Attack() {
            Debug.Log("attack");
            Debug.Log(state);
        }

        public override void Reload() {
            throw new System.NotImplementedException();
        }

        public override void Pursue() {
            throw new System.NotImplementedException();
        }

        public override void Retreat() {
            throw new System.NotImplementedException();
        }
    }
}