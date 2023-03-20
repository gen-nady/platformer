using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Quest
{
    public abstract class Quest : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private string _title;
        [SerializeField] private string _discription;
        [SerializeField] private int _gold;
        [SerializeField] private int _expirience;
        [SerializeField] private List<string> _prevIdQuest = new List<string>();
        [SerializeField] protected string _nameTarget;
        [SerializeField] protected int _targetCount;
        protected bool _isComplete;
        public List<string> PrevIdQuest => _prevIdQuest;
        public bool IsCompleted => _isComplete;
        public string Id => _id;
        public string Title => _title;
        public string Discription => _discription;
        
        public abstract void Reset();

        public abstract string CurrentTextProgress();
        
        private void OnValidate()
        {
            if (Application.isPlaying)
                return;

            if (string.IsNullOrEmpty(_id))
                _id = System.Guid.NewGuid().ToString();
        }

        public (int, int) GetBonusesForQuest()
        {
            return (_gold, _expirience);
        }
        
        public string ShowBonusesText()
        {
           return $"Золото х{_gold} \n Опыт х{_expirience}";
        }
    }
}