using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using _053505_Izmer_lab5.Interfaces;

namespace _053505_Izmer_lab5.Collections
{
    public class MyCustomCollectionItem<T>
    {
        private GCHandle? _next;
        public T Value;

        public MyCustomCollectionItem(T value)
        {
            Value = value;
        }

        public MyCustomCollectionItem<T>? Next
        {
            get => (MyCustomCollectionItem<T>)_next?.Target!;
            set
            {
                _next?.Free();
                _next = value != null ? GCHandle.Alloc(value) : null;
            }
        }

        public void FreeAllNext()
        {
            if (_next == null) return;
            ((MyCustomCollectionItem<T>)_next.Value.Target!).FreeAllNext();
            _next.Value.Free();
        }
    }

    public class MyCustomCollection<T> : ICustomCollection<T>, IEnumerable<T>
    {
        private MyCustomCollectionItem<T> _cursor;
        private GCHandle _first;

        public MyCustomCollection(T item)
        {
            _first = GCHandle.Alloc(new MyCustomCollectionItem<T>(item));
            _cursor = (MyCustomCollectionItem<T>)_first.Target!;
        }

        private MyCustomCollectionItem<T> Last
        {
            get
            {
                MyCustomCollectionItem<T> current = _cursor;
                while (current.Next != null) current = current.Next;
                return current;
            }
        }

        public T this[int index]
        {
            get => AtIndex(index);
            set => AtIndex(index) = value;
        }

        public void Reset()
        {
            _cursor = (MyCustomCollectionItem<T>)_first.Target!;
        }

        public void Next()
        {
            if (_cursor.Next != null) _cursor = _cursor.Next;
        }

        public T Current()
        {
            return _cursor.Value;
        }

        public int Count => ItemsToEnd((MyCustomCollectionItem<T>)_first.Target!);

        public void Add(T item)
        {
            Last.Next = new MyCustomCollectionItem<T>(item);
        }

        public void Remove(T item)
        {
            var current = (MyCustomCollectionItem<T>)_first.Target!;
            while (current.Next != null && !current.Next.Value!.Equals(item)) current = current.Next;
            if (current.Next != null) current.Next = current.Next.Next;
        }

        public T RemoveCurrent()
        {
            var index = Count - ItemsToEnd(_cursor);
            var current = (MyCustomCollectionItem<T>)_first.Target!;
            for (var i = 0; i < index - 1; i++) current = current?.Next;
            Debug.Assert(current != null, nameof(current) + " != null");
            Debug.Assert(current.Next != null, "current.Next != null");
            current.Next = current.Next.Next;
            return Current();
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = (MyCustomCollectionItem<T>)_first.Target!;
            while (current.Next != null)
            {
                yield return current.Value;
                current = current.Next;
            }

            yield return current.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private ref T AtIndex(int index)
        {
            var current = (MyCustomCollectionItem<T>)_first.Target!;
            for (var i = 0; i < index; i++) current = current?.Next;
            if (current == null) throw new IndexOutOfRangeException();
            return ref current.Value;
        }

        private static int ItemsToEnd(MyCustomCollectionItem<T> current)
        {
            var count = 0;
            while (current.Next != null)
            {
                current = current.Next;
                count++;
            }

            return count;
        }

        ~MyCustomCollection()
        {
            ((MyCustomCollectionItem<T>)_first.Target!).FreeAllNext();
            _first.Free();
        }
    }
}