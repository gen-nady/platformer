﻿using System;
using System.Collections;
using System.Collections.Generic;
using OtherItem;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Infastructure
{
    public class SceneLoader : MonoBehaviour
    {
        public static event Action OnSceneChange;
        [SerializeField] private Scenes _scenes;
        [SerializeField] private Vector3 _positionPoint;
        private WorldInfoUI _worldInfoUI;
        
        [Inject]
        private void Construct(WorldInfoUI worldInfoUI)
        {
            _worldInfoUI = worldInfoUI;
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.GetComponent<MainPlayerMovement>())
            {
                col.gameObject.transform.position = _positionPoint;
                StartCoroutine(LoadLevelAsync());
            }
        }
        
        private IEnumerator LoadLevelAsync()
        {
            _worldInfoUI.OpenLoading();
            var progress = SceneManager.LoadSceneAsync(_scenes.Scene.name, LoadSceneMode.Single);
            progress.allowSceneActivation = false;
            while (progress.progress < 0.9f)
            {
                yield return null;
            }
            progress.allowSceneActivation = true;
            OnSceneChange?.Invoke();
            _worldInfoUI.CloseLoading();
        }
    }
}