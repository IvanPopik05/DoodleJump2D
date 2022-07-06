using System;
using Pause_System;
using Pool_Container;
using UnityEngine;

namespace Platform_Container
{
    public class BrokenPlatform : BasePlatform, IPauseHandler
    { 
        [SerializeField] private EdgeCollider2D _collider2D;
        
        private IPool<BasePlatform> _pool;
        private Transform _lowerCameraPosition;
        public bool IsPaused => PauseManager.Instance.IsPaused;
        public override void Construct(IPool<BasePlatform> pool, Transform lowerCameraPosition)
        {
            _pool = pool;
            _lowerCameraPosition = lowerCameraPosition;
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.collider.TryGetComponent(out Rigidbody2D rb) && collision.relativeVelocity.y <= 0)
            {
                _collider2D.isTrigger = true;
                _pool.ReturnToPull(this);
                _collider2D.isTrigger = false;
            }
        }
        private void Update()
        {
            if(IsPaused)
                return;
            
            if (transform.position.y < _lowerCameraPosition.position.y) 
                _pool.ReturnToPull(this);
        }
    }
}