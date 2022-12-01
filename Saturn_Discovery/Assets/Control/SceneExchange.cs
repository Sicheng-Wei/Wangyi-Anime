using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class SceneExchange : MonoBehaviour
{
    public void StartPage()
    {
        SceneManager.LoadScene("story1");
    }

    public void GamePage()
    {
        SceneManager.LoadScene("StartPage");
    }

    public void Story1()
    {
        SceneManager.LoadScene("story2");
    }

    public void Story2()
    {
        SceneManager.LoadScene("story3");
    }

    public void Story3()
    {
        SceneManager.LoadScene("story4");
    }

    public void Story4()
    {
        SceneManager.LoadScene("story5");
    }

    public void Story5()
    {
        SceneManager.LoadScene("story6");
    }

    public void Story6()
    {
        SceneManager.LoadScene("OutdoorsScene");
    }

    public void introduce()
    {
        //1
        Application.OpenURL("https://github.com/Sicheng-Wei/Wangyi-Anime/blob/main/README.md");
        //2
        //Help.BrowseURL("https://github.com/Sicheng-Wei/Wangyi-Anime/blob/main/README.md");
        //3
        //System.Diagnostics.Process.Start("https://github.com/Sicheng-Wei/Wangyi-Anime/blob/main/README.md");
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
