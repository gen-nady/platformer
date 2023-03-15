using PickUpObject;
using UnityEngine;

namespace Quest
{
    [CreateAssetMenu(fileName = "New Search Quest", menuName = "Quest System/Search Quest")]
    public class SearchQuest : Quest
    {
        [SerializeField] private string _objectToFind;
        [SerializeField] private string _objectName;
        public void ObjectFound(string findObjectName)
        {
            if (!_isComplete && findObjectName == _objectToFind)
            {
                _isComplete = true;
            }
        }
        
        public override string CurrentTextProgress()
        {
            return _isComplete ?  $"Предмет {_objectName} найден!" : $"Найдите {_objectName}";
        }
    }
}