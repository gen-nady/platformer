﻿using Infastructure;
using UnityEngine;
using Zenject;

namespace OtherItem
{
    public class BigInfo : MonoBehaviour
    {
        [SerializeField] private string _text;
        private WorldInfoUI _worldInfoUI;
        
        [Inject]
        private void Construct(WorldInfoUI worldInfoUI)
        {
            _worldInfoUI = worldInfoUI;
        }
        
        private void OnEnable()
        {
            SceneLoader.OnSceneChange += CloseText;
        }

        private void OnDisable()
        {
            SceneLoader.OnSceneChange -= CloseText;
        }
        
        public void ShowText()
        {
            _worldInfoUI.ShowBigTableInfoPanel(_text);
        }

        public void CloseText()
        {
            _worldInfoUI.CloseBigTableInfoPanel();
        }
    }
}