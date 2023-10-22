using System.Collections;
using UnityEngine;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;
namespace Beb.States
{
    public class StoneState : BebStatesController
    {
        private Vector3 destination;
        private bool phaseOne = true;
        private GameObject stone;
        private float currentMineTime = 0;
        public StoneState(BebControll beb, pohyb player, Vector3 destination, GameObject stone) : base(beb, player)
        {
            currentState = States.mine;
            this.destination = destination;
            this.stone = stone;
        }
        protected override void Enter()
        {
            beb.agent.isStopped = false;
            beb.agent.SetDestination(destination);
            base.Enter();
        }

        protected override void Update()
        {
            if (phaseOne)
            {
                if (beb.agent.remainingDistance < 0.5f)
                {
                    phaseOne = false;
                    beb.animator.SetBool("isWalking", false);
                    beb.animator.SetBool("isMining", true);
                }
            }
            else
            {
                currentMineTime += Time.deltaTime;
                if (currentMineTime >= beb.mineTime)
                {
                    beb.animator.SetBool("isMining", false);
                    beb.animator.SetBool("isWalking", false);
                    Object.Destroy(stone);
                }
            }
        }

        IEnumerator Mine()
        {
            WaitForSeconds waitForSeconds = new WaitForSeconds(5);
            yield return waitForSeconds;
        }
        protected override void Exit()
        {
            player.stoneCount++;
            GameManager.manager.normalGUIScript.UpdateStoneCountUI();
            base.Exit();
        }
    }
}