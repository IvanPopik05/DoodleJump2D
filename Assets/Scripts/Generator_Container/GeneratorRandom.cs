using UnityEngine;

namespace Generator_Container
{
    public class GeneratorRandom
    {
        private Camera _camera;
        private Vector2 _randomPoint;
        private readonly float _screenInCameraCoordsX;
        private readonly Vector2 _pointY = new Vector2(1f,2f);

        private Vector2 _startingPointSpawn;
        private bool _isStart = false;
        private Transform _endPoint;
        public GeneratorRandom(Vector2 startingPointSpawn, Transform endPoint)
        {
            _camera = Camera.main;
            _endPoint = endPoint;
            _startingPointSpawn = startingPointSpawn;
            _screenInCameraCoordsX = _camera.aspect * _camera.orthographicSize;
        }
        public Vector3 GetRandomPosition()
        {
            if (!_isStart)
            {
                _randomPoint = _startingPointSpawn;
                _isStart = true;
            }
            else
            {
                _startingPointSpawn.y += _endPoint.position.y + Random.Range(_pointY.x, _pointY.y);
                _randomPoint = new Vector2(0,_startingPointSpawn.y);
            }

            return _randomPoint;
        }

        private float GetRandomValue(float coords) => 
            Random.Range(-coords, coords);
    }
}