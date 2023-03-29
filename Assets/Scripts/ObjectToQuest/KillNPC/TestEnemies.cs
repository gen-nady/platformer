using ObjectToQuest.KillNPC;
using UnityEngine;

namespace Hero.Attack
{
    //пока так. Потом как продумается реализация других врагов, исправить
    public class TestEnemies : Enemy
    {
        [SerializeField] private int _lifePoints;
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent<FireballAttack>(out var fireballAttack))
            {
                _lifePoints -= fireballAttack.Damage;
                Destroy(fireballAttack.gameObject);
                if (_lifePoints <= 0)
                {
                    _playerQuest.EnemyKilled(_idName);
                    Destroy(gameObject);
                }
            }
        }
    }
}