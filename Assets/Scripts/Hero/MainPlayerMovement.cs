using Infastructure;
using Services.Input;
using UnityEngine;

public class MainPlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rb;
    private IInputService _inputService;
    private const float GroundRadius = 0.2f;
    private bool _isIdle;

    #region MONO
    private void Start()
    {
        _inputService = Game.InputService;
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
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
        if (moveVector > 0)
        {
            _spriteRenderer.flipX = false;
            _animator.ResetTrigger("Idle");
            _animator.SetTrigger("Move");
            _isIdle = false;
        }
        else if (moveVector < 0)
        {
            _spriteRenderer.flipX = true;
            _animator.ResetTrigger("Idle");
            _animator.SetTrigger("Move");
            _isIdle = false;
        }
        else
        {
            if (!_isIdle)
            {
                _animator.ResetTrigger("Move");
                _animator.SetTrigger("Idle");
                _isIdle = true;
            }
        }
    }
    
    public void Jump()
    {
        if (isGrounded)
        {
            _rb.velocity =new Vector2(_rb.velocity.x,_jumpForce);
        }
    }
    
    private bool isGrounded => Physics2D.OverlapCircle(_groundCheck.position, GroundRadius, _groundLayer);
}
