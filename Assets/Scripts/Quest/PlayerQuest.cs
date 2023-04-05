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
        private PlayerQuestUI _playerQuestUI;
        private TalkQuestUI _talkQuestUI;
        
        #region MONO
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
        #endregion 
        
        [Inject]
        private void Construct(PlayerQuestUI playerQuestUI, TalkQuestUI talkQuestUI)
        {
            _playerQuestUI = playerQuestUI;
            _talkQuestUI = talkQuestUI;
        }

        public bool IsCompletedQuest(string needQuest)
        {
            return _complitedQuests.Any(item => item == needQuest);
        }
        
        public bool IsCompletedQuest(List<string> needQuest)
        {
            return needQuest.All(item => _complitedQuests.Contains(item));
        }

        public bool IsShowQuestObject(string idQuest)
        {
            return _quests.Any(_ => _.Id == idQuest && !_.IsCompleted);
        }
        
        public bool IsQuestExist(string idQuest)
            => _quests.Any(_ => _.Id == idQuest);
        
        private void AddQuest(Quest quest)
        {
            _quests.Add(quest);
        }

        private void QuestComplited(Quest quest)
        {
            _complitedQuests.Add(quest.Id);
            _quests.Remove(quest);
            (HeroData.Money, HeroData.XP) = quest.GetBonusesForQuest();
        }
        
        public void EnemyKilled(string idKill)
        {
            var quest = _quests.OfType<KillQuest>().FirstOrDefault(_ => _.Id == idKill)!;
            if(quest == default) return;
            quest.EnemyKilled(idKill);
            ChangeProgressQuest(quest);
        }

        public void ObjectFound(string idFind)
        {
            var quest = _quests.OfType<SearchQuest>().FirstOrDefault(_ => _.Id == idFind)!;
            if(quest == default) return;
            quest.ObjectFound(idFind);
            ChangeProgressQuest(quest);
        }

        public void NpcTalked(string idTalk)
        {
            var quest = _quests.OfType<TalkQuest>().FirstOrDefault(_ => _.Id == idTalk)!;
            if (quest is null) return;
            quest.NpcTalked(idTalk);
            ChangeProgressQuest(quest);
            _talkQuestUI.OpenTalkPanel(quest);
        }

        private void ChangeProgressQuest(Quest quest)
        {
            _playerQuestUI.ChangeProgress(quest);
        }

        public void SaveProgressQuest()
        {
            ES3.Save("PlayerQuest", _quests);
            ES3.Save("ComplitedPlayerQuest", _complitedQuests);
        }
        
        public void LoadProgressQuest()
        {
            if (ES3.KeyExists("PlayerQuest"))
            {
                _quests = ES3.Load<List<Quest>>("PlayerQuest");
                foreach (var quest in _quests)
                {
                    _playerQuestUI.SetInfoOrQuest(quest);
                }
            }
            if (ES3.KeyExists("ComplitedPlayerQuest"))
            {
                _complitedQuests = ES3.Load<List<string>>("ComplitedPlayerQuest");
            }
        }
    }
}