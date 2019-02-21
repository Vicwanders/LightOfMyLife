using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour {

    public GameObject starPrefab;
    public int amount = 1;
    public float limitOffScreen = 0.25f;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < amount; i++)
        {
            Vector3 position = new Vector3(
                Random.Range(0f, 1f) + limitOffScreen * Random.Range(-1f, 1f),
                Random.Range(-3f, 3f), 
                10f);
            GameObject star = Instantiate(
                starPrefab,
                Camera.main.ViewportToWorldPoint(position),
                Quaternion.identity);
            star.transform.parent = this.transform;
        }
	}
}
