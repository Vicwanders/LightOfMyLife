using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalCutscene : MonoBehaviour {

    public Image fade;
    public Text text;
    private PlayerState PlayerState;
    private bool startedEnding = false;
    private bool finalSceneReached = false;

	// Update is called once per frame
	void Update () {
	    if (GameState.Instance.IsGameWon && !startedEnding)
        {
            startedEnding = true;
            if (PlayerState == null)
            {
                PlayerState = GameState.Instance.player.GetComponent<PlayerState>();
            }
            StartCoroutine(ExpandLife());
            AudioController.Instance.PlayEnding();
        }
        if (finalSceneReached && (Input.GetMouseButtonDown(0) || Input.GetButton("Submit"))) {
            SceneLoader.Instance.MainMenu();
        }
	}

    IEnumerator ExpandLife()
    {
        while (PlayerState.GetLife() < 350)
        {
            yield return new WaitForSeconds(0.01f);
            PlayerState.AddLife(1);
        }
        StartCoroutine(FadeOff());
    }

    IEnumerator FadeOff()
    {
        SpriteRenderer sprite = GameState.Instance.player.GetComponent<SpriteRenderer>();
        while (sprite.color.a > 0)
        {
            yield return new WaitForSeconds(0.01f);
            sprite.color = new Vector4(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a - 0.01f);
            transform.localScale = new Vector2(transform.localScale.x + 0.01f, transform.localScale.y + 0.01f);
        }
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 5f);
        StartCoroutine(FadeBackground());
    }

    IEnumerator FadeBackground()
    {
        while (fade.color.a < 1)
        {
            yield return new WaitForSeconds(0.05f);
            fade.color = new Vector4(fade.color.r, fade.color.g, fade.color.b, fade.color.a + 0.01f);
        }
        StartCoroutine(FadeText());
    }

    IEnumerator FadeText()
    {
        while (text.color.a < 1)
        {
            yield return new WaitForSeconds(0.01f);
            text.color = new Vector4(text.color.r, text.color.g, text.color.b, text.color.a + 0.01f);
        }
        //AudioController.Instance.StopEnding();
        yield return new WaitForSeconds(5f);
        finalSceneReached = true;
        //SceneLoader.Instance.MainMenu();
    }
}
