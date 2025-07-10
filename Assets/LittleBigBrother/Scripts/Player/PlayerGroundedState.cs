using UnityEngine;

public class PlayerGroundedState : PlayerEntityState
{
    public PlayerGroundedState(Player _player, PlayerStateMachine _stateMachine, string _animationBoolName, string _stateName) : base(_player, _stateMachine, _animationBoolName, _stateName)
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
        if(rigidbody2D.linearVelocity.y<0 && player.groundDetected == false)
        {
            playerStateMachine.ChangeState(player.playerFallState);
        }
        if(playerInputSet.Player.Jump.WasPerformedThisFrame())
        {
            playerStateMachine.ChangeState(player.playerJumpState);
        }
    }
}
