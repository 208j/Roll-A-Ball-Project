using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    
    public GameObject startMenu;   
    public GameObject pauseMenu;   

    
    public GameObject countText;   
    public GameObject pauseButton; 
    public GameObject winText;     
    public GameObject loseText;    
    public GameObject exitButton;  
    public GameObject restartButton; 

    public static bool isPaused = false;

    bool gameStarted = false;
    bool gameEnded = false;

    void Start()
    {
        // Стартовое меню, игра стоит
        Time.timeScale = 0f;
        isPaused = false;
        gameStarted = false;
        gameEnded = false;

        startMenu.SetActive(true);
        pauseMenu.SetActive(false);

        countText.SetActive(false);
        pauseButton.SetActive(false);
        winText.SetActive(false);
        loseText.SetActive(false);

        exitButton.SetActive(true);    
        restartButton.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        if (!gameStarted || gameEnded) return;

        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnlockCursor();
        }

        
        if (Cursor.lockState != CursorLockMode.Locked)
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                LockCursor();
            }
        }
    }

    

    public void StartGame()
    {
        gameStarted = true;
        gameEnded = false;
        isPaused = false;

        startMenu.SetActive(false);
        pauseMenu.SetActive(false);

        countText.SetActive(true);
        pauseButton.SetActive(true);
        winText.SetActive(false);
        loseText.SetActive(false);

        exitButton.SetActive(false);    
        restartButton.SetActive(false); 

        Time.timeScale = 1f;
        LockCursor();
    }

    public void Pause()
    {
        if (!gameStarted || gameEnded) return;

        isPaused = true;
        Time.timeScale = 0f;

        pauseMenu.SetActive(true);
        countText.SetActive(false);
        pauseButton.SetActive(false);

        exitButton.SetActive(true);     
        restartButton.SetActive(true);  

        UnlockCursor();
    }

    public void Resume()
    {
        if (!gameStarted || gameEnded) return;

        isPaused = false;
        Time.timeScale = 1f;

        pauseMenu.SetActive(false);
        countText.SetActive(true);
        pauseButton.SetActive(true);

        exitButton.SetActive(false);
        restartButton.SetActive(false);

        LockCursor();
    }

    public void Restart()
    {
        isPaused = false;
        gameEnded = false;
        Time.timeScale = 1f;

        UnlockCursor(); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void EndGame(bool win)
    {
        gameEnded = true;
        isPaused = false;
        Time.timeScale = 0f;

        pauseMenu.SetActive(false);
        pauseButton.SetActive(false);
        countText.SetActive(false);

        winText.SetActive(win);
        loseText.SetActive(!win);

        exitButton.SetActive(true);     
        restartButton.SetActive(true);  

        UnlockCursor();
    }

    

    void LockCursor()
    {
        if (!gameStarted || isPaused || gameEnded) return;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}