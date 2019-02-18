using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSize : MonoBehaviour {
    [Range(1.0f, 10.0f)]
    public float multiplierMax = 3f;
    public bool randomRotate = false;
    Vector3 initialScale;

    void Start () {
        //Initial scale
        initialScale = transform.localScale;
        Generate();
    }

    public void Generate()
    {
        //Choose a random multiplied scale from the initial scale and the multiplierMax variable
        transform.localScale = initialScale * Random.Range(1f, multiplierMax);
        if (randomRotate)
        {
            Vector3 angles = transform.eulerAngles;
            angles.z = Random.Range(0, 360);
            transform.eulerAngles = angles;
        }
    }
    
    void Update () {
		
	}
}
