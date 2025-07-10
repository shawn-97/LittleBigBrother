using Assets.LittleBigBrother.Scripts.Player;
using UnityEngine;


public class PlayerJumpState : PlayerAirState
{
    public PlayerJumpState(Player _player, PlayerStateMachine _stateMachine, string _animationBoolName, string _stateName) : base(_player, _stateMachine, _animationBoolName, _stateName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(rigidbody2D.linearVelocity.x, player.jumpForce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        player.SetVelocity(player.moveInput.x * player.moveSpeed, rigidbody2D.linearVelocity.y);

         if (rigidbody2D.linearVelocity.y<0)
        {
            playerStateMachine.ChangeState(player.playerFallState); 
        } 
    }
}
