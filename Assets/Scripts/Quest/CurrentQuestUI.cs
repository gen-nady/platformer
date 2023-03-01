using TMPro;
using UnityEngine;

namespace Quest
{
    public class CurrentQuestUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currentProgressQuest;
        [SerializeField] private TextMeshProUGUI _nameQuest;

        #region MONO
        private void OnEnable()
        {
            GiverQuests.AddQuestToPlayer += SetInfoOrQuest;
            GiverQuests.QuestCompleted += ResetQuest;
        }

        private void OnDestroy()
        {
            GiverQuests.AddQuestToPlayer -= SetInfoOrQuest;
            GiverQuests.QuestCompleted -= ResetQuest;
        }
        #endregion
       
        public void ChangeProgress(Quest quest)
        {
            _currentProgressQuest.text = quest.CurrentProgress();
        }
        
        private void SetInfoOrQuest(Quest quest)
        {
            _nameQuest.text = quest.Name;
            _currentProgressQuest.text = quest.CurrentProgress();
        }
        
        private void ResetQuest(Quest quest)
        {
            _nameQuest.text = string.Empty;
            _currentProgressQuest.text = string.Empty;
        }
    }
}