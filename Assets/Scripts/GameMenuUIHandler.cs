using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameMenuUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject gameOverView;
    [SerializeField] private GameObject victoryView;
    private bool asyncInProgress = false;

    public async void RestartGame()
    {
        if (asyncInProgress) return;
        asyncInProgress = true;
        await Task.Delay(500);
        SceneManager.LoadScene(1);
    }

    public async void Exit()
    {
        if (asyncInProgress) return;
        asyncInProgress = true;
        await Task.Delay(500);
        SceneManager.LoadScene(0);
    }

    public void ChangeView()
    {
        gameOverView.SetActive(!gameOverView.activeSelf);
    }

    public void victory()
    {
        victoryView.SetActive(!victoryView.activeSelf);
    }
}
