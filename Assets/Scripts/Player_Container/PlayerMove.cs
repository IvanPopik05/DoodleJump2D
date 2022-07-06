using UnityEngine;

namespace Player_Container
{
    
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMove : MonoBehaviour
    {
        private const string AXIS_HORIZONTAL = "Horizontal";

        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float _movementSpeed = 3f;

        private PlayerBorders _playerBorders;
        private float _movement;

        public void Initialize()
        {
            _playerBorders = new PlayerBorders();
        }

        private void Update()
        {
            _movement = Input.GetAxis(AXIS_HORIZONTAL) * _movementSpeed;
            
            transform.position = _playerBorders.CheckBorderPositionX(transform);
        }

        private void FixedUpdate()
        {
            Vector2 velocity = _rigidbody2D.velocity;
            velocity.x = _movement;
            _rigidbody2D.velocity = velocity;
        }
    }
}