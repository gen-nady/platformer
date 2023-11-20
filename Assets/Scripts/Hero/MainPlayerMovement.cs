using System;
using Infastructure;
using Services.Input;
using UnityEngine;

public class MainPlayerMovement : MonoBehaviour
{
    public static event Action<bool> OnLadderState;
    
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 10f;

    private bool _isLadder;
    
    private Animator _animator;
    private Rigidbody2D _rb;
    private IInputService _inputService;
    private const float GroundRadius = 0.2f;
    private bool _isIdle;
    
    private readonly Vector3 _rightScale = new Vector3(5, 5, 1);
    private readonly Vector3 _leftScale = new Vector3(-5, 5, 1);
    private readonly int _speed = Animator.StringToHash("Speed");
    private readonly int _attack1 = Animator.StringToHash("Attack1");
    private readonly int _attack2 = Animator.StringToHash("Attack2");
    
    #region MONO
    private void Start()
    {
        _inputService = Game.InputService;
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space) && !_isLadder)
            Jump();
    }

    private void FixedUpdate()
    {
        Movement();
        if (_isLadder)
        {
            MovementLadder();
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_groundCheck.position, GroundRadius);
    }
    #endregion

    private void Movement()
    {
        var moveVector = _inputService.HorizontalAxis;
        Debug.Log(moveVector);
        _animator.SetFloat(_speed, Mathf.Abs(moveVector));
        _rb.velocity = new Vector2(moveVector * _moveSpeed, _rb.velocity.y);
        if (moveVector > 0)
        {
            if(transform.localScale.x < 0)
                transform.localScale = _rightScale;
            _isIdle = false;
        }
        else if (moveVector < 0)
        {
            if(transform.localScale.x > 0)
                transform.localScale = _leftScale;
            _isIdle = false;
        }
        else if (!_isIdle)
        {
            _isIdle = true;
        }
    }
    
    public void Jump()
    {
        if (isGrounded)
        {
            _animator.ResetTrigger(_attack1);
            _animator.ResetTrigger(_attack2);
            _rb.velocity = new Vector2(_rb.velocity.x,0f);
            _rb.velocity = new Vector2(_rb.velocity.x,_jumpForce);
        }
    }
    
    private bool isGrounded => Physics2D.OverlapCircle(_groundCheck.position, GroundRadius, _groundLayer);

    public void SetLadder(bool isLadder)
    {
        _isLadder = isLadder;
        OnLadderState?.Invoke(_isLadder);
    }
    
    private void MovementLadder()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, 0.85f);
        var moveVector = _inputService.VerticalAxis;
        if (moveVector != 0)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, moveVector * _moveSpeed);
        }
    }
}
