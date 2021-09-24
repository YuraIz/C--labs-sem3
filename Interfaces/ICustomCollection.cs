namespace _053506_Izmer_lab5.Interfaces
{
    internal interface ICustomCollection<T>
    {
        T this[int index] { get; set; }
        int Count { get; }
        void Reset();
        void Next();
        T Current();
        void Add(T item);
        void Remove(T item);
        T RemoveCurrent();
    }
}