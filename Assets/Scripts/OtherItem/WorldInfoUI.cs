﻿using TMPro;
using UnityEngine;

namespace OtherItem
{
    public class WorldInfoUI : MonoBehaviour
    {
        [SerializeField] private GameObject _tableInfoPanel;
        [SerializeField] private TextMeshProUGUI _tableInfoText;

        public void ShowTableInfoPanel(string text)
        {
            _tableInfoPanel.SetActive(true);
            _tableInfoText.text = text;
        }
        
        public void CloseTableInfoPanel()
        {
            _tableInfoPanel.SetActive(false);
        }
    }
}