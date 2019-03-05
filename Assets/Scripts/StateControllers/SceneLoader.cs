using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    private static SceneLoader _instance;

    public static SceneLoader Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadSceneAsync("Game");
    }

    public void StartGame()
    {
        AudioController.Instance.PlaySparkle();
        StartCoroutine(LoadGame());
    }

    public void EndGame()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("Menu");
    }
}
