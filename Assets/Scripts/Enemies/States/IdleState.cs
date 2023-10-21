﻿using skripts.Enemies;
using UnityEngine;

namespace Enemies.States {
    public class IdleState : StateController{
        public IdleState(Enemy parent) : base(parent) {
            stateNow = currentState.idle;
        }
        protected override void Enter() {
            parent.agent.isStopped = true;
            base.Enter();
        }

        protected override void Update(){
            if (parent.transform.CalculateDistance(GameManager.manager.Player.transform) < parent.stats.SeeRange) {
                nextState = new PursueState(parent);
                stage = stateStage.exit;
            }
        }

        protected override void Exit() {
            parent.agent.isStopped = false;
            base.Exit();
        }
    }
}