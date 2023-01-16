using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject winMenu;
    public GameObject loseMenu;
    
    private void WinMenu()
    {
        winMenu.SetActive(true);
        winMenu.GetComponent<Animator>().SetBool("Win", true);
    }

    private void LoseMenu()
    {
        loseMenu.SetActive(true);
        loseMenu.GetComponent<Animator>().SetBool("Lose", true);
    }
}
