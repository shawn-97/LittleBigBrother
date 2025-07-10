using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player _player, PlayerStateMachine _stateMachine, string _animationBoolName, string _stateName) : base(_player, _stateMachine, _animationBoolName, _stateName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        
        player.SetVelocity(player.moveInput.x * player.moveSpeed, rigidbody2D.linearVelocity.y);
        if (player.moveInput.x == 0)
        {
            playerStateMachine.ChangeState(player.playerIdleState);
        }
    }
}
