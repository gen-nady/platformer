using UnityEngine;

namespace ObjectToQuest.KillNPC
{
    public class BeeEnemy : Enemy
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _rangeSpeed;
        [SerializeField] private float _amplitude;
        [SerializeField] private float _frequency;
        [SerializeField] private float _attackRange;
        [SerializeField] private LayerMask _layer;
        private readonly float _dontHeighAttack = 1.5f;
        private Transform _targetTransform;
        private Vector3 _startPos;
        private float _startTime;

        protected void OnEnable()
        {
            _startPos = transform.position;
            _startTime = Time.time;
        }
        
        public override void AttackHero()
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
                    _targetTransform = playerCollider.GetComponent<Transform>();
                if(Mathf.Abs(_targetTransform.position.y - transform.position.y) < _dontHeighAttack)
                    Attack();
                else
                    Move();
            }
            else
            {
                _targetTransform = null;
                Move();
            }
        }
        
        private void Move()
        {
            var xOffset = Mathf.Sin((Time.time - _startTime) * _frequency) * _amplitude;
            transform.position = _startPos + new Vector3(xOffset, 0f, 0f);
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
        }

        private void Attack()
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetTransform.position, _rangeSpeed * Time.deltaTime);;
        }
    }
}