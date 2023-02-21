using UnityEngine;

namespace Services.Input
{
    public interface IInputService
    {
        float Axis { get; }
        float Jump(float jumpForce);
        bool IsAttackButtonUp();
        
    }
}