namespace Core.Classes
{
    public class Synchronized<T>
    {
        private object _lock;
        private T _value;

        public T Value
        {
            get
            {
                lock (_lock)
                {
                    return _value;
                }
            }
            set
            {
                lock (_lock)
                {
                    _value = value;
                }
            }
        }

        public Synchronized()
        {
            _lock = new object();
        }

        public Synchronized(T value)
        {
            _lock = new object();
            this.Value = value;
        }

        public Synchronized(T value, object Lock)
        {
            _lock = Lock;
            this.Value = value;
        }

        public static implicit operator T(Synchronized<T> s)
        {
            return s.Value;
        }
    }
}
