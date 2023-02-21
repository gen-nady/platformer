using Services.Input;
using UnityEngine;

namespace Infastructure
{
    public class Game
    {
        public static IInputService InputService;
        
        public Game(FloatingJoystick joystick)
        {
            RegisterInput(joystick);
        }

        private static void RegisterInput(FloatingJoystick joystick)
        {
            if (Application.isEditor)
                InputService = new StandaloneInputService(joystick);
            else
                InputService = new MobileInputService(joystick);
        }
    }
}