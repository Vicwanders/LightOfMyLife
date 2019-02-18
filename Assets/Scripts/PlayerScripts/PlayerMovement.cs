using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 10.0f;
    public float jumpSpeed = 5.0f;
    private Rigidbody2D rigidBody;
    private bool inAir = false;

    void Awake()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!GameState.Instance.IsGameOver)
        {
            if (Input.GetButton("Jump") && !inAir)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
                inAir = true;
            }
            rigidBody.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rigidBody.velocity.y);
        }   
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.tag == "Floor" && inAir)
        {
            Debug.Log("Collided with ground");
            inAir = false;
        }
    }
}
