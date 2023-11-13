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
        
        private MainPlayerUI mainPlayerUI;
        private Transform _transform;
        private Animator _animator;
        private float _currentDelaySwordAttack;
        private float _currentTimerToCombo;
        private int _currentCombo;
     
        private readonly int _attack1 = Animator.StringToHash("Attack1");
        private readonly int _attack2 = Animator.StringToHash("Attack2");

        [Inject]
        private void Construct(MainPlayerUI mainPlayerUI)
        {
            this.mainPlayerUI = mainPlayerUI;
        }
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _transform = GetComponent<Transform>();
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
            fireball.SetDirection(_transform.localScale.x > 0 ? Vector2.right : Vector2.left);
            mainPlayerUI.StartCooldDown(fireball.CoolDown);
        }
        
        public void SwordAttack()
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
        }
    }
}