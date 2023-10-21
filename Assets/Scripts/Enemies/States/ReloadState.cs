using skripts.Enemies;
using UnityEngine;

namespace Enemies.States {
    public class ReloadState : StateController {
        private float currentCooldown;
        public ReloadState(Enemy parent, bool fromPursue) : base(parent) {
            stateNow = currentState.reload;
        }
        protected override void Enter() {
            parent.agent.isStopped = true;
            currentCooldown = 0;
            base.Enter();
        }

        protected override void Update() {
            if (parent.transform.CalculateDistance(GameManager.manager.Player.transform) > parent.stats.AttackRange) {
                nextState = new PursueState(parent);
                stage = stateStage.exit;
                return;
            }
            currentCooldown += Time.deltaTime;
            if (currentCooldown >= parent.stats.TimeBetweenAttacks) {
                nextState = new AttackState(parent);
                stage = stateStage.exit;
            }
        }

        protected override void Exit() {
            parent.agent.isStopped = false;
            base.Exit();
        }

        
    }
}