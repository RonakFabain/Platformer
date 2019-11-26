using UnityEngine;

namespace BSP
{
    /**/
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        //The volatile keyword indicates that a field might
        //be modified by multiple threads that are executing at the same time.
        //Fields that are declared volatile are not subject to these optimizations.
        private static volatile T _instance;
        private static readonly object _lock = new object();
        private static bool _appIsQuitting = false;


        private static bool _isLazy;
        private static bool _persist;

        //Properties in c#
        private static bool _instanciated = false;
        public static bool Instanciated
        {
            get { return _instanciated; }
            protected set { _instanciated = value; }
        }

        public static T Instance
        {
            get
            {
                if (_appIsQuitting)
                {
                    Debug.LogWarning("Instance {0} already destroyed on app quit",
                        (T)_instance);
                    return null;
                }
                //A lock statement, in C#, is a statement that contains the "lock"
                //keyword and is used in multithreaded applications to ensure
                //that the current thread executes a block of code to completion
                //without interruption by other threads.
                lock (_lock)
                {
                    if (!_instanciated)
                    {
                        SingletonAwake();
                        return _instance;
                    }
                    return _instance;
                }
            }
        }

        public void InitializeSingleton(bool persist, bool isLazy)
        {
            _appIsQuitting = false;
            _persist = persist;
            _isLazy = isLazy;
            if (_isLazy)
                return;
            SingletonAwake();
        }

        private static void SingletonAwake()
        {
            Object[] objects = Resources.FindObjectsOfTypeAll<T>();
            if (objects != null && objects.Length >= 1)
            {
                if (objects.Length >= 1)
                {
                    T tObject = objects[0] as T;
                    tObject.gameObject.SetActive(true);

                    if (objects.Length > 1)
                    {
                        for (int i = 1; i < objects.Length; i++)
                        {
                            T go = objects[i] as T;
                            Destroy(go.gameObject);
                        }
                    }
                    _instance = objects[0] as T;
                    _instanciated = true;

                    if (_persist)
                        DontDestroyOnLoad(_instance.gameObject);

                }

            }


        }

        private void OnApplicationQuit()
        {
            _persist = false;
        }

        public void OnDestroy()
        {
            _instanciated = false;
            _appIsQuitting = true;
        }
    }
}
