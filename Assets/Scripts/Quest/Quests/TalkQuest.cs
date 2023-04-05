using System.Collections.Generic;
using UnityEngine;

namespace Quest
{
    [CreateAssetMenu(fileName = "New Talk Quest", menuName = "Quest System/Talk Quest")]
    public class TalkQuest : Quest
    {
        [SerializeField] private List<string> _npcText = null!;
        private QuestGiver _questGiver;

        public QuestGiver QuestGiver => _questGiver;
        
        public List<string> NpcText => _npcText;
        
        public void NpcTalked(string npcId)
        {
            if (!_isComplete && npcId == Id)
            {
                _isComplete = true;
            }
        }
        
        public override string CurrentTextProgress()
        {
            return _isComplete ?  $"Вы получили мудрую информацию от {_nameTarget}!" : $"Поговорите с  {_nameTarget}!";
        }

        public override void ResetValue()
        {
            _isComplete = false;
        }

        public void SetQuestGiver(QuestGiver questGiver)
        {
            _questGiver = questGiver;
        }
    }
}