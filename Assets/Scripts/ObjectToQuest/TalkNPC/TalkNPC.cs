using Quest;
using UnityEngine;
using Zenject;

namespace ObjectToQuest
{
    public abstract class TalkNPC : MonoBehaviour
    {
        [SerializeField] protected string _idName;
        protected PlayerQuest _playerQuest;

        [Inject]
        private void Construct(PlayerQuest playerQuest)
        {
            _playerQuest = playerQuest;
        }
        
        public abstract void Talk();
    }
}