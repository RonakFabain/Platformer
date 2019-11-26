using UnityEngine;

namespace BSP
{
    [RequireComponent(typeof(Canvas))]
    public abstract class Menu : MonoBehaviour
    {
        public virtual void OnBackPressButton()
        {
            if (MenuManager.Instance != null)
                MenuManager.Instance.CloseMenu();
            else
                Debug.LogError("Menu instance is null");
        }
    }

    public abstract class Menu<T> : Menu where T: Menu<T>
    {
        private static bool _instantiated = false;
        public static bool Instantiated { get { return _instantiated; }
            protected set { _instantiated = value; } }

        private static T _instance;
        public static T Instance
        {
            get
            {
                return _instance;
            }
        }

        protected void Awake()
        {
            if (_instantiated)
                Destroy(this.gameObject);
            else
            {
                _instance = (T)this;
                _instantiated = true;
            }
        }

        public static void Open()
        {
            if (MenuManager.Instance != null && Instance != null)
                MenuManager.Instance.OpenMenu(Instance);
            else
                Debug.LogError("Menu instance or menu is null");
        }

        
        private void OnDestroy()
        {
            _instantiated = false;
        }
    }
}
