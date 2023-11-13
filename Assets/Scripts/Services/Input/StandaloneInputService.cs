namespace Services.Input
{
    public class StandaloneInputService : InputService
    {
        public StandaloneInputService(FloatingJoystick joystick) : base(joystick)
        {
        }
        
        public override float HorizontalAxis => UnityEngine.Input.GetAxis(HORIZONTAL);
        public override float VerticalAxis => UnityEngine.Input.GetAxis(VERTICAL);
    }
}