using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerState : MonoBehaviour {

    public float boundsTolerance = 0.1f;
    public float shrinkingFrequency = 5.0f;
    public GameObject mask;
    public int life = 50;
    private float shrinkTimer;
    private SpriteRenderer spriteRenderer;
    private const int CRITICAL_LIFE = 15;

	// Use this for initialization
	void Start () {
        this.shrinkTimer = 0;
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
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
            this.shrinkTimer += Time.deltaTime;
            if (this.shrinkTimer > this.shrinkingFrequency)
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
    
    /*
    IEnumerator ExpandLife()
    {
        while (this.life < 200)
        {
            yield return new WaitForSeconds(0.01f);
            life += 1;
            UpdateMask();
        }
    }
    */

    private void UpdateMask()
    {
        this.mask.transform.localScale = new Vector3(life, life, 1);
        this.shrinkTimer = 0;
        if (life < CRITICAL_LIFE)
        {
            this.spriteRenderer.color = new Color(1, 1, 1, 1.0f - (CRITICAL_LIFE - life) * (1.0f/CRITICAL_LIFE));
        } else
        {
            this.spriteRenderer.color = new Color(1, 1, 1, 1);
        }
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
