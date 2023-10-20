namespace Enemies.States {
    public class AttackState : StateController {
        public AttackState(Enemy parent) : base(parent) {
            stateNow = currentState.attack;
        }

        protected override void Enter() {
            base.Enter();
        }

        protected override void Update(){
            parent.Attack();
            nextState = new ReloadState(parent, false);
            stage = stateStage.exit;
        }

        protected override void Exit() {
            base.Exit();
        }
    }
}