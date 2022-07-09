using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    [Serializable]
    private class Section
    {
        public string name;
        public GameObject sectionObject;
    }

    [SerializeField] private Section[] sections;

    public void StartGame()
    {
        StartCoroutine(StartGameCoroutine());

        IEnumerator StartGameCoroutine()
        {
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene("Demo Scene");
        }
    }

    public void ExitGame()
    {
        StartCoroutine(ExitGameCoroutine());

        IEnumerator ExitGameCoroutine()
        {
            yield return new WaitForSeconds(0.5f);
#if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        }
    }

    public void LoadScene(string name)
    {
        StartCoroutine(LoadSceneCoroutine(name));

        IEnumerator LoadSceneCoroutine(string name)
        {
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene(name);
        }
    }

    public void ChangeSection(string name)
    {
        foreach (var section in sections)
        {
            section.sectionObject.SetActive(section.name == name);
        }
    }
}
