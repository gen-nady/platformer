using UnityEngine;
using Zenject;

namespace Quest
{
    public class CurrentQuests : MonoBehaviour
    {
        private Quest _playerQuest;
        [Inject] private CurrentQuestUI _playerQuestUI;
        
        public Quest CurrentQuestPlayer => _playerQuest;

        #region MONO
        private void OnEnable()
        {
            GiverQuests.AddQuestToPlayer += SetQuest;
            GiverQuests.QuestCompleted += GetBonuses;
        }

        private void OnDestroy()
        {
            GiverQuests.AddQuestToPlayer -= SetQuest;
            GiverQuests.QuestCompleted -= GetBonuses;
        }
        #endregion

        public void DeadEnemy<TypeDead>()
        {
            if (_playerQuest != null)
            {
                _playerQuest.ChangeProgressQuest<TypeDead>();
                _playerQuestUI.ChangeProgress(_playerQuest);
            }
        }
        
        public void PickUp<FindObject>()
        {
            if (_playerQuest != null)
            {
                _playerQuest.ChangeProgressQuest<FindObject>();
                _playerQuestUI.ChangeProgress(_playerQuest);
            }
        }

        private void GetBonuses(Quest quest)
        {
            Debug.Log($"Получено опыта: {quest.Expirience}");
            Debug.Log($"Получено золота: {quest.Gold}");
        }
        private void SetQuest(Quest quest)
        {
            _playerQuest = quest;
        }
    }
}