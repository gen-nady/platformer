using System;
using System.Threading.Tasks;
using Hero.Attack;
using UnityEngine;
using Zenject;

namespace Hero
{
    //пока так. Потом как продумается реализация других атак, исправить. Мб через стратегию
    public class HeroAttack : MonoBehaviour
    {
        [SerializeField] private FireballAttack _fireball;
        [SerializeField] private int _orderInLayer;
        [SerializeField] private float _timerToCombo;
        [SerializeField] private float _delaySwordAttack;
        [SerializeField] private float _powerCombo;
        [Inject] private HeroAttackUI _heroAttackUI;
        
        private float _currentDelaySwordAttack;
        private float _currentTimerToCombo;
        private int _currentCombo;
        private SpriteRenderer _spriteRenderer;
        private Animator _animator;
        private Rigidbody2D _rigibody;
        private readonly int _attack1 = Animator.StringToHash("Attack1");
        private readonly int _attack2 = Animator.StringToHash("Attack2");
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _rigibody = GetComponent<Rigidbody2D>();
            _orderInLayer *= -1;
            _currentTimerToCombo = 0;
            _currentCombo = 0;
        }

        private void Update()
        {
            _currentTimerToCombo -= Time.deltaTime;
            if (_currentTimerToCombo <= 0)
            {
                _currentCombo = 0;
            }
            _currentDelaySwordAttack -= Time.deltaTime;
        }

        public void FireballAttack()
        {
            var positionHero = transform.position;
            var position = new Vector3(positionHero.x, positionHero.y, _orderInLayer);
            var fireball = Instantiate(_fireball, position, Quaternion.identity);
            fireball.SetDirection(_spriteRenderer.flipX ? Vector2.left : Vector2.right);
            _heroAttackUI.StartCooldDown(fireball.CoolDown);
        }
        
        public async void SwordAttack()
        {
            if (_currentDelaySwordAttack > 0 && _currentCombo > 0) return;
            _currentDelaySwordAttack = _delaySwordAttack;
            _currentTimerToCombo = _timerToCombo;
            if (_currentCombo == 0)
            {
                _animator.SetTrigger(_attack1);
                _currentCombo++;
            }
            else if (_currentCombo == 1)
            {
                _animator.SetTrigger(_attack2);
                _currentCombo = 0;
            }
            // else if (_currentCombo == 2)
            // {
            //     _currentCombo = 0;
            //     _currentTimerToCombo = _timerToCombo;
            //     _rigibody.AddForce(new Vector2(transform.localScale.x * _powerCombo,0), ForceMode2D.Force);
            //     await Task.Delay(500);
            //     _rigibody.velocity = new Vector2(0f, _rigibody.velocity.y);
            // }
        }
    }
}