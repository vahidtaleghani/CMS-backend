namespace CMS.Singleton
{
    using System;
    public sealed class GenericSingleton<T> where T : class, new()
    {
        private static T _instance = null;

        private static readonly object _instanceLocker = new object();

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_instanceLocker)
                    {
                        if (_instance == null)
                        {
                            _instance = new T();
                        }
                    }
                }

                return _instance;
            }
        }
    }
}