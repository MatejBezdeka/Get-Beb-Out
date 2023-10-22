using skripts.Enemies;
using UnityEngine;

namespace Beb.States {
    public class GoTo : BebStatesController {
        private Vector3 destination;
        public GoTo(BebControll beb, pohyb player, Vector3 destination) : base(beb, player) {
            currentState = States.going;
            this.destination = destination;
        }
        protected override void Enter() {
            beb.agent.isStopped = false;
            beb.agent.SetDestination(destination);
            base.Enter();
        }

        protected override void Update(){
            if (beb.agent.remainingDistance < 0.5f) {
                nextState = new IdleBeb(beb, player);
                stage = Stage.exit;
            }
        }

        protected override void Exit() {
            base.Exit();
        }
    }
}