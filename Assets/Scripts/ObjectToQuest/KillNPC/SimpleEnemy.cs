using ObjectToQuest.KillNPC;
using UnityEngine;

namespace Hero.Attack
{
    //пока так. Потом как продумается реализация других врагов, исправить
    public class SimpleEnemy : Enemy
    {
        [SerializeField] private int _lifePoints;
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent<Attack>(out var attack))
            {
                _lifePoints -= attack.Damage;
                if(attack is FireballAttack)
                    Destroy(attack.gameObject);
                if (_lifePoints <= 0)
                {
                    _playerQuest.EnemyKilled(_idName);
                    gameObject.SetActive(false);
                }
               
            }
        }
    }
}