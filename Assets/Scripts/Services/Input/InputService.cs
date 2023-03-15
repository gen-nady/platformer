using UnityEngine;

namespace Services.Input
{
    public abstract class InputService : IInputService
    {
        public abstract float Axis { get; }
        public abstract float Jump(float jump);
        protected const string Horizontal = "Horizontal";
        private readonly FloatingJoystick _floatingJoystick;
        
        protected InputService(FloatingJoystick joystick)
        {
            _floatingJoystick = joystick;
        }
        
        protected float JoystickAxis()
            => _floatingJoystick.Horizontal;
        
        public bool IsAttackButtonUp()
        {
            throw new System.NotImplementedException();
        }
    }
}