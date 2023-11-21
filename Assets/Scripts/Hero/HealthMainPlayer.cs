using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hero
{
    public class HealthMainPlayer : MonoBehaviour
    {
        public static event Action<int> OnHealthChanged; 
        [SerializeField] private int _healthCount;

        private int _currentHealthCount;

        private void Awake()
        {
            _currentHealthCount = _healthCount; 
            OnHealthChanged?.Invoke(_currentHealthCount);
        }

        public void TakeDamage(int damage)
        {
            _currentHealthCount -= damage;
            OnHealthChanged?.Invoke(_currentHealthCount);
            if (_currentHealthCount <= 0)
            {
                var currentScene = ES3.Load<int>("CurrentScene");
                _currentHealthCount = _healthCount;
                OnHealthChanged?.Invoke(_currentHealthCount);
                SceneManager.LoadScene(currentScene);
            }
        }
    }
}