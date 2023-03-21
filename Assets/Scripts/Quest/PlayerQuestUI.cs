using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Quest
{
    public class PlayerQuestUI : MonoBehaviour
    {
        [SerializeField] private PlayerQuestPrefab _playerQuestPrefab;
        [SerializeField] private RectTransform _intantiatePosition;
        private List<PlayerQuestPrefab> _playerQuest = new List<PlayerQuestPrefab>();
        
        private void OnEnable()
        {
            QuestGiver.AddQuestToPlayer += SetInfoOrQuest;
            QuestGiver.QuestCompleted += ResetQuest;
        }

        private void OnDestroy()
        {
            QuestGiver.AddQuestToPlayer -= SetInfoOrQuest;
            QuestGiver.QuestCompleted -= ResetQuest;
        }
        
        public void ChangeProgress(Quest quest)
        {
             _playerQuest.FirstOrDefault(_ => _.IdQuest == quest.Id)!.ChangeProgress(quest);
        }
        private void SetInfoOrQuest(Quest quest)
        {
            var questPrefab = Instantiate(_playerQuestPrefab, _intantiatePosition);
            _playerQuest.Add(questPrefab);
            questPrefab.SetValue(quest);
        }
        private void ResetQuest(Quest quest)
        {
            var curQuest = _playerQuest.FirstOrDefault(_ => _.IdQuest == quest.Id)!;
            Destroy(curQuest.gameObject);
            _playerQuest.Remove(curQuest);
        }
    }
}