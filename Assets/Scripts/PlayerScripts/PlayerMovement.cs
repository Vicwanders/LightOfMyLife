using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerState))]
public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 10.0f;
    public float jumpSpeed = 5.0f;
    private Rigidbody2D rigidBody;
    private PlayerState playerState;
    private Animator animator;
    private bool inAir = false;

    void Awake()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
        playerState = this.GetComponent<PlayerState>();
        animator = this.GetComponent<Animator>();
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
                animator.SetBool("inAir", inAir);
            }
            float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed;
            rigidBody.velocity = new Vector2(horizontalMovement, rigidBody.velocity.y);
            if (horizontalMovement >= 0)
            {
                this.transform.eulerAngles = Vector3.zero;
            } else
            {
                this.transform.eulerAngles = new Vector3(0, 180, 0);
            }
            animator.SetFloat("walking", Mathf.Abs(horizontalMovement));
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.tag == "Floor" && inAir)
        {
            Debug.Log("Collided with ground");
            inAir = false;
            animator.SetBool("inAir", inAir);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collectable")
        {
            int points = collision.gameObject.GetComponent<CollectablesController>().points;
            playerState.AddLife(points);
            AudioController.Instance.PlaySparkle();
            Destroy(collision.gameObject);
        }
    }
}
