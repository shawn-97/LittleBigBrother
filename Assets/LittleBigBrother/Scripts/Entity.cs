using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;

public class Entity : MonoBehaviour
{

    [Header("Collision Info")]
    public Transform attackCheck;
    public float attackCheckRadius;

    [Header("Collision Detection")]
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected float wallCheckDistance;
    [SerializeField] protected LayerMask whatIsGround;
    [SerializeField] private Transform primaryWallCheck;
    [SerializeField] private Transform secondaryWallCheck;

    public bool groundDetected { get; private set; }
    public bool wallDetected { get; private set; }

    #region Components

    public Animator animator {  get; private set; }	
	public Rigidbody2D rigidBody2D {  get; private set; }

    #endregion


    #region Components

    protected bool isKnocked;
    public int facingDir { get; private set; } = 1;
    protected bool facingRight = true;
    #endregion
    protected virtual void Awake()
	{
        animator = GetComponentInChildren<Animator>();
        rigidBody2D = GetComponentInChildren<Rigidbody2D>();
    }

	protected virtual void Start()
	{
		
		
	}

	protected virtual void Update()
	{
        HandleCollisionDetection();
    }

    #region Velocity
    public virtual void SetZeroVelocity()
    {
        if (isKnocked) { return; }
        rigidBody2D.linearVelocity = new Vector2(0, 0);
    }

    public virtual void SetVelocity(float _xvelocity, float _yvelocity)
    {
        if (isKnocked) { return; }
        rigidBody2D.linearVelocity = new Vector2(_xvelocity, _yvelocity);
        FlipController(_xvelocity);
    }
    #endregion
    #region Flip
    public virtual void Flip()
    {
        transform.Rotate(0, 180, 0);
        facingRight = !facingRight;
        facingDir = facingDir * -1;
    }

    public virtual void FlipController(float xVelocity)
    {
          if (xVelocity > 0 && !facingRight)
        {
            Flip();

        }
        else if (xVelocity < 0 && facingRight)
        {
             Flip();
        }
    }
    #endregion

    #region Collision
    //public virtual bool isGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    //public virtual bool isWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance, whatIsGround);

    private void HandleCollisionDetection()
    {
        groundDetected = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
        wallDetected = Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance, whatIsGround);
                  //  && Physics2D.Raycast(secondaryWallCheck.position, Vector2.right * facingDir, wallCheckDistance, whatIsGround);
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + new Vector3(wallCheckDistance * facingDir, 0));

       // Gizmos.DrawLine(wallCheck.position, new Vector3( wallCheckDistance * facingDir, wallCheck.position.y)); //wallCheck.position.x +
        Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius);
    }
    #endregion

}
