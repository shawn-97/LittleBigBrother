using UnityEngine;

public class PlayerWallSlideState : PlayerEntityState
{
    public PlayerWallSlideState(Player _player, PlayerStateMachine _stateMachine, string _animationBoolName, string _stateName) : base(_player, _stateMachine, _animationBoolName, _stateName)
    {
    }




    public override void Update()
    {
        base.Update();
        HandleWallSlide();
        if (player.groundDetected)
        {
            playerStateMachine.ChangeState(player.playerIdleState);
            player.Flip();
        }

        if (!player.wallDetected)
        {
            playerStateMachine.ChangeState(player.playerFallState);
        }

    }

    private void HandleWallSlide()
    {
        if(player.moveInput.y < 0)
        {
            player.SetVelocity(player.moveInput.x,rigidbody2D.linearVelocity.y);

        }
        else
        {
            player.SetVelocity(player.moveInput.x, rigidbody2D.linearVelocity.y * player.wallSlideSlowMultiplier);
        }
    }
}
