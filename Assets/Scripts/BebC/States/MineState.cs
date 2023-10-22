using System.Collections;
using UnityEngine;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;
namespace Beb.States {
    public class MineState : BebStatesController {
        private Vector3 destination;
        private bool phaseOne = true;
        private GameObject crystal;
        private float currentMineTime = 0;
        public MineState(BebControll beb, pohyb player, Vector3 destination, GameObject crystal) : base(beb, player) {
            currentState = States.mine;
            this.destination = destination;
            this.crystal = crystal;
        }
        protected override void Enter() {
            beb.agent.isStopped = false;
            beb.agent.SetDestination(destination);
            base.Enter();
        }

        protected override void Update(){
            if (phaseOne) {
                if (beb.agent.remainingDistance < 0.5f)
                {
                    phaseOne = false;
                    beb.animator.SetBool("isWalking", false);
                    beb.animator.SetBool("isMining", true);
                }    
            }
            else {
                currentMineTime += Time.deltaTime;
                if (currentMineTime >= beb.mineTime) {
                    beb.animator.SetBool("isMining", false);
                    beb.animator.SetBool("isWalking", false);
                    beb.states.ChangeState(new FollowState(beb, GameManager.manager.Player));
                    Object.Destroy(crystal);
                }
            }
        }

        IEnumerator Mine() {
            WaitForSeconds waitForSeconds = new WaitForSeconds(5);
            yield return waitForSeconds;
        }
        protected override void Exit() {
            base.Exit();
        }
    }
}