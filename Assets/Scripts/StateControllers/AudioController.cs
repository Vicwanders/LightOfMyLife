using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    private static AudioController _instance;

    public static AudioController Instance { get { return _instance; } }
    public AudioSource SparkleFX;
    public AudioSource Background;
    public AudioSource Ending;
    public float smoothingTime = 0.2f;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private IEnumerator SmoothTransition(AudioSource audio1)
    {
        while (audio1.volume > 0)
        {
            audio1.volume -= 0.1f;
            yield return new WaitForSeconds(smoothingTime);
        }
        audio1.Stop();
    }

    private IEnumerator SmoothTransition(AudioSource audio1, AudioSource audio2)
    {
        while (audio1.volume > 0)
        {
            audio1.volume -= 0.1f;
            yield return new WaitForSeconds(smoothingTime);
        }
        audio1.Stop();
        audio2.Play();
    }

    public void PlaySparkle()
    {
        SparkleFX.Play(0);
    }

    public void PlayEnding()
    {
        StartCoroutine(SmoothTransition(Background, Ending));
    }

    public void StopEnding()
    {
        StartCoroutine(SmoothTransition(Ending));
    }
}
