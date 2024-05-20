using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject playerUI;
    [SerializeField] private GameObject pauseScreen;

    private readonly float _timePaused = 0f;
    private readonly float _timeUnpaused = 1f;

    public void ShowHidePauseScreen(bool isActive)
    {
        if (isActive)
            Time.timeScale = _timePaused;
        else
            Time.timeScale = _timeUnpaused;

        pauseScreen.SetActive(isActive);
        playerUI.SetActive(!isActive);
    }

    public void TogglePauseScreen()
    {
        ShowHidePauseScreen(!pauseScreen.activeSelf);
    }
}
