using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public bool moving = false;
    public ScrollDirection moveDirection;
    public float distance;
    public float speed;
    private bool forward = true;
    private Vector2 origin;

	// Use this for initialization
	void Start () {
        origin = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (moving && distance != 0 && speed != 0)
        {
            float displacement = speed * Time.deltaTime;
            if (!forward)
            {
                displacement *= -1;
            }
            float newPosition;
            switch (moveDirection)
            {
                case ScrollDirection.UpToDown:
                    newPosition = this.transform.position.y + displacement;
                    if (forward && newPosition > this.origin.y + distance ||
                        !forward && newPosition < this.origin.y)
                    {
                        forward = !forward;
                    } else
                    {
                        this.transform.position = new Vector2(this.transform.position.x, newPosition);
                    }
                    break;
                case ScrollDirection.DownToUp:
                    newPosition = this.transform.position.y - displacement;
                    if (forward && newPosition < this.origin.y - distance ||
                        !forward && newPosition > this.origin.y)
                    {
                        forward = !forward;
                    }
                    else
                    {
                        this.transform.position = new Vector2(this.transform.position.x, newPosition);
                    }
                    break;
                case ScrollDirection.LeftToRight:
                    newPosition = this.transform.position.x + displacement;
                    if (forward && newPosition > this.origin.x + distance ||
                        !forward && newPosition < this.origin.x)
                    {
                        forward = !forward;
                    }
                    else
                    {
                        this.transform.position = new Vector2(newPosition, this.transform.position.y);
                    }
                    break;
                case ScrollDirection.RightToLeft:
                    newPosition = this.transform.position.x - displacement;
                    if (forward && newPosition < this.origin.x - distance ||
                        !forward && newPosition > this.origin.x)
                    {
                        forward = !forward;
                    }
                    else
                    {
                        this.transform.position = new Vector2(newPosition, this.transform.position.y);
                    }
                    break;
                default:
                    break;
            }
        }
		
	}
}
