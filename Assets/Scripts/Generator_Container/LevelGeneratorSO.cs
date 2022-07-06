using Extensions;
using Pool_Container;
using UnityEngine;

namespace Generator_Container
{
    public class LevelGeneratorSO : MonoBehaviour
    {
        [SerializeField] private PlatformLevels _platformLevels;
        [SerializeField] private Transform _startingPointSpawn;
        [SerializeField] private Transform _lowerCameraPosition;
        [SerializeField] private int _baseQuantity = 7;
        [SerializeField] private int _additionQuantity;
        [SerializeField] private float _delaySpawn = 1.5f;

        private IPool<Level> _pool;
        private Level _level;
        private GeneratorRandom _generatorRandom;
        private float _timeSpawn;
        public void Initialize()
        {
            _generatorRandom = new GeneratorRandom(_startingPointSpawn.position,_platformLevels.Levels.GetRandomItem().EndPoint);
            _pool = new Pool<Level>(_platformLevels.Levels.GetRandomItem(),transform,_generatorRandom,_baseQuantity,_additionQuantity);

            _level = _pool.GetElement();
            _level.Construct(_pool, _lowerCameraPosition);
        }

        private void Update()
        {
            _timeSpawn += Time.deltaTime;
            if (_timeSpawn > _delaySpawn)
            {
                _timeSpawn = 0;
                _level = _pool.GetElement();
                _level.Construct(_pool,_lowerCameraPosition);
            }
        }
    }
}