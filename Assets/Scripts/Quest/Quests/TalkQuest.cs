using UnityEngine;

namespace Quest
{
    [CreateAssetMenu(fileName = "New Talk Quest", menuName = "Quest System/Talk Quest")]
    public class TalkQuest : Quest
    {
        [SerializeField] private string npcText;
        #region MONO
        private void OnEnable()
        {
            Reset();
        }

        private void OnDisable()
        {
            Reset();
        }
        #endregion
        
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
        
        public override void Reset()
        {
            _isComplete = false;
            _targetCount = 0;
        }
    }
}