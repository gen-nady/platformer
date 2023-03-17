using UnityEngine;

namespace Quest
{
    [CreateAssetMenu(fileName = "New Kill Quest", menuName = "Quest System/Kill Quest")]
    public class KillQuest : Quest
    {
        [SerializeField] private string _enemyName;
        [SerializeField] private int _currentTarget;

        public void EnemyKilled(string enemyName)
        {
            if (!_isComplete && enemyName == _enemyName)
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
            return $"Убито {_currentTarget} из {_questTarget}";
        }
        
        public override void Reset()
        {
            _currentTarget = 0;
            _isComplete = false;
        }
    }
}