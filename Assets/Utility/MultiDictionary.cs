using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Tools
{
public class MultiDictionary<T, U> : IEnumerable 
    where T : notnull where U : notnull
    {
        private List<MultiDictionaryKeyValuePair<T, U>> _keyValuesPairs;

        public MultiDictionary()
        {
            _keyValuesPairs = new List<MultiDictionaryKeyValuePair<T, U>>();
        }

        public void Add(T key, U value)
        {
            if (ContainsKey(key) == false) 
            {
                _keyValuesPairs.Add(new MultiDictionaryKeyValuePair<T, U>(key, new List<U>()));
            }
            AddValue(key, value);
        }

        public void Add(T key, IEnumerable<U> values)
        {
            if (ContainsKey(key) == false) 
            {
                _keyValuesPairs.Add(new MultiDictionaryKeyValuePair<T, U>(key, new List<U>()));
            }
            foreach (var value in values)
            {
                AddValue(key, value);
            }
        }

        public void Add(T key, U[] values)
        {
            Add(key, values.ToList());
        }

        public void Remove(T key, U value)
        {
            if (ContainsKey(key) == false) return;
            RemoveValue(key, value);
        }

        public void RemoveAllByKey(T key)
        {
            if (ContainsKey(key) == false) return;
            RemoveValuesByKey(key);
        }

        public bool ContainsKey(T key)
        {
            return _keyValuesPairs.Any(x => x.Key.Equals(key));
        }

        public bool ContainsValue(U value)
        {
            foreach (var pair in _keyValuesPairs)
            {
                if (pair.Values.Contains(value)) return true;
            }
            return false;
        }

        public bool ContainsValue(T key, U value)
        {
            if (ContainsKey(key) == false) return false;
            return _keyValuesPairs.First(x => x.Key.Equals(key)).Values.Contains(value);
        }

        public IEnumerable<U> this[T key]
        {
            get
            {
                if (ContainsKey(key) == false) return null;
                return _keyValuesPairs.First(x => x.Key.Equals(key)).Values;
            }
            set
            {
                if (ContainsKey(key) == false) return;
                _keyValuesPairs.First(x => x.Key.Equals(key)).SetValues(value);
            }
        }

        private void AddValue(T key, U value)
        {
            _keyValuesPairs.First(x => x.Key.Equals(key)).AddValue(value);
        }

        private void RemoveValue(T key, U value)
        {
            if (ContainsValue(value) == false) return;
            _keyValuesPairs.First(x => x.Key.Equals(key)).RemoveValue(value);
        }

        private void RemoveValuesByKey(T key)
        {
            _keyValuesPairs.Remove(_keyValuesPairs.First(x => x.Key.Equals(key)));
        }

        public IEnumerator GetEnumerator()
        {
            return new MultiDictionaryEnumerator<T, U>(_keyValuesPairs);
        }
    }

    public class MultiDictionaryEnumerator<T, U> : IEnumerator
    {
        private IEnumerable<MultiDictionaryKeyValuePair<T, U>> _pairs;
        int position = -1;

        public MultiDictionaryEnumerator(IEnumerable<MultiDictionaryKeyValuePair<T, U>> list)
        {
            _pairs = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _pairs.Count());
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current => Current;

        public MultiDictionaryKeyValuePair<T, U> Current
        {
            get
            {
                try
                {
                    return _pairs.ElementAt(position);
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

    public class MultiDictionaryKeyValuePair<T, U>
    {
        public T Key { get; private set; }
        public List<U> Values { get; private set; }

        public MultiDictionaryKeyValuePair(T key, IEnumerable<U> values)
        {
            (Key, Values) = (key, values.ToList());
        }

        public void AddValue(U value)
        {
            if (Values.Contains(value)) return;
            Values.Add(value);
        }

        public void SetValues(IEnumerable<U> values)
        {
            Values = values.ToList();
        }

        public void RemoveValue(U value)
        {
            if (Values.Contains(value) == false) return;
            Values.Remove(value);
        }
    }
}