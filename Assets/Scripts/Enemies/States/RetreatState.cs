using skripts.Enemies;

namespace Enemies.States {
    public class RetreatState : StateController {
        public RetreatState(Enemy parent) : base(parent) {
            stateNow = currentState.retreat;
        }
        protected override void Enter() {
            base.Enter();
        }

        protected override void Update() {
            parent.agent.SetDestination(parent.startingPos);
            if (parent.transform.CalculateDistance(Enemy.player.transform) <= parent.stats.AttackRange + 3) {
                nextState = new PursueState(parent);
                stage = stateStage.exit;
                return;
            }if (parent.transform.CalculateDistance(parent.startingPos) < 2) {
                nextState = new IdleState(parent);
                stage = stateStage.exit;
            }
        }

        protected override void Exit() {
            base.Exit();
        }
    }
}