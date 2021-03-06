﻿using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    //Set the speed that the camera moves through space
    public float cameraSpeed = 8f;
    public float verticalBound = -6.0f;
    private float currentScrollPosition = 0f;
    private float verticalOffset;

	void Start () {
        switch (SpaceManager.instance.scrollDirection)
        {
            case ScrollDirection.LeftToRight:
            case ScrollDirection.RightToLeft:
                currentScrollPosition = transform.position.x / cameraSpeed;
                break;
            case ScrollDirection.DownToUp: case ScrollDirection.UpToDown:
                currentScrollPosition = transform.position.y / cameraSpeed;
                break;
        }
        verticalOffset = transform.position.y - GameState.Instance.player.transform.position.y;
    }
	
	void Update () {
        //Assign the current position using a variable to set the position
        currentScrollPosition += Time.deltaTime;
        Vector3 newPosition = Vector3.zero;
        //Set the new position based on the scroll direction and speed
        if (GameState.Instance.IsGameRunning())
        {
            float reference = Mathf.Max(transform.position.x, GameState.Instance.player.transform.position.y);
            newPosition = new Vector3(
                Mathf.Lerp(reference, cameraSpeed * currentScrollPosition, 1f * Time.deltaTime),
                Mathf.Max(GameState.Instance.player.transform.position.y + verticalOffset, verticalBound), 
                transform.position.z);
            /*
            switch (SpaceManager.instance.scrollDirection)
            {
                case ScrollDirection.LeftToRight:
                    newPosition = new Vector3(Mathf.Lerp(transform.position.x, cameraSpeed * currentScrollPosition, 1f * Time.deltaTime), transform.position.y, transform.position.z);
                    break;
                case ScrollDirection.RightToLeft:
                    newPosition = new Vector3(Mathf.Lerp(transform.position.x, -cameraSpeed * currentScrollPosition, 1f * Time.deltaTime), transform.position.y, transform.position.z);
                    break;
                case ScrollDirection.DownToUp:
                    newPosition = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, cameraSpeed * currentScrollPosition, 1f * Time.deltaTime), transform.position.z);
                    break;
                case ScrollDirection.UpToDown:
                    newPosition = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, -cameraSpeed * currentScrollPosition, 1f * Time.deltaTime), transform.position.z);
                    break;
            }
            */
            transform.position = newPosition;
        }
    }
}
