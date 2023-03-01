﻿using Quest.FoundObjects;
using UnityEngine;

namespace Quest
{
    [CreateAssetMenu(fileName = "QuestsFind", menuName = "Quests/QuestFind", order = 1)]
    public class QuestToFindObject : Quest
    {
        [SerializeField] private Found _typePickUp;
        [SerializeField] private string _localizedName;
        [SerializeField] private int _countFind;
        [SerializeField] private int _currentFind = 0;
        private const string Collected = "Собрано";

        public override void ChangeProgressQuest<TypePickUp>()
        {
            if (_typePickUp is TypePickUp)
            {
                _currentFind++;
            }
        }

        public override bool IsCompleteQuest()
        {
            return _currentFind == _countFind;
        }

        public override string CurrentProgress()
        {
            return IsCompleteQuest() 
                ? CanPassQuest
                : $"{Collected} {_localizedName} {_currentFind} {From} {_countFind}";
        }

        public override void Reset()
        {
            _currentFind = 0;
        }
    }
}