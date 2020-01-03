using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    enum MenuType { MainMenu, Running, PauseMenu, Credits, Levels }
    MenuType menuType;

    [SerializeField]
    public List<Level> levelList = new List<Level>();

    public static UIManager Instance;

    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject Running;
    [SerializeField] GameObject Pause;
    [SerializeField] GameObject Credits;
    [SerializeField] GameObject Levels;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(this);
        
    }

    void InitLevelUI()
    {

        for (int i = 0; i < levelList.Count; i++)
        {
            if (GameObject.Find(i.ToString()) != null)
            {
                //Enable and Disable Levels
                if (GameObject.Find(i.ToString()).GetComponent<Button>() != null)
                {

                    if (levelList[i].isUnlocked == 0)
                    {
                        GameObject.Find(i.ToString()).GetComponent<Button>().interactable = false;
                    }
                    else
                        GameObject.Find(i.ToString()).GetComponent<Button>().interactable = true;
                }


                //Assign Stars
            }


        }
    }
    private void Start()
    {
        InitLevelUI();
        menuType = MenuType.MainMenu;
        SelectMenu(menuType);
        
    }
    public void Mute()
    {

    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // Save and Load levels completed
    void LevelComplete()
    {
        //get score form playerspawner
        //Enable next buttons
        //Update UI

    }
    public void LoadScene(int id)
    {
        SceneManager.LoadScene(id);
        menuType = MenuType.Running;
        SelectMenu(menuType);

    }
    public void LevelSelect()
    {
        menuType = MenuType.Levels;
        SelectMenu(menuType);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void OnPause()
    {
        menuType = MenuType.PauseMenu;
        SelectMenu(menuType);
        Time.timeScale = 0;

    }
    public void Resume()
    {
        menuType = MenuType.Running;
        SelectMenu(menuType);
        Time.timeScale = 1;

    }

    void SelectMenu(MenuType type)
    {
        switch (type)
        {

            case MenuType.Running:
                Running.SetActive(true);
                MainMenu.SetActive(false);
                Pause.SetActive(false);
                Credits.SetActive(false);
                Levels.SetActive(false);

                break;
            case MenuType.MainMenu:

                Running.SetActive(false);
                MainMenu.SetActive(true);
                Pause.SetActive(false);
                Credits.SetActive(false);
                Levels.SetActive(false);
                break;
            case MenuType.PauseMenu:
                Running.SetActive(false);
                MainMenu.SetActive(false);
                Pause.SetActive(true);
                Credits.SetActive(false);
                Levels.SetActive(false);
                break;
            case MenuType.Credits:
                Running.SetActive(false);
                MainMenu.SetActive(false);
                Pause.SetActive(false);
                Credits.SetActive(true);
                Levels.SetActive(false);
                break;

            case MenuType.Levels:
                Running.SetActive(false);
                MainMenu.SetActive(false);
                Pause.SetActive(false);
                Credits.SetActive(false);
                Levels.SetActive(true);
                break;

        }

    }
}
