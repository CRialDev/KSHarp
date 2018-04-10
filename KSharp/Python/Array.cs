using System;
using System.Collections;
using System.Collections.Generic;

namespace CRial.Python
{
    public class Array<T> : PythonObject, IEnumerator<T>, IList<T>
    {
        private bool _isReadOnly;
        private int position = -1;
        public Array(string name, bool isReadOnly = false) : base(name)
        {

            _isReadOnly = isReadOnly;
        }
        //
        public T this[int index]
        {
            get
            {
                if (index > Count)
                    return (T)(object)null;

                if (typeof(T) == typeof(int) || typeof(T) == typeof(long) || typeof(T) == typeof(float) || typeof(T) == typeof(bool) || typeof(T) == typeof(string))
                {
                    return Utils.Call<T>(_name + "[" + index + "]");
                }
                else return Utils.GetFromType<T>(_name + "[" + index + "]");

            }

            set
            {
                if (typeof(T) == typeof(int) || typeof(T) == typeof(long) || typeof(T) == typeof(float) || typeof(T) == typeof(bool) || typeof(T).IsSubclassOf(typeof(PythonObject)))
                {
                    Utils.Call(_name + "[" + index + "] = " + value.ToString());
                }
                else
                {
                    Utils.Call(_name + "[" + index + "] = '" + value + "'");
                }
            }
        }
        public T Get(int index, T Default)
        {
            if (index >= Count)
                return Default;
            else return this[index];
        }
        public int Count
        {
            get
            {
                return Utils.Call<int>("len(" + _name + ")");
            }
        }
        public T Current
        {
            get
            {
                return this[position];
            }
        }
        public bool IsReadOnly
        {
            get
            {
                return _isReadOnly;
            }
        }
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        public void Add(T item)
        {
            if (typeof(T) == typeof(int) || typeof(T) == typeof(long) || typeof(T) == typeof(float) || typeof(T) == typeof(bool) || typeof(T).IsSubclassOf(typeof(PythonObject)))
            {
                Utils.Call(_name + ".append(" + item.ToString() + ")");
            }
            else
            {
                Utils.Call(_name + ".append('" + item + "')");
            }
        }
        public void Clear()
        {
            Utils.Call(_name + " = []");
        }
        public bool Contains(T item)
        {
            if (typeof(T) == typeof(int) || typeof(T) == typeof(long) || typeof(T) == typeof(float) || typeof(T) == typeof(bool) || typeof(T).IsSubclassOf(typeof(PythonObject)))
            {
                return Utils.Call<bool>(item.ToString() + " in " + _name);
            }
            else
            {
                return Utils.Call<bool>("'" + item + "' in " + _name);
            }
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
        }
        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }
        public int IndexOf(T item)
        {
            if (typeof(T) == typeof(int) || typeof(T) == typeof(long) || typeof(T) == typeof(float) || typeof(T) == typeof(bool) || typeof(T).IsSubclassOf(typeof(PythonObject)))
            {
                return Utils.Call<int>(_name + ".index(" + item.ToString() + ")");
            }
            else
            {
                return Utils.Call<int>(_name + ".index('" + item + "')");
            }
        }
        public void Insert(int index, T item)
        {
            if (typeof(T) == typeof(int) || typeof(T) == typeof(long) || typeof(T) == typeof(float) || typeof(T) == typeof(bool) || typeof(T).IsSubclassOf(typeof(PythonObject)))
            {
                Utils.Call(_name + ".insert(" + index + ", " + item.ToString() + ")");
            }
            else
            {
                Utils.Call(_name + ".insert(" + index + ", '" + item + "')");
            }
        }
        public bool MoveNext()
        {
            position++;
            return (position < Count);
        }
        public bool Remove(T item)
        {
            if (typeof(T) == typeof(int) || typeof(T) == typeof(long) || typeof(T) == typeof(float) || typeof(T) == typeof(bool) || typeof(T).IsSubclassOf(typeof(PythonObject)))
            {
                Utils.Call(_name + ".remove(" + item.ToString() + ")");
            }
            else
            {
                Utils.Call(_name + ".remove('" + item + "')");
            }
            return true;
        }
        public void RemoveAt(int index)
        {
            Utils.Call("del " + _name + "[" + index + "]");
        }
        public void Reset()
        {
            position = -1;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public List<T> ToList()
        {
            List<T> li = new List<T>();
            foreach (T s in this)
                li.Add(s);
            return li;
        }
    }
}
