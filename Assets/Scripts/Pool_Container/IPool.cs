using UnityEngine;

namespace Pool_Container
{
    public interface IPool<T> where T : MonoBehaviour
    {
        T GetElement();
        void ReturnToPull(T element);
    }
}