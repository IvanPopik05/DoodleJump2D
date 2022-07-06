using Pause_System;
using Pool_Container;
using UnityEngine;

namespace Platform_Container
{
    public abstract class BasePlatform : MonoBehaviour
    {
        public abstract void Construct(IPool<BasePlatform> pool, Transform lowerCameraPosition);
    }
}