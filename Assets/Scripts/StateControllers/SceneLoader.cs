using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    private static SceneLoader _instance;

    public static SceneLoader Instance { get { return _instance; } }
    public Image TransitionFade;
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

    IEnumerator LoadScene(string scene)
    {
        TransitionFade.enabled = true;
        while (TransitionFade.color.a < 1)
        {
            yield return new WaitForSeconds(0.001f);
            TransitionFade.color = new Vector4(TransitionFade.color.r, TransitionFade.color.g, TransitionFade.color.b, TransitionFade.color.a + 0.01f);
        }
        AudioController.Instance.Silence();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(scene);
    }

    public void StartGame()
    {
        StartCoroutine(LoadScene("Game"));
    }

    public void EndGame()
    {
        StartCoroutine(LoadScene("GameOver"));
    }

    public void MainMenu()
    {
        StartCoroutine(LoadScene("Menu"));
    }
}
