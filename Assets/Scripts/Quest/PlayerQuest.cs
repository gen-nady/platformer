using System.Collections.Generic;
using System.Linq;
using Hero;
using UnityEngine;
using Zenject;

namespace Quest
{
    public class PlayerQuest : MonoBehaviour
    {
        private List<Quest> _quests = new List<Quest>();
        private List<string> _complitedQuests = new List<string>();
        [Inject] private PlayerQuestUI _playerQuestUI;
        
        private void OnEnable()
        {
            QuestGiver.AddQuestToPlayer += AddQuest;
            QuestGiver.QuestCompleted += QuestComplited;
        }

        private void OnDestroy()
        {
            QuestGiver.AddQuestToPlayer -= AddQuest;
            QuestGiver.QuestCompleted -= QuestComplited;
        }

        public bool CheckForQuest(List<string> needQuest)
        {
            return needQuest.All(item => _complitedQuests.Contains(item));
        }
        
        private void AddQuest(Quest quest)
        {
            _quests.Add(quest);
        }

        public bool IsThereQuest(Quest quest)
            => _quests.Any(_ => _.Equals(quest));
        
        private void KillEnemy(string enemyName)
        {
            foreach (var killQuest in _quests.OfType<KillQuest>())
            {
                killQuest.EnemyKilled(enemyName);
            }
        }

        private void FindObject(string objectFind)
        {
            foreach (var searchQuest in _quests.OfType<SearchQuest>())
            {
                searchQuest.ObjectFound(objectFind);
            }
        }

        private void TalkNpc(string npcName)
        {
            foreach (var talkQuest in _quests.OfType<TalkQuest>())
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
            foreach (var quest in _quests)
            {
                _playerQuestUI.ChangeProgress(quest);
            }
        }
        
        private void QuestComplited(Quest quest)
        {
            _complitedQuests.Add(quest.Id);
            _quests.Remove(quest);
            (HeroData.Money, HeroData.XP) = quest.GetBonusesForQuest();
        }
    }
}