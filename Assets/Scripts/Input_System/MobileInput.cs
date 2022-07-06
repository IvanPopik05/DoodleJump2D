using System;
using UnityEngine;

namespace Input_System
{
    public class MobileInput : IInput
    {
        private float _dirX;
        
        public event Action<float> Pressed;
        public void UpdateInput()
        {
            _dirX = Input.acceleration.x;
            Pressed?.Invoke(_dirX);
        }
    }
}