using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infastructure
{
    public class SceneLoader : MonoBehaviour
    {
        public static event Action OnSceneChange;
        [SerializeField] private Scenes _scenes;
        [SerializeField] private Vector3 _positionPoint;
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.GetComponent<MainPlayerMovement>())
            {
                OnSceneChange?.Invoke();
                col.gameObject.transform.position = _positionPoint;
                SceneManager.LoadScene(_scenes.Scene.name);
            }
        }
        
    }
}