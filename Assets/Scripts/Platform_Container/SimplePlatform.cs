using Pause_System;
using Pool_Container;
using UnityEngine;

namespace Platform_Container
{
    public class SimplePlatform : BasePlatform, IPauseHandler
    {
        [SerializeField] protected float _jumpForce = 10f;   
        
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
                Vector2 velocity = rb.velocity;
                velocity.y = _jumpForce;
                rb.velocity = velocity;
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