using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoder : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartingScene()
    {
        SceneManager.LoadScene(0);
    }

    public void onPressQuit()
    {
        Application.Quit();
    }

    public void LoadScene(string s)
    {
        SceneManager.LoadScene(s);
    }
}
