using UnityEngine;

namespace Services.Input
{
    public class StandaloneInputService : InputService
    {
        public StandaloneInputService(FloatingJoystick joystick) : base(joystick)
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
            => UnityEngine.Input.GetKeyDown(KeyCode.Space) ? jump : 0f;

        private float UnityAxis()
            => UnityEngine.Input.GetAxis(Horizontal);


    }
}