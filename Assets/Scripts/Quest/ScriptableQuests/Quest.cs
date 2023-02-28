using UnityEngine;

namespace Quest
{
    public abstract class Quest : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private int _idQuest;
        [SerializeField] private string _name;
        [SerializeField] private string _discription;
        [SerializeField] private int _expirience;
        [SerializeField] private int _gold;
        protected const string CanPassQuest= "Можете сдать квест!";
        protected const string From= "из";
        public string Name => _name;
        public string Discription => _discription;
        public int Expirience => _expirience;
        public int Gold => _gold;
        public abstract void ChangeProgressQuest<T>();
        public abstract bool IsCompleteQuest();
        public abstract string CurrentProgress();
        public abstract void Reset();
        private void OnEnable() => Reset();
    }
}