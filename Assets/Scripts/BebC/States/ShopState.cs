using UnityEngine;

namespace Beb.States {
    public class ShopState : BebStatesController {
        private Vector3 destination;
        public ShopState(BebControll beb, pohyb player, Vector3 destination) : base(beb, player) {
            currentState = States.shopping;
            this.destination = destination;
        }
        protected override void Enter() {
            beb.agent.isStopped = false;
            beb.agent.SetDestination(destination);
            base.Enter();
        }

        protected override void Update(){
            if (beb.agent.remainingDistance < 1.5f) {
                nextState = new IdleBeb(beb, player);
                stage = Stage.exit;
            }
        }

        protected override void Exit() {
            base.Exit();
        }
    }
}