using System;
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
        [SerializeField] private string _textButton;
        private Transform _currentTransform;
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
                _currentTransform = col.gameObject.transform;
                _worldInfoUI.OpenButtonActionPanel(OpenNewScene, _textButton);
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.GetComponent<MainPlayerMovement>())
            {
                _worldInfoUI.CloseButtonActionPanel();
            }
        }
        
        private void OpenNewScene()
        {
            _currentTransform.position = _positionPoint;
            StartCoroutine(LoadLevelAsync());
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
            ES3.Save("CurrentScene", SceneManager.GetActiveScene().buildIndex);
            _worldInfoUI.CloseButtonActionPanel();
            _worldInfoUI.CloseLoading();
        }
    }
}