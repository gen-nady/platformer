using System;
using InventorySystem;
using InventorySystem.Objects;
using Quest;
using UnityEngine;
using WorldItem;
using Zenject;

namespace ObjectToQuest
{
    public abstract class PickUpItem : MonoBehaviour
    {
        [SerializeField] protected string _idName;
        [SerializeField] protected InventoryItemInfo info;
        public InventoryItem item { get; protected set; }
        protected PlayerQuest _playerQuest;
        
        
        [Inject]
        private void Construct(PlayerQuest playerQuest)
        {
            _playerQuest = playerQuest;
        }

        protected virtual void OnEnable()
        {
            if(_idName == string.Empty) return;
            QuestGiver.AddQuestToPlayer += EnableItem;
            gameObject.SetActive(_playerQuest.IsShowQuestObject(_idName));
        }
        
        protected virtual void OnDestroy()
        {
            if(_idName == string.Empty) return;
            QuestGiver.AddQuestToPlayer -= EnableItem;
        }
        
        protected void EnableItem(Quest.Quest quest)
        {
            if(quest.Id == _idName)
                gameObject.SetActive(true);
        }

        public abstract void PickUp();
    }
}