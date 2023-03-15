using Infastructure;
using Services.Input;
using UnityEngine;

public class MainPlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D _rb;
    private IInputService _inputService;
    private const float GroundRadius = 0.2f;

    #region MONO
    private void Start()
    {
         _inputService = Game.InputService;
        _rb = GetComponent<Rigidbody2D>();
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
        Gizmos.DrawWireSphere(_groundCheck.position, GroundRadius);
    }
    #endregion

    private void Movement()
    {
        var moveVector = _inputService.Axis;
        _rb.velocity = new Vector2(moveVector * _moveSpeed, _rb.velocity.y);
    }
    
    private void Jump()
    {
        if (isGrounded)
        {
            _rb.velocity =new Vector2(_rb.velocity.x,_inputService.Jump(_jumpForce) == 0f ? _rb.velocity.y : _inputService.Jump(_jumpForce));
        }
    }
    
    private bool isGrounded => Physics2D.OverlapCircle(_groundCheck.position, GroundRadius, _groundLayer);
}
