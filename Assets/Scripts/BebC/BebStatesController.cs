using UnityEngine.AI;

namespace Beb {
    public class BebStatesController {
        protected enum States {
            idle, follow, mine, fight, going, shopping
        }

        protected enum Stage {
            enter, update, exit
        }

        protected States currentState;
        protected BebStatesController nextState;
        protected Stage stage;
        protected BebControll beb;
        protected pohyb player;
        public BebStatesController(BebControll beb, pohyb player) {
            this.beb = beb;
            this.player = player;
            stage = Stage.enter;
        }

        protected virtual void Enter() {
            stage = Stage.update;
        }

        protected virtual void Update() { }

        protected virtual void Exit() {
            stage = Stage.exit;
        }

        public BebStatesController Process() {
            switch (stage) {
                case Stage.enter:
                    Enter();
                    break;
                case Stage.update:
                    Update();
                    break;
                case Stage.exit:
                default:
                    Exit();
                    return nextState;
            }
            return this;
        }

        public void ChangeState(BebStatesController next) {
            nextState = next;
            stage = Stage.exit;
        }
    }
}