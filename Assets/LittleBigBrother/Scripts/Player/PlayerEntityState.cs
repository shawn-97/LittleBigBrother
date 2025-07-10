using UnityEngine;

public abstract class PlayerEntityState 
{
    protected PlayerStateMachine playerStateMachine;
    protected Player player;
    private string animationBoolName;
    private string stateName;
    protected float xInput;
    protected float yInput;
    protected Rigidbody2D rigidbody2D;
    protected PlayerInputSet playerInputSet; 
    protected Animator animator;

    public PlayerEntityState (Player _player,PlayerStateMachine _stateMachine,string _animationBoolName, string _stateName)
    {
        this.player = _player;
        this.playerStateMachine = _stateMachine;
        this.animationBoolName = _animationBoolName;
        this.stateName = _stateName;

        rigidbody2D = player.rigidBody2D;
        this.animator = player.animator;
        playerInputSet = player.input;


    }

    public virtual void Enter()
    {
          
        player.animator.SetBool(animationBoolName, true);
    //Everytime state will be change, enter will be called.
    }

    public virtual void Update()
    {

    }

    public virtual void Exit()
    {
       player.animator.SetBool(animationBoolName, false);     

    }

}
