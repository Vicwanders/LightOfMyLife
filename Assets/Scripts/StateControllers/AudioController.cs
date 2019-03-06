using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    private static AudioController _instance;

    public static AudioController Instance { get { return _instance; } }
    public AudioSource SparkleFX;
    public BGMSmoother Background;
    public BGMSmoother Ending;
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

    public void Silence()
    {
        Background.Stop();
        if (Ending)
        {
            Ending.Stop();
        }
    }

    public void PlaySparkle()
    {
        SparkleFX.Play(0);
    }

    public void PlayEnding()
    {
        Background.Stop();
        Ending.Play();
    }

    public void StopEnding()
    {
        Ending.Stop();
    }
}
