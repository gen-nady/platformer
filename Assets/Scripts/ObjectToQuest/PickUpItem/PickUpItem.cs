using Quest;
using UnityEngine;
using Zenject;

namespace ObjectToQuest
{
    public abstract class PickUpItem : MonoBehaviour
    {
        [SerializeField] protected string _idName;
        [Inject] protected PlayerQuest _playerQuest;

        private void Awake()
        {
            QuestGiver.AddQuestToPlayer += EnableItem;
            gameObject.SetActive(false);
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