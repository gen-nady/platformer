using UnityEngine;

namespace Quest
{
    [CreateAssetMenu(fileName = "New Kill Quest", menuName = "Quest System/Kill Quest")]
    public class KillQuest : Quest
    {
        [SerializeField] private string _enemyName;
        [SerializeField] private int _enemiesToKill;

        public void EnemyKilled(string enemyName)
        {
            if (!_isComplete && enemyName == this._enemyName)
            {
                _enemiesToKill++;

                if (_enemiesToKill == _questTarget)
                {
                    _isComplete = true;
                }
            }
        }

        public override string CurrentTextProgress()
        {
            return $"Убито {_enemiesToKill} из {_questTarget}";
        }
    }
}