using System;
using UnityEngine;

namespace Quest
{
    [CreateAssetMenu(fileName = "New Search Quest", menuName = "Quest System/Search Quest")]
    public class SearchQuest : Quest
    {
        [SerializeField] private string _objectName;
        [SerializeField] private int _currentTarget;

        private void Awake()
        {
            Reset();
        }

        public void ObjectFound(string findObjectName)
        {
            if (!_isComplete && findObjectName == Id)
            {
                _currentTarget++;
                if (_currentTarget == _questTarget)
                {
                    _isComplete = true;
                }
            }
        }
        
        public override string CurrentTextProgress()
        {
            return _isComplete ?  $"Предметы {_objectName} найдены!" : $"Найдено {_objectName} {_currentTarget} из {_questTarget}";
        }

        public void Reset()
        {
            _currentTarget = 0;
            _isComplete = false;
        }
    }
}