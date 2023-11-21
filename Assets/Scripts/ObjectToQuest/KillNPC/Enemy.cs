using System;
using Hero;
using Hero.Attack;
using Quest;
using UnityEngine;
using Zenject;

namespace ObjectToQuest
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected string _idName;
        [SerializeField] private int _lifePoints;
        [SerializeField] private int _attackHealth;
        private PlayerQuest _playerQuest;

        [Inject]
        private void Construct(PlayerQuest playerQuest)
        {
            _playerQuest = playerQuest;
        }

        #region MONO
        private void Awake()
        {
            if (_idName != string.Empty)
            {
                QuestGiver.AddQuestToPlayer += KillEnemy;
                gameObject.SetActive(_playerQuest.IsShowQuestObject(_idName)); 
            }
        }
   
        private void OnDestroy()
        {
            if (_idName != string.Empty)
            {
                QuestGiver.AddQuestToPlayer -= KillEnemy;
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent<Attack>(out var attack))
            {
                _lifePoints -= attack.Damage;
                if (attack is FireballAttack)
                {
                    Debug.Log("УБИЛО!!");
                    Destroy(attack.gameObject);
                }
                if (_lifePoints <= 0)
                {
                    _playerQuest.EnemyKilled(_idName);
                    gameObject.SetActive(false);
                    Debug.Log("УБИЛО!!");
                }
            }

            if (col.TryGetComponent<HealthMainPlayer>(out var health))
            {
                health.TakeDamage(_attackHealth);
            }
        }
        #endregion        
          
        public abstract void TakeDamage();
        
        private void KillEnemy(Quest.Quest quest)
        {
            if(quest.Id == _idName)
                gameObject.SetActive(true);
        }
    }
}