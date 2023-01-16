using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameButtons : MonoBehaviour
{
    [SerializeField] private Button restartButton = null;
    [SerializeField] private Button exitMenuButton = null;
    [SerializeField] private Button settingsButton = null;
    [SerializeField] private GameObject settingsMenu = null;
    [SerializeField] private Button backButton = null;
    
    private void Awake()
    {
        restartButton.onClick.AddListener(RestartGame);
        exitMenuButton.onClick.AddListener(ExitToMenu);
        settingsButton.onClick.AddListener(OpenSettingsMenu);
        backButton.onClick.AddListener(CloseSettingsMenu);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    private void ExitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void OpenSettingsMenu()
    {
        settingsMenu.SetActive(true);
    }
    
    private void CloseSettingsMenu()
    {
        settingsMenu.SetActive(false);
    }
}
