using UnityEngine;

namespace Services.Input
{
    public class MobileInputService : InputService
    {
        public MobileInputService(FloatingJoystick joystick) : base(joystick)
        {
        }
        
        public override float Axis
        {
            get
            {
                var axis = JoystickAxis();
                if (axis == 0f)
                    axis = UnityAxis();
                return axis;
            }
        }

        public override float Jump(float jump)
            =>  jump;

        private float UnityAxis()
            => UnityEngine.Input.GetAxis(Horizontal);
    }
}