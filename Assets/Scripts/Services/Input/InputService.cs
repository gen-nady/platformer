namespace Services.Input
{
    public abstract class InputService : IInputService
    {
        public abstract float HorizontalAxis { get; }
        public abstract float VerticalAxis { get; }
        protected const string HORIZONTAL = "Horizontal";
        
        protected const string VERTICAL = "Vertical";
        protected readonly FloatingJoystick _floatingJoystick;
        
        protected InputService(FloatingJoystick joystick)
        {
            _floatingJoystick = joystick;
        }
    }
}