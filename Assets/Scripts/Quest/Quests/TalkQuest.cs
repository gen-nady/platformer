using UnityEngine;

namespace Quest
{
    [CreateAssetMenu(fileName = "New Talk Quest", menuName = "Quest System/Talk Quest")]
    public class TalkQuest : Quest
    {
        public string npcToTalk;

        public void NpcTalked(string npcName)
        {
            if (!_isComplete && npcName == npcToTalk)
            {
                _isComplete = true;
            }
        }
        
        public override string CurrentTextProgress()
        {
            return _isComplete ?  $"Вы получили мудрую информацию от {npcToTalk}!" : $"Поговорите с  {npcToTalk}!";
        }
        
        public override void Reset()
        {
            _isComplete = false;
        }
    }
}