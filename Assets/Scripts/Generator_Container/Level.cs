using System;
using Pool_Container;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Generator_Container
{
    public class Level : MonoBehaviour, ILevel<Level>
    {
        [SerializeField] private Transform _endPoint;
        
        private IPool<Level> _pool;
        private Transform _lowerCameraPosition;

        public Transform EndPoint => _endPoint;
        public void Construct(IPool<Level> pool, Transform lowerCameraPosition)
        {
            _pool = pool;
            _lowerCameraPosition = lowerCameraPosition;
        }

        private void Update()
        {
            if (_endPoint.position.y < _lowerCameraPosition.position.y)
            {
                _pool.ReturnToPull(this);
            }
        }
    }

    public interface ILevel<T> where T : MonoBehaviour
    {
        public void Construct(IPool<T> pool, Transform lowerCameraPosition);
    }
}