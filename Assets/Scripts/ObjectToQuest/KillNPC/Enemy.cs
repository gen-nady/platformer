using Quest;
using UnityEngine;
using Zenject;

namespace ObjectToQuest.KillNPC
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected string _idName;
        protected PlayerQuest _playerQuest;

        [Inject]
        private void Construct(PlayerQuest playerQuest)
        {
            _playerQuest = playerQuest;
        }
        
        private void Awake()
        {
            QuestGiver.AddQuestToPlayer += KillEnemy;
            gameObject.SetActive(false);
        }
   
        private void OnDestroy()
        {
            QuestGiver.AddQuestToPlayer -= KillEnemy;
        }

        private void KillEnemy(Quest.Quest quest)
        {
            if(quest.Id == _idName)
                gameObject.SetActive(true);
        }
    }
}