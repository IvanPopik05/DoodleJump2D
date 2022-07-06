using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace DefaultNamespace
{
    public class PlatformMove : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _sprite;
        [SerializeField] private float _jumpForce = 10f;
        [SerializeField] private float _speedMove = 0.7f;

        private bool _isRight;
        private Camera _camera;
        private float _screenCoordsX;
        private void Start()
        {
            _camera = Camera.main;
            _screenCoordsX = (_camera.orthographicSize * _camera.aspect) - _sprite.bounds.extents.x;
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
            Moving();
        }

        private void Moving()
        {
            if (!_isRight)
            {
                transform.position += new Vector3(_speedMove * Time.deltaTime, 0);
                if (transform.position.x >= _screenCoordsX)
                    _isRight = true;
            }
            else
            {
                transform.position -= new Vector3(_speedMove * Time.deltaTime, 0);
                if (transform.position.x <= -_screenCoordsX)
                    _isRight = false;
            }
        }
    }
}