using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private Button playButton = null;
    [SerializeField] private Button exitTheGame = null;

    private void Awake()
    {
        playButton.onClick.AddListener(PlayGame);
        exitTheGame.onClick.AddListener(ExitTheGame);
    }

    private void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    private void ExitTheGame()
    {
        Application.Quit();
    }
}
