using System;
using Infastructure;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace OtherItem
{
    public class WorldInfoUI : MonoBehaviour
    {
        [Header("Table Info")]
        [SerializeField] private GameObject _tableInfoPanel;
        [SerializeField] private TextMeshProUGUI _tableInfoText;
        [Header("Loading Panel")]
        [SerializeField] private GameObject _loadingPanel;
        [Header("Other Item")]
        [SerializeField] private Button _buttonAction;
        [SerializeField] private TextMeshProUGUI _buttonText;

        private void OnEnable()
        {
            SceneLoader.OnSceneChange += CloseTableInfoPanel;
        }

        private void OnDisable()
        {
            SceneLoader.OnSceneChange -= CloseTableInfoPanel;
        }
        
        public void ShowTableInfoPanel(string text)
        {
            _tableInfoPanel.SetActive(true);
            _tableInfoText.text = text;
        }
        
        public void CloseTableInfoPanel()
        {
            _tableInfoPanel.SetActive(false);
        }
        
        public void OpenLoading()
        {
            _loadingPanel.SetActive(true);
        }
        
        public void CloseLoading()
        {
            _loadingPanel.SetActive(false);
        }
        
        public void OpenButtonActionPanel(Action action, string textButton)
        {
            _buttonAction.gameObject.SetActive(true);
            _buttonText.text = textButton;
            _buttonAction.onClick.AddListener(() => action?.Invoke());
        }
        
        public void CloseButtonActionPanel()
        {
            _buttonAction.gameObject.SetActive(false);
            _buttonAction.onClick.RemoveAllListeners();
        }
    }
}