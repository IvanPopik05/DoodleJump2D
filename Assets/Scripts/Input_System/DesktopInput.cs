using System;
using UnityEngine;

namespace Input_System
{
    public class DesktopInput : IInput
    {
        private const string AXIS_HORIZONTAL = "Horizontal";
        
        private float _dirX;
        public event Action<float> Pressed;
        public void UpdateInput()
        {
            _dirX = Input.GetAxis(AXIS_HORIZONTAL);
            Pressed?.Invoke(_dirX);
        }
    }
}