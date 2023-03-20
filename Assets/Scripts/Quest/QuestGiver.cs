using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Quest
{
    public class QuestGiver : MonoBehaviour
    {
        public static event Action<Quest> AddQuestToPlayer;
        public static event Action<Quest> QuestCompleted;
        [SerializeField] private List<Quest> _quests;
        private bool _isActiveQuest;
        private bool _isAllQuest;
        [Inject] private QuestGiverUI _questGiverUI;
        [Inject] private PlayerQuest _playerQuest;
        
        private void AddQusetToPlayer()
        {
            AddQuestToPlayer?.Invoke(_quests[0]);
            _isActiveQuest = true;
        }
        
        private void GetBonusesForQuest()
        {
            QuestCompleted?.Invoke(_quests[0]);
            CheckForActiveQuest(_quests[0]);
        }

        private void CheckForActiveQuest(Quest quest)
        {
            _quests.Remove(quest);
            if (_quests.Count > 0)
            {
                if (_playerQuest.IsCompletedQuest(_quests[0].PrevIdQuest))
                {
                    _questGiverUI.SetQuestText(_quests[0], AddQusetToPlayer);
                    _isActiveQuest = false;
                    return;
                }
                return;
            }
            _isAllQuest = true;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(_isAllQuest) return;
            if (other.GetComponent<MainPlayerMovement>())
            {
                if (_isActiveQuest && _playerQuest.IsQuestExist(_quests[0]) && _quests[0].IsCompleted)
                {
                    _questGiverUI.CompletedQuest(_quests[0],GetBonusesForQuest);
                }
                else if (_quests.Count > 0 && _playerQuest.IsCompletedQuest(_quests[0].PrevIdQuest))
                {
                    _questGiverUI.SetQuestText(_quests[0], AddQusetToPlayer);
                }
            }
        }
    }
}