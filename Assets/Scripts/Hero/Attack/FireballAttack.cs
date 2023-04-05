using OtherItem;
using UnityEngine;

namespace Hero.Attack
{
    //пока так. Потом как продумается реализация других атак, исправить. Мб через стратегию
    public class FireballAttack : Attack
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private float _coolDown;
        [SerializeField] private float _timeToDestroy;
        [SerializeField] private int _speed;
       
        private Vector2 _direction;
        
        private void OnEnable()
        {
            Destroy(gameObject,_timeToDestroy);
        }

        private void Update()
        {
            _transform.Translate(_direction * (_speed * Time.deltaTime));
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.GetComponent<Wall>())
            {
                Destroy(gameObject);
            }
        }

        public float CoolDown => _coolDown;
        
        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }
    }
}