using UnityEngine;
using UnityEngine.UIElements;

public class Player : Entity
{

    [Header("Attack Details")]

    [Header("Move Info")]
    public float moveSpeed = 12f;
    public float jumpForce = 15f;
    [Range(0f, 1f)]
    public float inAirMoveMultiplier = .7f;
    [Range(0, 1)]
    public float wallSlideSlowMultiplier = .3f;


    public PlayerInputSet input {  get; private set; }  

    #region Property States

    public PlayerStateMachine playerStateMachine { get; private set; }
    public PlayerIdleState playerIdleState { get; private set; }
    public PlayerMoveState playerMoveState { get; private set; }
    public PlayerJumpState playerJumpState { get; private set; }
    public PlayerFallState playerFallState { get; private set; }    
    public PlayerWallSlideState playerWallSlideState    { get; private set; }   

    public Vector2 moveInput{get; private set; }

    #endregion

    protected override void Awake()
    {
        base.Awake();



        //Initialize all properties states here. example 
        playerStateMachine = new PlayerStateMachine();  
        input = new PlayerInputSet();   

        playerIdleState = new PlayerIdleState(this,playerStateMachine,"idle","IdleState");
        playerMoveState = new PlayerMoveState(this, playerStateMachine, "move", "MoveState");
        playerJumpState = new PlayerJumpState(this, playerStateMachine, "jumpfall", "JumpState");
        playerFallState = new PlayerFallState(this, playerStateMachine, "jumpfall", "FallState");
        playerWallSlideState = new PlayerWallSlideState(this, playerStateMachine, "wallslide", "WallSlideState");

    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += context => moveInput = context.ReadValue<Vector2>();
        input.Player.Movement.canceled += context => moveInput = Vector2.zero;
    }

    private void OnDisable()
    {
       input.Disable();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        playerStateMachine.Initialize(playerIdleState);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        playerStateMachine.UpdateActiveState();
    }



}
