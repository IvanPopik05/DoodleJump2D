namespace UI
{
    public interface IWindow
    {
        void Open(IWindow window = null);
        void Close();
    }
}