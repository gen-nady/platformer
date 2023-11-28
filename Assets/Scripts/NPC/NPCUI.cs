using System;
using Infastructure;
using UnityEngine;
using UnityEngine.UI;

namespace NPC
{
    public class NPCUI : MonoBehaviour
    {
        [SerializeField] private GameObject _npcPanel;
        [SerializeField] private Button _talkButton;
        [SerializeField] private Button _saleButton;
        [SerializeField] private Button _questButton;
        
        public void SetActionButtons(Action talk, Action sale, Action quest)
        {
            _npcPanel.SetActive(true);
            if (talk != default)
            {
                _talkButton.onClick.AddListener(() => talk?.Invoke());
                _talkButton.gameObject.SetActive(true);
            }
            else
            {
                _talkButton.gameObject.SetActive(false);
            }
            if (sale != default)
            {
                _saleButton.onClick.AddListener(() => sale?.Invoke());
                _saleButton.gameObject.SetActive(true);
            }
            else
            {
                _saleButton.gameObject.SetActive(false);
            }
            if (quest != default)
            {
                _questButton.onClick.AddListener(() => quest?.Invoke());
                _questButton.gameObject.SetActive(true);
            }
            else
            {
                _questButton.gameObject.SetActive(false);
            }
        }

        public void RemoveAllListener()
        {
            _npcPanel.SetActive(false);
            _talkButton.onClick.RemoveAllListeners();
            _saleButton.onClick.RemoveAllListeners();
            _questButton.onClick.RemoveAllListeners();
        }
    }
}