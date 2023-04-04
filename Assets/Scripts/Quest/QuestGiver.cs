using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Quest
{
    public class QuestGiver : MonoBehaviour
    {
        public static event Action<Quest> AddQuestToPlayer;
        public static event Action<Quest> QuestCompleted;
        [SerializeField] private List<Quest> _quests;
        [SerializeField] private GameObject _activeQuestPanel;
        private bool _isActiveQuest;
        private bool _isAllQuest;
        [Inject] private QuestGiverUI _questGiverUI;
        [Inject] private PlayerQuest _playerQuest;

        private void OnEnable()
        {
            if (_quests.Count > 0)
            {
                var isActiveQuest = _playerQuest.IsQuestExist(_quests[0].Id);
                _activeQuestPanel.SetActive(isActiveQuest);
                _isActiveQuest = isActiveQuest;
            }
        }

        private void AddQusetToPlayer()
        {
            AddQuestToPlayer?.Invoke(_quests[0]);
            _activeQuestPanel.SetActive(true);
            _isActiveQuest = true;
        }
        
        private void GetBonusesForQuest()
        {
            QuestCompleted?.Invoke(_quests[0]);
            _activeQuestPanel.SetActive(false);
            CheckForActiveQuest(_quests[0]);
        }

        private void CheckForActiveQuest(Quest quest)
        {
            _quests.Remove(quest);
            if (_quests.Count > 0)
            {
                if(quest is TalkQuest) return;
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

        public void CompletedTalkQuest()
        {
            if (_isActiveQuest && _playerQuest.IsQuestExist(_quests[0].Id) && _quests[0].IsCompleted)
            {
                _questGiverUI.CompletedQuest(_quests[0],GetBonusesForQuest);
            }
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(_isAllQuest) return;
            if (other.GetComponent<MainPlayerMovement>())
            {
                if (_isActiveQuest)
                {
                    if (_playerQuest.IsQuestExist(_quests[0].Id) && _quests[0].IsCompleted)
                    {
                        _questGiverUI.CompletedQuest(_quests[0],GetBonusesForQuest);
                    }
                }
                else if (_quests.Count > 0 && _playerQuest.IsCompletedQuest(_quests[0].PrevIdQuest))
                {
                    (_quests[0] as TalkQuest)?.SetQuestGiver(this);
                    _questGiverUI.SetQuestText(_quests[0], AddQusetToPlayer);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.GetComponent<MainPlayerMovement>())
            {
                _questGiverUI.CloseQuestPanel();
                _questGiverUI.CloseBonusesPanel();
            }
        }
    }
}