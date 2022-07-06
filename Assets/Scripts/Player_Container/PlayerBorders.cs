using UnityEngine;

namespace Player_Container
{
    public class PlayerBorders
    {
        private Camera _camera;
        
        private readonly float _screenInCameraCoordsX;

        public PlayerBorders()
        {
            _camera = Camera.main;
            _screenInCameraCoordsX = _camera.aspect * _camera.orthographicSize;
        }

        public Vector2 CheckBorderPositionX(Transform target)
        {
            if (target.position.x > _screenInCameraCoordsX)
            {
                target.position = new Vector2(-_screenInCameraCoordsX, target.position.y);
            }
            else if (target.position.x < -_screenInCameraCoordsX)
            {
                target.position = new Vector2(_screenInCameraCoordsX,target.position.y);
            }

            return target.position;
        }
    }
}