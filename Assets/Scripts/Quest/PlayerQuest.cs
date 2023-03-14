using System.Collections.Generic;
using System.Linq;
using PickUpObject;
using UnityEngine;

namespace Quest
{
    public class PlayerQuest : MonoBehaviour
    {
        public static PlayerQuest instance;

        private List<Quest> quests = new List<Quest>();

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void AddQuest(Quest quest)
        {
            quests.Add(quest);
        }

        private void KillEnemy(string enemyName)
        {
            foreach (var killQuest in quests.OfType<KillQuest>())
            {
                killQuest.EnemyKilled(enemyName);
            }
        }

        private void FindObject(PickUpItem objectFind)
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

        public void ObjectFound(PickUpItem objectFind)
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
                // Выдаем награду
            }
        }
    }
}