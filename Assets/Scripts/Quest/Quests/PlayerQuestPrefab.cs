using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Quest
{
    public class PlayerQuestPrefab : MonoBehaviour
    {
        [SerializeField] private string _idQuest;
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private TextMeshProUGUI _disriptionText;

        public string IdQuest => _idQuest;
        
        public void SetValue(Quest quest)
        {
            _titleText.text = quest.Title;
            _idQuest = quest.Id;
            ChangeProgress(quest);
        }

        public void ChangeProgress(Quest quest)
        {
            _disriptionText.text = quest.CurrentTextProgress();
        }
    }
}