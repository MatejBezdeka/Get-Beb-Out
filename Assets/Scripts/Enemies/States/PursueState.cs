using skripts.Enemies;
using UnityEngine;

namespace Enemies.States {
    public class PursueState : StateController {
        public PursueState(Enemy parent) : base(parent) {
            stateNow = currentState.pursue;
        }
        protected override void Enter() {
            base.Enter();
        }

        protected override void Update() {
            float distance = parent.transform.CalculateDistance(GameManager.manager.Player.transform);
            float distanceToSpawn = parent.transform.CalculateDistance(parent.startingPos);
            if (distance <= parent.stats.AttackRange) {
                nextState = new ReloadState(parent, true);
                parent.agent.SetDestination(parent.transform.position);
                stage = stateStage.exit;
                return;
            }
            if (distanceToSpawn >= parent.stats.EngageRange) {
                nextState = new RetreatState(parent);
                stage = stateStage.exit;
                return;
            }
            parent.agent.SetDestination(GameManager.manager.Player.transform.position);
        }

        protected override void Exit() {
            base.Exit();
        }
    }
}