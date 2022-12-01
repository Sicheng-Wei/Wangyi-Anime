using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class SceneExchange : MonoBehaviour
{
    public void GamePage()
    {
        SceneManager.LoadScene("StartPage");
    }

    public void StoryPage()
    {
        SceneManager.LoadScene("StoryPage");
    }

    public void WebPage()
    {
        Application.OpenURL("https://github.com/Sicheng-Wei/Wangyi-Anime/blob/main/README.md");
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("StartPage");
        }
    }
}
