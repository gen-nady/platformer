using System;
using System.Collections.Generic;
using DG.Tweening;
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
        //private readonly int _walk = Animator.StringToHash("Walk");
 
        private void AddQusetToPlayer()
        {
            AddQuestToPlayer?.Invoke(_quests[0]);
            _isActiveQuest = true;
        }
        
        private void GetBonusesForQuest()
        {
            QuestCompleted?.Invoke(_quests[0]);
            _quests.RemoveAt(0);
            if (_quests.Count > 0)
            {
                _questGiverUI.SetQuestText(_quests[0], AddQusetToPlayer);
                _isActiveQuest = false;
                return;
            }
            _isAllQuest = true;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(_isAllQuest) return;
            if (other.GetComponent<MainPlayerMovement>())
            {
                if (_isActiveQuest)
                {
                    if (_playerQuest.IsThereQuest(_quests[0]))
                    {
                        if (_quests[0].IsCompleted)
                        {
                            _questGiverUI.CompletedQuest(_quests[0],GetBonusesForQuest);
                        }
                    }
                }
                else
                {
                    _questGiverUI.SetQuestText(_quests[0], AddQusetToPlayer);
                }
            }
        }
    }
}