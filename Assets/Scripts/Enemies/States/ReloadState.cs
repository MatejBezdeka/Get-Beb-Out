using skripts.Enemies;
using UnityEngine;

namespace Enemies.States {
    public class ReloadState : StateController {
        private float currentCooldown;
        public ReloadState(Enemy parent, bool fromPursue) : base(parent) {
            stateNow = currentState.reload;
        }
        protected override void Enter() {
            currentCooldown = 0;
            base.Enter();
        }

        protected override void Update() {
            currentCooldown += Time.deltaTime;
            if (currentCooldown >= parent.stats.TimeBetweenAttacks) {
                nextState = new AttackState(parent);
                stage = stateStage.exit;
            }

            if (parent.transform.CalculateDistance(Enemy.player.transform) > parent.stats.AttackRange) {
                nextState = new PursueState(parent);
                stage = stateStage.exit;
            }
        }

        protected override void Exit() {
            base.Exit();
        }

        
    }
}