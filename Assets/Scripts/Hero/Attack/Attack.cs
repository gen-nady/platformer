using UnityEngine;

namespace Hero.Attack
{
    //пока так. Потом как продумается реализация других атак, исправить. Мб через стратегию
    public class Attack : MonoBehaviour
    {
        [SerializeField] protected Transform _transform;
        [SerializeField] protected int _damage;
        public int Damage => _damage;
    }
}