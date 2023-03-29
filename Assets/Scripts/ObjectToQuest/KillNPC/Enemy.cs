using Quest;
using UnityEngine;
using Zenject;

namespace ObjectToQuest.KillNPC
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected string _idName;
        [Inject] protected PlayerQuest _playerQuest;

        private void Awake()
        {
            QuestGiver.AddQuestToPlayer += KillEnemy;
            gameObject.SetActive(false);
        }
   
        private void OnDestroy()
        {
            QuestGiver.AddQuestToPlayer -= KillEnemy;
        }

        private void KillEnemy(Quest.Quest quest)
        {
            if(quest.Id == _idName)
                gameObject.SetActive(true);
        }
    }
}