using UnityEngine;

namespace Quest
{
    [CreateAssetMenu(fileName = "New Search Quest", menuName = "Quest System/Search Quest")]
    public class SearchQuest : Quest
    {
        private int _currentCount;

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
        
        public void ObjectFound(string findObjectName)
        {
            if (!_isComplete && findObjectName == Id)
            {
                _currentCount++;
                if (_currentCount == _targetCount)
                {
                    _isComplete = true;
                }
            }
        }
        
        public override string CurrentTextProgress()
        {
            return _isComplete ?  $"Предметы {_nameTarget} найдены!" : $"Найдено {_nameTarget} {_currentCount} из {_targetCount}";
        }
        
        public override void Reset()
        {
            _currentCount = 0;
            _isComplete = false;
        }
    }
}