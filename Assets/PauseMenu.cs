using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseUI;
    public bool isGamePaused = false;
    
    public static PauseMenu instance;

    private void Awake()
    {
        instance = this;
    }

    public bool GetGamePaused()
    {
        return isGamePaused;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseGame(!isGamePaused);
    }

    public void PauseGame(bool value)
    {
        Time.timeScale = value ? 0 : 1;
        isGamePaused = value;
        pauseUI.SetActive(isGamePaused);
        Cursor.visible = isGamePaused;
        Cursor.lockState = isGamePaused ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
