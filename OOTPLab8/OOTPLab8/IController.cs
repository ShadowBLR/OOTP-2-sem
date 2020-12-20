
namespace OOTPLab8
{
    interface IController<T>
    {
        bool Remove(T data);
        Node<T> Search(T data);
        void Add(T data);
        void Print(int index);
    }
}
