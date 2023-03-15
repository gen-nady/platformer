﻿using TMPro;
using UnityEngine;

namespace Quest
{
    public class PlayerQuestUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currentProgressQuest;
        [SerializeField] private TextMeshProUGUI _nameQuest;
        private void Start()
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
            _currentProgressQuest.text = quest.CurrentTextProgress();
        }
        private void SetInfoOrQuest(Quest quest)
        {
            _nameQuest.text = quest.QuestTitle;
            _currentProgressQuest.text = quest.CurrentTextProgress();
        }
        private void ResetQuest(Quest quest)
        {
            _nameQuest.text = string.Empty;
            _currentProgressQuest.text = string.Empty;
        }
    }
}