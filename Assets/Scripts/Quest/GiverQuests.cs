using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Quest
{
    public class GiverQuests : MonoBehaviour
    {
        public static event Action<Quest> AddQuestToPlayer;
        public static event Action<Quest> QuestCompleted;
        [SerializeField] private List<Quest> _quests;
        [SerializeField] private MeshRenderer _activeQuest;
        private Sequence _questAnim;
        private bool _isActiveQuest;
        private bool _isAllQuest;
        [Inject] private GiverQuestUI _questGiverUI;
        [Inject] private CurrentQuests _playerQuest;

        #region MONO
        private void Awake()
        {
            _questAnim = DOTween.Sequence()
                .Append(_activeQuest.transform.DOScale(new Vector3(1f, 1f, 1f), 2f))
                .Append(_activeQuest.transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f) , 2f))
                .SetLoops(-1);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(_isAllQuest) return;
            if (other.GetComponent<MainPlayerMovement>())
            {
                if (_isActiveQuest)
                {
                    var quest = _playerQuest.CurrentQuestPlayer;
                    if (_quests[0].Equals(quest))
                    {
                        if (quest.IsCompleteQuest())
                        {
                            _questGiverUI.CompletedQuest(quest,GetBonusesForQuest);
                        }
                    }
                }
                else
                {
                    _questGiverUI.SetQuestText(_quests[0], AddQusetToPlayer);
                }
            }
        }
        #endregion
        
        private void AddQusetToPlayer()
        {
            AddQuestToPlayer?.Invoke(_quests[0]);
            _isActiveQuest = true;
            _activeQuest.material.color = Color.red;
        }
        
        private void GetBonusesForQuest()
        {
            QuestCompleted?.Invoke(_quests[0]);
            _quests.RemoveAt(0);
            if (_quests.Count > 0)
            {
                _questGiverUI.SetQuestText(_quests[0], AddQusetToPlayer);
                _activeQuest.material.color = Color.white;
                _isActiveQuest = false;
                return;
            }
            _questAnim.Kill();
            _activeQuest.gameObject.SetActive(false);
            _isAllQuest = true;
        }
    }
}