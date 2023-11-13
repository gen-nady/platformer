namespace Services.Input
{
    public class MobileInputService : InputService
    {
        public MobileInputService(FloatingJoystick joystick) : base(joystick)
        {
        }
        
        public override float HorizontalAxis =>  _floatingJoystick.Horizontal;
        public override float VerticalAxis  =>  _floatingJoystick.Vertical;
    }
}