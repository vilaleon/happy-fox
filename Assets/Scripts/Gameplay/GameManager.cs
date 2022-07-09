using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gemsText;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private MenuUIHandler gameMenu;
    [SerializeField] private AudioManager audioManager;

    private int totalGems = 0;
    private int currentGems = 0;
    private bool gameOver;

    public void UpdateTotalGems(int x)
    {
        totalGems += x;
        gemsText.text = "Gems: " + currentGems + "/" + totalGems;
    }

    public void UpdateCurrentGems(int x)
    {
        currentGems += x;
        gemsText.text = "Gems: " + currentGems + "/" + totalGems;


        if (currentGems == totalGems)
        {
            playerObject.SetActive(false);
            audioManager.StopAllMusic();
            audioManager.PlaySFX("End Sound");
            gameMenu.ChangeSection("Victory");
            gameMenu.GetComponent<Animator>().SetTrigger("fadeInTrigger");
        }
    }

    public void GameOver()
    {
        gameOver = true;
        audioManager.StopAllMusic();
        audioManager.PlaySFX("End Sound");
        gameMenu.ChangeSection("Game Over");
        gameMenu.GetComponent<Animator>().SetTrigger("fadeInTrigger");
    }

    public void ChaseStarting()
    {
        audioManager.StopMusic("Ambient");
        audioManager.PlayMusic("Battle");
    }

    public void ChaseEnding()
    {
        audioManager.StopMusic("Battle");
        if (!gameOver) audioManager.PlayMusic("Ambient");
    }

}
