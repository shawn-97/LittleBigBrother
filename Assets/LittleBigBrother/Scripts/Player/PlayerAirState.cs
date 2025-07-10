using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.LittleBigBrother.Scripts.Player
{
    public class PlayerAirState : PlayerEntityState
    {
        public PlayerAirState(global::Player _player, PlayerStateMachine _stateMachine, string _animationBoolName, string _stateName) : base(_player, _stateMachine, _animationBoolName, _stateName)
        {
        }

        public override void Update()
        {
            base.Update();
            if(player.moveInput.x != 0)
            {
                player.SetVelocity(player.moveInput.x*(player.moveSpeed * player.inAirMoveMultiplier),rigidbody2D.linearVelocity.y);
            }
        }
    }
}
