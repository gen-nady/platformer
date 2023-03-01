using Quest.EnemiesObjects;
using UnityEngine;

namespace Quest
{
    [CreateAssetMenu(fileName = "Quests", menuName = "Quests/Quest", order = 0)]
    public class QuestToKill : Quest
    {
        [SerializeField] private Enemy _typeKill;
        [SerializeField] private string _localizedMaimEnemy;
        [SerializeField] private int _countToKill;
        [SerializeField] private int _currentToKill = 0;
        private const string Kill = "Убито";

        public override void ChangeProgressQuest<TypeKill>()
        {
            if (_typeKill is TypeKill)
            {
                _currentToKill++;
            }
        }

        public override bool IsCompleteQuest()
        {
            return _countToKill == _currentToKill;
        }

        public override string CurrentProgress()
        {
            return IsCompleteQuest() 
                ? CanPassQuest 
                : $"{Kill} {_localizedMaimEnemy} {_currentToKill} {From} {_countToKill}";
        }

        public override void Reset()
        {
            _currentToKill = 0;
        }
    }
}