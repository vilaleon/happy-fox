using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject gameOverView;
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
}
