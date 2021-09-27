namespace _053505_Izmer_lab8.Interfaces
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