using System.Collections.Generic;
using UnityEngine;

namespace Generator_Container
{
    public class GeneratorRandom<T> where T : MonoBehaviour
    {
        private Vector2 _startingPointSpawn;
        private Vector2 _randomPoint;
        private bool _isStart = false;
        private Camera _camera;
        
        private readonly float _screenInCameraCoordsX;
        private readonly Vector2 _pointY;
        private readonly List<T> _listElements;
        public GeneratorRandom(List<T> listElements,Vector2 startingPointSpawn, Vector2 spawnBetweenElementsY)
        {
            _pointY = spawnBetweenElementsY;
            _listElements = listElements;
            _camera = Camera.main;
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
                _startingPointSpawn.y += Random.Range(_pointY.x, _pointY.y);
                _randomPoint = new Vector2(GetRandomValue(_screenInCameraCoordsX),_startingPointSpawn.y);
            }

            return _randomPoint;
        }

        private float GetRandomValue(float coords) => 
            Random.Range(-coords, coords);

        public T GetRandomElement()
        {
            float percent = Random.Range(0, 100);

            if (percent < 70)
            {
                return _listElements[0];
            }
            
            int range = Random.Range(0, _listElements.Count);
            return _listElements[range];
        }
    }
}