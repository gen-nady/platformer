using Infastructure;
using Services.Input;
using UnityEngine;

public class MainPlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private IInputService _inputService;
    private const float groundRadius = 0.2f;

    #region MONO
    private void Awake()
    {
        _inputService = Game.InputService;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Movement();
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }
    #endregion
    
    private void Movement()
    {
        var moveVector = _inputService.Axis;
        rb.velocity = new Vector2(moveVector * moveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.velocity =new Vector2(rb.velocity.x,_inputService.Jump(jumpForce) == 0f ? rb.velocity.y : _inputService.Jump(jumpForce));          
        }
    }
    
    private bool isGrounded => Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
}
