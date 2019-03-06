using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BGMSmoother : MonoBehaviour {
    [Range(0f, 1f)]
    public float MaxVolume = 0.5f;
    public float SmoothingTime = 0.2f;
    public float Increments = 0.1f;
    public bool PlayOnStart = true;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        if (PlayOnStart)
        {
            StartCoroutine(SmoothIncrease());
        }
    }

    public void Play()
    {
        StartCoroutine(SmoothIncrease());
    }

    public void Stop()
    {
        StartCoroutine(SmoothStop());
    }

    private IEnumerator SmoothStop()
    {
        if (audioSource != null)
        {
            while (audioSource.volume > 0)
            {
                audioSource.volume -= Increments;
                yield return new WaitForSeconds(SmoothingTime);
            }
            audioSource.Stop();
        }
    }

    IEnumerator SmoothIncrease()
    {
        audioSource.Play();
        audioSource.volume = 0f;
        while (audioSource.volume < MaxVolume)
        {
            audioSource.volume += Increments;
            yield return new WaitForSeconds(SmoothingTime);
        }
    }
}
