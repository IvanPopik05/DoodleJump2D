
namespace Pool_Container
{
    public interface IPool<T>
    {
        T GetElement();
        void ReturnToPull(T element);
    }
}