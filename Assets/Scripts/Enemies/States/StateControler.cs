using UnityEngine;
using UnityEngine.AI;

namespace Enemies.States {
    public class StateController {
            protected enum currentState {
                idle, attack, pursue, reload, retreat
            };
            protected enum stateStage {
                enter, update, exit
            };

            protected Enemy parent;
            protected StateController nextState;
            protected stateStage stage;
            protected currentState stateNow;

            protected StateController(Enemy parent) {
                this.parent = parent;                
                stage = stateStage.enter;
                
            }

            protected virtual void Enter() {
                stage = stateStage.update;
            }

            protected virtual void Update() { }

            protected virtual void Exit() {
                stage = stateStage.exit;
            }

            public StateController Process() {
                switch (stage) {
                    case stateStage.enter:
                        Enter();
                        break;
                    case stateStage.update:
                        Update();
                        break;
                    case stateStage.exit:
                    default:
                        Exit();
                        return nextState;
                }
                return this;
            }
    }
}