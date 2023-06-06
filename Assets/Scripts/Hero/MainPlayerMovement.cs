using Infastructure;
using Services.Input;
using UnityEngine;

public class MainPlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 10f;
 
    private Animator _animator;
    private Rigidbody2D _rb;
    private IInputService _inputService;
    private const float GroundRadius = 0.2f;
    private bool _isIdle;
    
    private readonly Vector3 _rightScale = new Vector3(5, 5, 1);
    private readonly Vector3 _leftScale = new Vector3(-5, 5, 1);
    private readonly int _speed = Animator.StringToHash("Speed");

    #region MONO
    private void Start()
    {
        _inputService = Game.InputService;
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
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
            Debug.Log(_rb.velocity.y);
            _isIdle = true;
        }
    }
    
    public void Jump()
    {
        if (isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x,_jumpForce);
        }
    }
    
    private bool isGrounded => Physics2D.OverlapCircle(_groundCheck.position, GroundRadius, _groundLayer);
}
