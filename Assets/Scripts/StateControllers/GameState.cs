using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {

    private static GameState _instance;

    public static GameState Instance { get { return _instance; } }
    public bool IsGameOver = false;
    public bool IsGameWon = false;
    public bool IsPaused = false;
    public GameObject player;

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

    public bool IsGameRunning()
    {
        return !IsGameOver && !IsPaused && !IsGameWon;
    }

    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "Game" && IsGameOver)
        {
            SceneLoader.Instance.EndGame();
        }
    }

}
