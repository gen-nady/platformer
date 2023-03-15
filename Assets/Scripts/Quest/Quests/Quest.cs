using UnityEngine;

namespace Quest
{
    [CreateAssetMenu(fileName = "New Quest", menuName = "Quest System/Quest")]
    public abstract class Quest : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private string _questTitle;
        [SerializeField] private string _questDescription;
        [SerializeField] protected int _questTarget;
        [SerializeField] private int _gold;
        [SerializeField] private int _expirience;
        [SerializeField] protected bool _isComplete;
        public bool IsCompleted => _isComplete;
        public string Id => _id;
        public string QuestTitle => _questTitle;
        public string QuestDescription => _questDescription;
        public abstract string CurrentTextProgress();

        public string ShowBonusesText()
        {
           return $"Золото х{_gold} \n Опыт х{_expirience}";
        }
    }
}