using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
        LoadAsyncScene();
        Debug.Log("Starting");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Closing");
    }
    IEnumerator LoadAsyncScene()
    {
        AsyncOperation m_asyncLoad = SceneManager.LoadSceneAsync("Scene1");
        while (!m_asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
