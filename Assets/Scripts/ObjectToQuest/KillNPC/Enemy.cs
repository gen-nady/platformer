using Hero;
using Hero.Attack;
using Quest;
using UnityEngine;
using Zenject;

namespace ObjectToQuest.KillNPC
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] private bool _isExistQuest;
        [SerializeField] protected string _idName;
        [SerializeField] private int _lifePoints;
        [SerializeField] private float _attackHealth;
        protected PlayerQuest _playerQuest;

        [Inject]
        private void Construct(PlayerQuest playerQuest)
        {
            _playerQuest = playerQuest;
        }

        #region MONO
        private void Awake()
        {
            if (_isExistQuest)
            {
                QuestGiver.AddQuestToPlayer += KillEnemy;
                gameObject.SetActive(_playerQuest.IsShowQuestObject(_idName)); 
            }
        }
   
        private void OnDestroy()
        {
            if (_isExistQuest)
            {
                QuestGiver.AddQuestToPlayer -= KillEnemy;
            }
        }

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
        #endregion        
          
        public abstract void AttackHero();
        
        private void KillEnemy(Quest.Quest quest)
        {
            if(quest.Id == _idName)
                gameObject.SetActive(true);
        }
    }
}