using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenuUI; 
    private bool isPaused = false;
    public SimpleController controller;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false); 
        Time.timeScale = 1f; 
        isPaused = false;
        controller.isPaused = false; 
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false; 
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true); 
        Time.timeScale = 0f; 
        isPaused = true;
        controller.isPaused = true; 
        Cursor.lockState = CursorLockMode.Confined; 
        Cursor.visible = true;
        //UnityEngine.EventSystems.EventSystem.current.enabled = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); 
#endif
    }
}
