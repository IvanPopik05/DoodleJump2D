using System;
using Pool_Container;
using UnityEngine;

namespace Generator_Container
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private Platform _platformPrefab;
        [SerializeField] private Transform _startingPointSpawn;
        [SerializeField] private Transform _lowerCameraPosition;
        [SerializeField] private int _baseQuantity = 7;
        [SerializeField] private int _additionQuantity;
        [SerializeField] private float _delaySpawn = 1.5f;

        private IPool<Platform> _pool;
        private Platform _platform;
        private GeneratorRandom _generatorRandom;
        private float _timeSpawn;
        public void Initialize()
        {
            _generatorRandom = new GeneratorRandom(_startingPointSpawn.position,transform); // !!!
            _pool = new Pool<Platform>(_platformPrefab,transform,_generatorRandom,_baseQuantity,_additionQuantity);

            _platform = _pool.GetElement();
            //_platform.Construct(_pool, _lowerCameraPosition);
        }

        private void Update()
        {
            _timeSpawn += Time.deltaTime;
            if (_timeSpawn > _delaySpawn)
            {
                _timeSpawn = 0;
                _platform = _pool.GetElement();
                //_platform.Construct(_pool,_lowerCameraPosition);
            }
        }
    }
}