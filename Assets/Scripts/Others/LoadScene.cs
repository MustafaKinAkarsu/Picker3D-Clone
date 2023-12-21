using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    int currentScene;
    public static LoadScene instance;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }
    public void LoadCurrentScene()
    {
        SceneManager.LoadScene(currentScene);
    }
    public void LoadNextScene()
    {
        currentScene++;
        SceneManager.LoadScene(currentScene);
    }
    public int GetCurrentScene()
    {
        return currentScene;
    }
}
