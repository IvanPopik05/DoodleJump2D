using System;

namespace Input_System
{
    public interface IInput
    {
        event Action<float> Pressed;
        void UpdateInput();
    }
}