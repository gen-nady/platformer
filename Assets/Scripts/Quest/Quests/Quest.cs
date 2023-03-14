using UnityEngine;

namespace Quest
{
    [CreateAssetMenu(fileName = "New Quest", menuName = "Quest System/Quest")]
    public class Quest : ScriptableObject
    {
        protected string questTitle;
        protected string questDescription;
        protected int questTarget;
        protected bool isComplete;
        public bool IsCompleted => isComplete;
    }
}