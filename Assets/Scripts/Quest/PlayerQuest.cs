using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Quest
{
    public class PlayerQuest : MonoBehaviour
    {
        private List<Quest> quests = new List<Quest>();
        [Inject] private PlayerQuestUI _playerQuestUI;
        
        private void Start()
        {
            QuestGiver.AddQuestToPlayer += AddQuest;
        }

        private void OnDestroy()
        {
            QuestGiver.AddQuestToPlayer -= AddQuest;
        }
        
        private void AddQuest(Quest quest)
        {
            quests.Add(quest);
        }

        public bool IsThereQuest(Quest quest)
            => quests.Any(_ => _.Equals(quest));
        
        private void KillEnemy(string enemyName)
        {
            foreach (var killQuest in quests.OfType<KillQuest>())
            {
                killQuest.EnemyKilled(enemyName);
            }
        }

        private void FindObject(string objectFind)
        {
            foreach (var searchQuest in quests.OfType<SearchQuest>())
            {
                searchQuest.ObjectFound(objectFind);
            }
        }

        private void TalkNpc(string npcName)
        {
            foreach (var talkQuest in quests.OfType<TalkQuest>())
            {
                talkQuest.NpcTalked(npcName);
            }
        }
        
        public void EnemyKilled(string enemyName)
        {
            KillEnemy(enemyName);
            CheckQuestsComplete();
        }

        public void ObjectFound(string objectFind)
        {
            FindObject(objectFind);
            CheckQuestsComplete();
        }

        public void NpcTalked(string npcName)
        {
            TalkNpc(npcName);
            CheckQuestsComplete();
        }

        private void CheckQuestsComplete()
        {
            foreach (var quest in quests.Where(quest => quest.IsCompleted))
            {
                _playerQuestUI.ChangeProgress(quest);
            }
        }
    }
}