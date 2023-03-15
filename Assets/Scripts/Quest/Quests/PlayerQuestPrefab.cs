using TMPro;
using UnityEngine;

namespace Quest
{
    public class PlayerQuestPrefab : MonoBehaviour
    {
        public string IdQuest;
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private TextMeshProUGUI _disriptionText;
        
        public void SetValue(Quest quest)
        {
            _titleText.text = quest.QuestTitle;
            _disriptionText.text = quest.CurrentTextProgress();
            IdQuest = quest.Id;
        }

        public void ChangeDiscription(string discription)
        {
            _disriptionText.text = discription;
        }
    }
}