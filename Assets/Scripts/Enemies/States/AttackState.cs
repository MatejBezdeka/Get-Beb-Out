namespace Enemies.States {
    public class AttackState : StateController {

        public AttackState(Enemy parent) : base(parent) { }

        protected override void Enter() {
            parent.agent.isStopped = true;
            base.Enter();
        }

        protected override void Update(){
            parent.Attack();
            
        }

        protected override void Exit() {
            base.Exit();
        }
    }
}