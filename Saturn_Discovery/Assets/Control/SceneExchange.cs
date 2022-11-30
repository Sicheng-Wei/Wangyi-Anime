using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExchange : MonoBehaviour
{
    public void StartPage()
    {
        SceneManager.LoadScene("OutdoorsScene");
    }

    public void GamePage()
    {
        SceneManager.LoadScene("StartPage");
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
