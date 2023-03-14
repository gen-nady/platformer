using UnityEngine;

namespace Quest
{
    [CreateAssetMenu(fileName = "New Kill Quest", menuName = "Quest System/Kill Quest")]
    public class KillQuest : Quest
    {
        public string enemyName;
        public int enemiesToKill;

        public void EnemyKilled(string enemyName)
        {
            if (!isComplete && enemyName == this.enemyName)
            {
                questTarget--;

                if (questTarget <= 0)
                {
                    isComplete = true;
                }
            }
        }
    }
}