using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {

    public float boundsTolerance = 0.1f; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 cameraPosition = Camera.main.WorldToViewportPoint(transform.position);
        if (cameraPosition.x < -boundsTolerance || cameraPosition.y < -boundsTolerance)
        {
            Debug.Log("Game Over");
            GameState.Instance.IsGameOver = true;
        }
	}
}
