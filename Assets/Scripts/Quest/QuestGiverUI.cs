using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Cysharp.Threading.Tasks;
using Infastructure;
using Newtonsoft.Json;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Quest
{
    public class QuestGiverUI : MonoBehaviour
    {
        [Header("Получение квеста")]
        [SerializeField] private GameObject _questPanel;
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private TextMeshProUGUI _desriptionText;
        [SerializeField] private Button _agreeQuestButton;
        [Header("Сдача квеста")]
        [SerializeField] private TextMeshProUGUI _bonusesText;
        [SerializeField] private GameObject _bonusesPanel;
        [SerializeField] private Button _agreeBonusesButton;

        private void OnEnable()
        {
            SceneLoader.OnSceneChange += CloseBonusesPanel;
            SceneLoader.OnSceneChange += CloseQuestPanel;
        }

        private async void OnDisable()
        {
            SceneLoader.OnSceneChange -= CloseBonusesPanel;
            SceneLoader.OnSceneChange -= CloseQuestPanel;
            var res = await PostAsync<Object,Object>(String.Empty, new Object());
        }

        public async UniTask<TResponse> PostAsync<TRequest, TResponse>(string domain, TRequest requestObject)
        {
            var _client = new HttpClient();
            var response = await _client.PostAsync($"{domain}",
                new StringContent(JsonConvert.SerializeObject(requestObject), Encoding.UTF8, "application/json"));
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(responseBody);
        }

        public void SetQuestText(Quest quest, Action agreeAction)
        {
            _questPanel.SetActive(true);
            _titleText.text = quest.Title;
            _desriptionText.text = quest.Discription;
            _agreeQuestButton.onClick.AddListener(() => agreeAction?.Invoke());
        }
        
        public void CompletedQuest(Quest quest, Action agreeAction)
        {
            _bonusesPanel.SetActive(true);
            _bonusesText.text = quest.ShowBonusesText();
            _agreeBonusesButton.onClick.AddListener(() => agreeAction?.Invoke());
        }
        
        public void CloseBonusesPanel()
        {
            _agreeBonusesButton.onClick.RemoveAllListeners();
            _bonusesPanel.SetActive(false);
        }
        
        public void CloseQuestPanel()
        {
            _agreeQuestButton.onClick.RemoveAllListeners();
            _questPanel.SetActive(false);
        }
    }
}