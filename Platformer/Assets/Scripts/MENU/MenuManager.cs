using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

namespace BSP
{

    public class MenuManager : Singleton<MenuManager>
    {
        [SerializeField]
        private MainMenu _mainMenuPrefab;
        [SerializeField]
        private GameMenu _gamemenuPrefab;
        [SerializeField]
        private SettingMenu _settingMenuPrefab;
        [SerializeField]
        private StoreMenu _storeMenuPrefab;

        //public List<Menu> MenuPrefabs = new List<Menu>();

        private Stack<Menu> _menus = new Stack<Menu>();

        private Transform _menuParent;

        private bool IsInitialized = false;


        private void Awake()
        {

            if (!Instanciated)
                InitializeSingleton(true, false);
            else
                IsInitialized = true;
        }

        private void Start()
        {
            if (Instanciated && !IsInitialized)
                InitMenus();
        }

        private void InitMenus()
        {
            if (_menuParent == null)
                _menuParent = new GameObject("Menu").transform;

            //Constrains
            BindingFlags myFlags = BindingFlags.Instance | BindingFlags.NonPublic
                | BindingFlags.DeclaredOnly;

            FieldInfo[] fieldInfo = this.GetType().GetFields(myFlags);

            foreach(FieldInfo field in  fieldInfo)
            {
                Menu prefab = field.GetValue(this) as Menu;
                if(prefab != null)
                {
                    Menu menuInstance = Instantiate(prefab, _menuParent);
                    menuInstance.name = prefab.name;

                    if (prefab != _mainMenuPrefab)
                        menuInstance.gameObject.SetActive(false);
                    else
                        OpenMenu(menuInstance);
                }
            }
        }

        public void OpenMenu(Menu menuInstance)
        {
            if(menuInstance == null)
            {
                Debug.Log("Menu Instance is null");
                return;
            }

            if(_menus.Count > 0)
            {
               foreach(Menu menu in _menus)
                {
                    menu.gameObject.SetActive(false);
                }
            }
            menuInstance.gameObject.SetActive(true);
            _menus.Push(menuInstance);
        }

        public void CloseMenu()
        {
            if(_menus.Count == 0)
            {
                Debug.Log("No menu is avalible");
                return;
            }

            Menu topMenu = _menus.Pop();
            topMenu.gameObject.SetActive(false);

            if(_menus.Count > 0)
            {
                Menu nextMenu = _menus.Peek();
                nextMenu.gameObject.SetActive(true);
            }
        }
     }
}
