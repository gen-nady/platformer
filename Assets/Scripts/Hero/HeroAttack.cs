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

        [Inject] private HeroAttackUI _heroAttackUI;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _orderInLayer *= -1;
        }

        public void FireballAttack()
        {
            var positionHero = transform.position;
            var position = new Vector3(positionHero.x, positionHero.y, _orderInLayer);
            var fireball = Instantiate(_fireball, position, Quaternion.identity);
            fireball.SetDirection(_spriteRenderer.flipX ? Vector2.left : Vector2.right);
            _heroAttackUI.StartCooldDown(fireball.CoolDown);
        }
    }
}