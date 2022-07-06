using System.Collections.Generic;
using System.Linq;
using Generator_Container;
using UnityEngine;

namespace Pool_Container
{
    public class Pool<T> : IPool<T> where T : MonoBehaviour
    {
        private Queue<PullElement> _pool;
        
        private readonly T _prefab;
        private readonly GeneratorRandom _generatorRandom;
        private readonly Transform _container;
        private readonly int _baseQuantity;
        private readonly int _additionQuantity;
        public Pool(T prefab, Transform container,GeneratorRandom generatorRandom, int baseQuantity, int additionQuantity)
        {
            _prefab = prefab;
            _container = container;
            _generatorRandom = generatorRandom;
            _baseQuantity = baseQuantity;
            _additionQuantity = additionQuantity;
            
            Initialize();
        }

        private void Initialize()
        {
            _pool = new Queue<PullElement>(_baseQuantity);
            
            SpawnElements(_baseQuantity);
        }

        public T GetElement()
        {
            if (HasFreeElement(out T newElement))
                return newElement;

            SpawnElements(_additionQuantity);
            return GetElement();
        }

        public void ReturnToPull(T element)
        {
            var pullElement = _pool.FirstOrDefault(e => e.Element == element);
            if (pullElement != null)
            {
                element.transform.position = _generatorRandom.GetRandomPosition();
                pullElement.Used = false;
                element.gameObject.SetActive(false);
            }

        }

        private void SpawnElements(int baseQuantity)
        {
            for (int i = 0; i < baseQuantity; i++) 
                CreateElement();
        }

        private T CreateElement(bool isActiveByDefault = false)
        {
            T newElement = Object.Instantiate(_prefab, _generatorRandom.GetRandomPosition(), Quaternion.identity, _container);
            newElement.gameObject.SetActive(isActiveByDefault);
            
            _pool.Enqueue(new PullElement(newElement));
            return newElement;
        }

        private bool HasFreeElement(out T element)
        {
            var pullElement = _pool.FirstOrDefault(e => e.Used == false);

            if (pullElement != null)
            {
                pullElement.Used = true;
                element = pullElement.Element;
                
                element.gameObject.SetActive(true);
                return true;
            }
            
            element = null;
            return false;
        }

        private class PullElement
        {
            public readonly T Element;

            public bool Used;

            public PullElement(T element)
            {
                Element = element;
            }
        }
    }
}