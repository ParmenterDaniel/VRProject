using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public InputActionReference openMenuAction;
    public InputActionReference resumeAction;
    public InputActionReference quitAction;

    private bool isPaused = false;
    bool startup = true;

    private void Awake()
    {
        if (startup)
        {
            pauseMenu.SetActive(false);
            startup = false;
        }
        openMenuAction.action.Enable();
        resumeAction.action.Enable();
        quitAction.action.Enable();
        openMenuAction.action.performed += TogglePause;
        resumeAction.action.performed += resumeGame;
        quitAction.action.performed += QuitGame;
    }

    private void OnDestroy()
    {
        openMenuAction.action.Disable();
        resumeAction.action.Disable();
        quitAction.action.Disable();
        openMenuAction.action.performed -= TogglePause;
        resumeAction.action.performed -= resumeGame;
        quitAction.action.performed -= QuitGame;
    }

    public void TogglePause(InputAction.CallbackContext context)
    {
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);

    }

    public void resumeGame(InputAction.CallbackContext context)
    {
        if (isPaused)
        {
            isPaused = !isPaused;
            pauseMenu.SetActive(isPaused);
        }
    }

    public void QuitGame(InputAction.CallbackContext context)
    {
        if (isPaused)
        {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
