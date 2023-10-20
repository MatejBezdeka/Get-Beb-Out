using skripts.Enemies;
using UnityEngine;

namespace Enemies.States {
    public class IdleState : StateController{
        public IdleState(Enemy parent) : base(parent) {
            stateNow = currentState.idle;
            parent.agent.isStopped = false;

            base.Enter();
        }
        protected override void Enter() {
            
            base.Enter();
        }

        protected override void Update(){
            if (parent.transform.CalculateDistance(Enemy.player.transform) < parent.stats.SeeRange) {
                nextState = new PursueState(parent);
                stage = stateStage.exit;
            }
        }

        protected override void Exit() {
            base.Exit();
        }
    }
}