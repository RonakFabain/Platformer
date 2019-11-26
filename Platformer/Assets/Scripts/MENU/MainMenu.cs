using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BSP
{

    public class MainMenu : Menu<MainMenu>
    {
        public void OnPlay()
        {
            GameMenu.Open();
        }

        public void OnSettingPressed()
        {
            SettingMenu.Open();
        }

        public void OnStorePressed()
        {
            StoreMenu.Open();
        }
    }
}
