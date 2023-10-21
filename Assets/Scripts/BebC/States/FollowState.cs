using skripts.Enemies;

namespace Beb.States {
    public class FollowState : BebStatesController{
        public FollowState(BebControll beb, pohyb player) : base(beb, player) {
            currentState = States.follow;
        }
        protected override void Enter() {
            beb.agent.isStopped = false;
            
            base.Enter();
        }

        protected override void Update() {
            if (beb.transform.CalculateDistance(player.transform) > 1) {
                beb.agent.SetDestination(player.transform.position);
            }
            else {
                beb.agent.SetDestination(beb.transform.position);
            }
        }

        protected override void Exit() {
            base.Exit();
        }
    }
}