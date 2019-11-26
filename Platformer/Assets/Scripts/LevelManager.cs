using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    enum MenuType { MainMenu, Running, PauseMenu, Credits }
    MenuType type;

    public static LevelManager Instance;

    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject Running;
    [SerializeField] GameObject Pause;
    [SerializeField] GameObject Credits;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        type = MenuType.MainMenu;
        SelectMenu(type);
    }
    public void Mute()
    {

    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(int id)
    {
        SceneManager.LoadScene(id);
        type = MenuType.Running;
        SelectMenu(type);

    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void OnPause()
    {
        type = MenuType.PauseMenu;
        SelectMenu(type);
        Time.timeScale = 0;
      
    }
    public void Resume()
    {
        type = MenuType.Running;
        SelectMenu(type);
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

                break;
            case MenuType.MainMenu:

                Running.SetActive(false);
                MainMenu.SetActive(true);
                Pause.SetActive(false);
                Credits.SetActive(false);
                break;
            case MenuType.PauseMenu:
                Running.SetActive(false);
                MainMenu.SetActive(false);
                Pause.SetActive(true);
                Credits.SetActive(false);
                break;
            case MenuType.Credits:
                Running.SetActive(false);
                MainMenu.SetActive(false);
                Pause.SetActive(false);
                Credits.SetActive(true);
                break;
        }

    }
}
