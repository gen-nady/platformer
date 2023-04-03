using Infastructure;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Quest
{
    public class TalkQuestUI : MonoBehaviour
    {
        [Header("Разговор по квесту")]
        [SerializeField] private GameObject _questTalkPanel;
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private TextMeshProUGUI _desriptionText;
        [SerializeField] private Button _nextButton;
        [SerializeField] private Button _getRewardButton;

        private int currentPhrase;
        private TalkQuest _quest;
        
        private void OnEnable()
        {
            SceneLoader.OnSceneChange += CloseQuestTalkPanel;
        }

        private void OnDisable()
        {
            SceneLoader.OnSceneChange -= CloseQuestTalkPanel;
        }

        public void OpenTalkPanel(Quest quest)
        {
            _quest = quest as TalkQuest;
            _questTalkPanel.SetActive(true);
            _titleText.text = _quest!.Title;
            currentPhrase = 0;
            _desriptionText.text = _quest!.NpcText[currentPhrase];
            if (_quest!.NpcText.Count > 1)
            {
                _nextButton.gameObject.SetActive(true);
                _getRewardButton.gameObject.SetActive(false);
            }
            else
            {
                _nextButton.gameObject.SetActive(false);
                _getRewardButton.gameObject.SetActive(true);
            }
        }
        
        public void NextPhrase()
        {
            currentPhrase++;
            if (_quest!.NpcText.Count > currentPhrase)
            {
                _desriptionText.text = _quest!.NpcText[currentPhrase];
                if (_quest!.NpcText.Count - 1 == currentPhrase)
                {
                    _getRewardButton.gameObject.SetActive(true);
                }
            }
        }
        
        public void GetReward()
        {
           _quest.QuestGiver.CompletedTalkQuest();
           _questTalkPanel.SetActive(false);
        }

        private void CloseQuestTalkPanel()
        {
            _questTalkPanel.SetActive(false);
        }
    }
}