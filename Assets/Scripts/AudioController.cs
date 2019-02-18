using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    private static AudioController _instance;

    public static AudioController Instance { get { return _instance; } }
    public AudioSource SparkleFX;

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

    public void PlaySparkle()
    {
        SparkleFX.Play(0);
    }

}
