using Enemies.States;
using skripts.Enemies;
using UnityEngine.AI;

namespace Beb.States {
    public class IdleBeb : BebStatesController {
        public IdleBeb(BebControll beb, pohyb player) : base(beb, player) {
            currentState = States.idle;
        }
        protected override void Enter() {
            beb.agent.isStopped = true;
            base.Enter();
        }

        protected override void Update(){
            if (beb.agent.transform.CalculateDistance(GameManager.manager.Player.transform) > beb.followStartDistance) {
                nextState = new FollowState(beb, player);
                stage = Stage.exit;
            }
        }

        protected override void Exit() {
            beb.agent.isStopped = false;
            base.Exit();
        }
    }
}