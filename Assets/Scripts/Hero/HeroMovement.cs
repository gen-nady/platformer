using Infastructure;
using Services.Input;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private IInputService _inputService;
    private const float groundRadius = 0.2f;

    private void Awake()
    {
       
    }

    void Start()
    {
         _inputService = Game.InputService;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isGrounded)
        {
            rb.velocity =new Vector2(rb.velocity.x,_inputService.Jump(jumpForce) == 0f ? rb.velocity.y : _inputService.Jump(jumpForce));          
        }
    }

    void FixedUpdate()
    {
        var moveVector = _inputService.Axis;
        rb.velocity = new Vector2(moveVector * moveSpeed, rb.velocity.y);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }
    
    private bool isGrounded => Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
}
