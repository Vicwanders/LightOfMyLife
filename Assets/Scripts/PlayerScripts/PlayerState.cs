using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {

    public float boundsTolerance = 0.1f;
    public float shrinkingRate = 5.0f;
    public GameObject mask;
    private int life = 25;
    private float shrinkTimer;

	// Use this for initialization
	void Start () {
        shrinkTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 cameraPosition = Camera.main.WorldToViewportPoint(transform.position);
        if (cameraPosition.x < -boundsTolerance || cameraPosition.y < -boundsTolerance)
        {
            Debug.Log("Game Over");
            GameState.Instance.IsGameOver = true;
        }
        if (GameState.Instance.IsGameRunning())
        {
            shrinkTimer += Time.deltaTime;
            if (shrinkTimer > shrinkingRate)
            {
                life = Mathf.Max(0, life - 1);
                UpdateMask();
                if (life == 0)
                {
                    GameState.Instance.IsGameOver = true;
                }
            }
        }  
	}

    private void UpdateMask()
    {
        this.mask.transform.localScale = new Vector3(life, life, 1);
        shrinkTimer = 0;
    }

    public void AddLife(int life)
    {
        this.life += life;
        UpdateMask();
    }

    public int GetLife()
    {
        return this.life;
    }
}
