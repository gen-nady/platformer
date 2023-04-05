using Quest;
using UnityEngine;
using Zenject;

namespace ObjectToQuest
{
    public abstract class PickUpItem : MonoBehaviour
    {
        [SerializeField] protected string _idName;
        protected PlayerQuest _playerQuest;
        
        [Inject]
        private void Construct(PlayerQuest playerQuest)
        {
            _playerQuest = playerQuest;
        }
        
        private void OnEnable()
        {
            QuestGiver.AddQuestToPlayer += EnableItem;
            gameObject.SetActive(_playerQuest.IsShowQuestObject(_idName));
        }
        
        private void OnDestroy()
        {
            QuestGiver.AddQuestToPlayer -= EnableItem;
        }
        
        private void EnableItem(Quest.Quest quest)
        {
            if(quest.Id == _idName)
                gameObject.SetActive(true);
        }
        
        public abstract void PickUp();
    }
}