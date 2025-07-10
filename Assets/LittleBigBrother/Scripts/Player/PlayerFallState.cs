using Assets.LittleBigBrother.Scripts.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class PlayerFallState : PlayerAirState
{
    public PlayerFallState(Player _player, PlayerStateMachine _stateMachine, string _animationBoolName, string _stateName) : base(_player, _stateMachine, _animationBoolName, _stateName)
    {
    }


    public override void Update()
    {
        base.Update();
        player.SetVelocity(player.moveInput.x * player.moveSpeed, rigidbody2D.linearVelocity.y);

        if (player.groundDetected)
        {
            playerStateMachine.ChangeState(player.playerIdleState);
        }

        if (player.wallDetected)
        {
            {
                playerStateMachine.ChangeState(player.playerWallSlideState);
            }
        }

    }
}
