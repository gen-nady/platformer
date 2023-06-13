using Enemy.Interface;
using Enemy.Movable;
using UnityEngine;

namespace ObjectToQuest.KillNPC
{
    public class BeeEnemy : Enemy
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _rangeSpeed;
        [SerializeField] private float _attackRange;
        [SerializeField] private LayerMask _layer;
        private readonly float _dontHeighAttack = 1.5f;
        private Transform _targetTransform;
        private IMovable _move;

        protected void OnEnable()
        {
            _move = new FlyingIdleMove(transform);
        }
        
        public override void TakeDamage()
        {
            Debug.Log("Lower Helth");
            gameObject.SetActive(false);
        }
        
        private void Update()
        {
            var playerCollider = Physics2D.OverlapCircle(transform.position, _attackRange, _layer);
            if (Physics2D.OverlapCircle(transform.position, _attackRange,_layer))
            {
                if (_targetTransform == null)
                {
                    _targetTransform = playerCollider.GetComponent<Transform>();
                }
                if (Mathf.Abs(_targetTransform.position.y - transform.position.y) < _dontHeighAttack)
                {
                    if (_move is not FlyingRangeMove)
                    {
                        _move = new FlyingRangeMove(transform, _targetTransform);
                    }
                    _move.Move(_rangeSpeed);
                }
                else
                {
                    _move.Move(_speed);
                }
            }
            else
            {
                _targetTransform = null;
                _move.Move(_speed);
            }
        }
    }
}