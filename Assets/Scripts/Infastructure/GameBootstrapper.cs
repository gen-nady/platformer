using UnityEngine;

namespace Infastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private FloatingJoystick _joystick;
        private Game _game;

        private void Awake()
        {
            
            _game = new Game(_joystick);
            
            DontDestroyOnLoad(this);
        }
    }
}