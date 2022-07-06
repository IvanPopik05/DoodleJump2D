using Pause_System;
using Pool_Container;
using UnityEngine;

namespace Platform_Container
{
    public enum PlatformMovingType
    {
        Right_Left,
        Up_Down
    }

    public class MovingPlatform : BasePlatform, IPauseHandler
    {
        [SerializeField] private SpriteRenderer _sprite;
        [SerializeField] private PlatformMovingType _platformMovingType;
        [SerializeField] private float _speedMove = 0.7f;
        [SerializeField] private float _jumpForce = 10f;   
        
        private bool _isRather;
        private float _screenCoordsX;
        private float _screenCoordsYMin;
        private float _screenCoordsYMax;
        private int _range;
        
        private IPool<BasePlatform> _pool;
        private Camera _camera;
        private Transform _lowerCameraPosition;
        
        public bool IsPaused => PauseManager.Instance.IsPaused;
        public override void Construct(IPool<BasePlatform> pool, Transform lowerCameraPosition)
        {
            _camera = Camera.main;
            _screenCoordsX = (_camera.orthographicSize * _camera.aspect) - _sprite.bounds.extents.x;
            _screenCoordsYMax = transform.position.y + 4;
            _screenCoordsYMin = transform.position.y - 4;
            
            _lowerCameraPosition = lowerCameraPosition;
            _platformMovingType = RandomDirection();
            _pool = pool;
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
        
            Moving();
            if (transform.position.y < _lowerCameraPosition.position.y) 
                _pool.ReturnToPull(this);
        }


        private void Moving()
        {
            switch (_platformMovingType)
            {
                case PlatformMovingType.Right_Left: 
                    MovingX();
                    break;
                case PlatformMovingType.Up_Down:
                    MovingY();
                    break;
            }
        }

        private void MovingY()
        {
            if (!_isRather)
            {
                transform.position += new Vector3(0, _speedMove * Time.deltaTime);
                if (transform.position.y >= _screenCoordsYMax)
                    _isRather = true;
            }
            else
            {
                transform.position -= new Vector3(0, _speedMove * Time.deltaTime);
                if (transform.position.y <= _screenCoordsYMin)
                    _isRather = false;
            }
        }

        private void MovingX()
        {
            if (!_isRather)
            {
                transform.position += new Vector3(_speedMove * Time.deltaTime, 0);
                if (transform.position.x >= _screenCoordsX)
                    _isRather = true;
            }
            else
            {
                transform.position -= new Vector3(_speedMove * Time.deltaTime, 0);
                if (transform.position.x <= -_screenCoordsX)
                    _isRather = false;
            }
        }

        private PlatformMovingType RandomDirection()
        {
            _range = Random.Range(0, 2);
            return _range == 0 ? PlatformMovingType.Right_Left : PlatformMovingType.Up_Down;
        }
    }
}