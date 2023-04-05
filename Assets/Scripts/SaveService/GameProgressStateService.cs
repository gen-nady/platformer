using System;
using Infastructure;
using Quest;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace SaveService
{
    public class GameProgressStateService : MonoBehaviour
    {
        [SerializeField] private MainPlayerMovement _mainPlayerMovement;
        private PlayerQuest _playerQuest;
        private PlayerQuestUI _playerQuestUI;
        private Vector3 _positionPlayer;
        private int _currentScene;

        
        [Inject]
        private void Construct(PlayerQuest playerQuest, PlayerQuestUI playerQuestUI)
        {
            _playerQuest = playerQuest;
            _playerQuestUI = playerQuestUI;
        }
        
        private void Awake()
        {
            QuestGiver.QuestCompleted += SaveAfterQuest;
            QuestGiver.AddQuestToPlayer += SaveAfterQuest;
            SceneLoader.OnSceneChange += Save;
            
            if (ES3.KeyExists("PlayerPosition"))
            {
                _positionPlayer = ES3.Load<Vector3>("PlayerPosition");
                _mainPlayerMovement.transform.position = _positionPlayer;
            }

            if (ES3.KeyExists("CurrentScene"))
            {
                _currentScene = ES3.Load<int>("CurrentScene");
                SceneManager.LoadScene(_currentScene);
            }
            
            _playerQuest.LoadProgressQuest();
        }

        private void OnDisable()
        {
            QuestGiver.QuestCompleted -= SaveAfterQuest;
            QuestGiver.AddQuestToPlayer -= SaveAfterQuest;
            SceneLoader.OnSceneChange -= Save;
        }

        private void SaveAfterQuest(Quest.Quest quest)
        {
            Save();
        }

        private void Save()
        {
            ES3.Save("PlayerPosition", _mainPlayerMovement.transform.position);
            ES3.Save("CurrentScene", SceneManager.GetActiveScene().buildIndex);
            _playerQuest.SaveProgressQuest();
        }
        
        private void OnApplicationQuit()
        {
            Save();
        }
    }
}