using System;
using System.Collections.Generic;
using Pause_System;
using Platform_Container;
using Pool_Container;
using UnityEngine;

namespace Generator_Container
{
    public class LevelGenerator : MonoBehaviour, IPauseHandler
    {
        [SerializeField] private List<BasePlatform> _platformPrefabs;
        [SerializeField] private Transform _startingPointSpawn;
        [SerializeField] private Transform _lowerCameraPosition;
        [SerializeField] private Vector2 _spawnBetweenElements;
        [SerializeField] private int _baseQuantity = 7;
        [SerializeField] private int _additionQuantity;
        [SerializeField] private int _amountStartElements = 7;
        [SerializeField] private float _delaySpawn = 1.5f;

        private IPool<BasePlatform> _pool;
        private BasePlatform _basePlatform;
        private GeneratorRandom<BasePlatform> _generatorRandom;
        private float _timeSpawn;

        public bool IsPaused => PauseManager.Instance.IsPaused;
        public void Initialize()
        {
            _generatorRandom = new GeneratorRandom<BasePlatform>(_platformPrefabs,_startingPointSpawn.position,_spawnBetweenElements);
            _pool = new Pool<BasePlatform>(transform,_generatorRandom,_baseQuantity,_additionQuantity);

            StartSpawn();
        }

        private void Update()
        {
            if(IsPaused)
                return;
            
            _timeSpawn += Time.deltaTime;
            if (_timeSpawn > _delaySpawn)
            {
                _timeSpawn = 0;
                _basePlatform = _pool.GetElement();
                _basePlatform.Construct(_pool,_lowerCameraPosition);
            }
        }

        private void StartSpawn()
        {
            for (int i = 0; i < _amountStartElements; i++)
            {
                _basePlatform = _pool.GetElement();
                _basePlatform.Construct(_pool, _lowerCameraPosition);
            }
        }
    }
}