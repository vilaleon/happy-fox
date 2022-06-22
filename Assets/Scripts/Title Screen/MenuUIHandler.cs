using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject settingsView;
    [SerializeField] private GameObject defaultView;

    private bool asyncInProgress = false;

    public async void StartGame()
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
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    public void ChangeView()
    {
        settingsView.SetActive(!settingsView.activeSelf);
        defaultView.SetActive(!defaultView.activeSelf);
    }
}
