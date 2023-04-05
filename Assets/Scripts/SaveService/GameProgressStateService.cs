using UnityEngine;
using Zenject;

namespace SaveService
{
    public class GameProgressStateService : MonoBehaviour
    {
        [Inject] private MainPlayerMovement _mainPlayerMovement;

        private void Awake()
        {
            if(ES3.KeyExists("_mainPlayerMovement"))
                _mainPlayerMovement = ES3.Load<MainPlayerMovement>("_mainPlayerMovement");

        }
    }
}